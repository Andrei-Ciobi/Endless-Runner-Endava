using UnityEngine;
using UnityEngine.InputSystem;

namespace My_Assets.Scrips.Player_Module
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed;

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

            if (isMoveing)
            {
                Movement();
            }
            else
            {
                ResetMovementVelocity();
            }
        }

        public void OnMovementStarted(InputAction.CallbackContext context)
        {
            moveDirection = context.ReadValue<Vector2>();

            isMoveing = true;
        }

        public void OnMovementEnded(InputAction.CallbackContext context)
        {
            isMoveing = false;

            moveDirection = Vector2.zero;
        }


        private void Movement()
        {
            var movement = (int) moveDirection.x;
            playerRigidbody.velocity = transform.right * movement * speed + transform.up * playerRigidbody.velocity.y;
        }

        private void ResetMovementVelocity()
        {
            var movement = new Vector3(0, playerRigidbody.velocity.y, 0);
            playerRigidbody.velocity = movement;
        }

        private void CheckForGrounded()
        {
            groundedPlayer = Physics.Raycast(transform.position, Vector3.down, 1f, 1 << LayerMask.NameToLayer($"Ground"));
        }
    }
}