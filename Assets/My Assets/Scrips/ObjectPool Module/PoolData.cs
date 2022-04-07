using System.Collections.Generic;
using My_Assets.Scrips.Utyles_Module;
using UnityEngine;

namespace My_Assets.Scrips.ObjectPool_Module
{
    [CreateAssetMenu(fileName = "New pool data", menuName = "ScriptableObjects/ObjectPool/PoolData")]
    public class PoolData : ScriptableObject
    {
        [SerializeField] private ObjectPoolType type;
        [SerializeField] private int sizeOfPool;
        [SerializeField] private List<GameObject> sampleObjects;


        public ObjectPoolType GetObjectPoolType()
        {
            return type;
        }

        public int GetSizeOfPool()
        {
            return sizeOfPool;
        }

        public List<GameObject> GetSampleObjects()
        {
            return sampleObjects;
        }
    }
}