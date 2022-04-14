using UnityEngine;

namespace My_Assets.Scrips.Player_Module
{
    [CreateAssetMenu(fileName = "New movement data", menuName = "ScriptableObjects/Player/MovementData")]
    public class PlayerMovementData : ScriptableObject
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpHeight;
        [SerializeField] private float moveDistance;
        [SerializeField] [Range(0f, .5f)] private float resetJumpDelay;

        public float GetSpeed()
        {
            return speed;
        }

        public float GetJumpHeight()
        {
            return jumpHeight;
        }

        public float GetMoveDistance()
        {
            return moveDistance;
        }

        public float GetResetJumpDelay()
        {
            return resetJumpDelay;
        }
    }
}