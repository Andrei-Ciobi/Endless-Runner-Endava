using UnityEngine;

namespace My_Assets.Scrips.Utyles_Module
{
    [System.Serializable]
    public class GameManagerSet<TK, TV> : SerializableSet<TK, TV>
    {
        [SerializeField] private float speed;
        [SerializeField] private bool useScaleSpeed;

        public float GetSpeed()
        {
            return speed;
        }

        public bool UseScaleSpeed()
        {
            return useScaleSpeed;
        }
    }
}