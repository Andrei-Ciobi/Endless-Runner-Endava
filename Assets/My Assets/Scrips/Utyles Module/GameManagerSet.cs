using UnityEngine;

namespace My_Assets.Scrips.Utyles_Module
{
    [System.Serializable]
    public class GameManagerSet<TK, TV, TSV> : SerializableSet<TK, TV>
    {
        [SerializeField] private TSV secondValue;

        public TSV GetSecondValue()
        {
            return secondValue;
        }
    }
}