using System;
using System.Collections;
using My_Assets.Scrips.Game_module;
using My_Assets.Scrips.Utyles_Module;
using UnityEngine;
using UnityEngine.InputSystem;

namespace My_Assets.Scrips.Player_Module
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerMovementData movementData;

        private Rigidbody playerRigidbody;
        private Animator animator;
        private bool isMoveing;
        private bool groundedPlayer;
        private bool isJumping;
        private Vector2 moveDirection;
        private float bonusJump;

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            animator = GetComponentInChildren<Animator>();
        }


        private void FixedUpdate()
        {
            CheckForGrounded();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if(!collision.gameObject.CompareTag(ObjectPoolType.Obstacles.ToString()))
                return;
            
            GameManager.Instance.EndGame();
        }

        public void Movement(InputAction.CallbackContext context)
        {
            if(isMoveing)
                return;

            isMoveing = true;
            moveDirection = context.ReadValue<Vector2>();

            var endPosition = transform.position;
            var inputDirection = (int) moveDirection.x;
            var direction = transform.right * inputDirection;
            endPosition += direction * movementData.GetMoveDistance();

            StartCoroutine(SmoothMovement(endPosition));

        }
        
        public void Jump(InputAction.CallbackContext context)
        {
            if (isJumping)
                return;
            
            animator.SetBool(PlayerState.IsJumping.ToString(), true);
            isJumping = true;
            
            // Calculate the jump force required to reach the given height
            var jumpHeight = movementData.GetJumpHeight() + bonusJump;
            var jumpForce = Mathf.Sqrt(jumpHeight * -2 * Physics.gravity.y);
            
            var direction = Vector3.up * jumpForce;
            playerRigidbody.AddForce(direction, ForceMode.VelocityChange);

            StartCoroutine(ResetJump(movementData.GetResetJumpDelay()));
        }

        public void SetBonusJumpHeight(float value)
        {
            bonusJump = value;
        }

        public void ResetBonusJumpHeight()
        {
            bonusJump = 0f;
        }

        public Animator GetAnimator()
        {
            return animator;
        }
        

        private void CheckForGrounded()
        {
            groundedPlayer = Physics.Raycast(transform.position, Vector3.down, 1.2f, 1 << LayerMask.NameToLayer($"Ground"));
        }

        private IEnumerator SmoothMovement(Vector3 endPosition)
        {
            var startPosition = transform.position;
            var time = 0f;
            while (Math.Abs(transform.position.x - endPosition.x) > .01f && !GameManager.Instance.IsGameOver)
            {
                var newPosition = Vector3.Lerp(startPosition, endPosition, time * movementData.GetSpeed()); 
                playerRigidbody.MovePosition(newPosition);
                time += Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }
            isMoveing = false;
        }

        private IEnumerator ResetJump(float delay)
        {
            yield return new WaitForSeconds(delay);

            while (isJumping && !GameManager.Instance.IsGameOver)
            {
                if (groundedPlayer)
                {
                    animator.SetBool(PlayerState.IsJumping.ToString(), false);
                    isJumping = false;
                }

                yield return new WaitForFixedUpdate();
            }
        }


    }
}