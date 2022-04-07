using System.Collections.Generic;
using UnityEngine;

namespace My_Assets.Scrips.ObjectPool_Module
{
    public class ObjectPool
    {
        private readonly List<GameObject> sampleObjects;
        private readonly int sizeOfPool;
        private readonly Transform poolParent;

        private List<GameObject> pooledObjects;

        public ObjectPool(List<GameObject> sampleObjects, int sizeOfPool, Transform poolParent)
        {
            this.sampleObjects = sampleObjects;
            this.sizeOfPool = sizeOfPool;
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

            for (var i = 0; i < sizeOfPool; ++i)
            {
                var randomIndex = Random.Range(0, sampleObjects.Count);
                var obj = Object.Instantiate(sampleObjects[randomIndex], poolParent);
                obj!.SetActive(true);
                pooledObjects.Add(obj);
            }
        }
    }
}