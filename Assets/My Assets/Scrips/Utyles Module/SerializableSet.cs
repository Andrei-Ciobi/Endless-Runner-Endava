using UnityEngine;

namespace My_Assets.Scrips.Utyles_Module
{
    [System.Serializable]
    public class SerializableSet<TK, TV>
    {
        [SerializeField] private TK key;
        [SerializeField] private TV value;


        public TK GetKey()
        {
            return key;
        }

        public TV GetValue()
        {
            return value;
        }
    }
}