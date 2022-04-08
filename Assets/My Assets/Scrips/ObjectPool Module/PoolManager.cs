using System.Collections.Generic;
using System.Linq;
using My_Assets.Scrips.Utyles_Module;
using UnityEngine;

namespace My_Assets.Scrips.ObjectPool_Module
{
    public class PoolManager : MonoSingleton<PoolManager>
    {
        [Header("List of all object pools data")] [SerializeField]
        private List<SerializableSet<Transform, PoolData>> poolDataList =
            new List<SerializableSet<Transform, PoolData>>();

        private readonly Dictionary<ObjectPoolType, ObjectPool> objectPools = new Dictionary<ObjectPoolType, ObjectPool>();

        private void Awake()
        {
            InitializeMonoSingleton();
            InitializePools();
        }


        public ObjectPool GetObjectPool(ObjectPoolType type)
        {
            if (!objectPools.ContainsKey(type))
            {
                Debug.LogError($"No pool with key {type}");
                return null;
            }

            return objectPools[type];
        }

        public List<ObjectPool> GetAllObjectPools()
        {
            return objectPools.Values.ToList();
        }

        public void SendBackToPool(ObjectPoolType type, GameObject obj)
        {
            var objectPool = GetObjectPool(type);
            objectPool.SendBackInPool(obj);
        }
        
        

        private void InitializePools()
        {
            foreach (var set in poolDataList)
            {
                var poolData = set.GetValue();
                var objPool = new ObjectPool(set.GetKey(), poolData);
                
                objPool.Initialize();
                objectPools.Add(poolData.GetObjectPoolType(), objPool);
            }
        }
    }
}