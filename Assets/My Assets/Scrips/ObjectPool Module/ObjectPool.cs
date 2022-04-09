using System.Collections.Generic;
using UnityEngine;

namespace My_Assets.Scrips.ObjectPool_Module
{
    public class ObjectPool
    {
        private readonly PoolData poolData;
        private readonly Transform poolParent;

        private List<GameObject> pooledObjects;

        public ObjectPool(Transform poolParent, PoolData poolData)
        {
            this.poolData = poolData;
            this.poolParent = poolParent;
        }


        public GameObject GetPooledObject()
        {
            var availablePoolObjects = pooledObjects.FindAll((obj) => !obj.activeInHierarchy);
            if (availablePoolObjects.Count == 0)
            {
                Debug.LogError("No available pool object");
                return null;
            }

            var randomIndex = Random.Range(0, availablePoolObjects.Count);
            
            return availablePoolObjects[randomIndex];
        }

        public PoolData GetPoolData()
        {
            return poolData;
        }
        
        public void SendBackInPool(GameObject obj)
        {
            if (obj.activeInHierarchy)
            {
                obj.transform.parent = poolParent;
                obj.SetActive(false);
            }
        }

        public void Initialize()
        {
            pooledObjects = new List<GameObject>();

            for (var i = 0; i < poolData.GetSizeOfPool(); ++i)
            {
                var sampleObjects = poolData.GetSampleObjects();
                var randomIndex = Random.Range(0, sampleObjects.Count);
                var obj = Object.Instantiate(sampleObjects[randomIndex], poolParent);
                obj!.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }
}