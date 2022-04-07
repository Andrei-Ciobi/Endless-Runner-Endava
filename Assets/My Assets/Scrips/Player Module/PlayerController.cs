using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace My_Assets.Scrips.Player_Module
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveDistance;
        [SerializeField] private float speed;
        [SerializeField] private float jumpHeight;

        private Rigidbody playerRigidbody;
        private bool isMoveing;
        private bool groundedPlayer;
        private Vector2 moveDirection;

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }


        private void FixedUpdate()
        {
            CheckForGrounded();
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
            endPosition += direction * moveDistance;

            StartCoroutine(SmoothMovement(endPosition));

        }
        
        public void Jump(InputAction.CallbackContext context)
        {
            if (!groundedPlayer)
                return;
            
            // Calculate the jump force required to reach the given height
            var jumpForce = Mathf.Sqrt(jumpHeight * -2 * Physics.gravity.y);
            
            var direction = Vector3.up * jumpForce;
            playerRigidbody.AddForce(direction, ForceMode.VelocityChange);
        }

        private void CheckForGrounded()
        {
            groundedPlayer = Physics.Raycast(transform.position, Vector3.down, 1.2f, 1 << LayerMask.NameToLayer($"Ground"));
        }

        private IEnumerator SmoothMovement(Vector3 endPosition)
        {
            var startPosition = transform.position;
            var time = 0f;
            while (Math.Abs(transform.position.x - endPosition.x) > .15f)
            {
                var newPosition = Vector3.Lerp(startPosition, endPosition, time * speed); 
                playerRigidbody.MovePosition(newPosition);
                time += Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }
            isMoveing = false;
        }
    }
}