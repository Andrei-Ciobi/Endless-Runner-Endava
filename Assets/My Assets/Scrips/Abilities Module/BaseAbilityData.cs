using UnityEngine;

namespace My_Assets.Scrips.Abilities_Module
{
    public abstract class BaseAbilityData : ScriptableObject
    {
        [SerializeField] private float duration;

        public float GetDuration()
        {
            return duration;
        }
    }
}