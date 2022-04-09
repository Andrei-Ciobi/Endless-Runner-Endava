using UnityEngine;

namespace My_Assets.Scrips.Abilities_Module
{
    [CreateAssetMenu(fileName = "New ability data", menuName = "ScriptableObjects/Player/Abilities/BonusJump", order = 0)]
    public class BonusJumpAbilityData : BaseAbilityData
    {
        [SerializeField] private float jumpHeight;

        public float GetJumpHeight()
        {
            return jumpHeight;
        }
    }
}