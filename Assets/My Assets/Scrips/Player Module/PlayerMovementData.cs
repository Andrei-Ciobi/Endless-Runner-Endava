using UnityEngine;

namespace My_Assets.Scrips.Player_Module
{
    [CreateAssetMenu(fileName = "New movement data", menuName = "ScriptableObjects/Player/MovementData")]
    public class PlayerMovementData : ScriptableObject
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpHeight;
        [SerializeField] private float moveDistance;

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
    }
}