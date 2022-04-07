using System.Collections;
using System.Collections.Generic;
using System.Linq;
using My_Assets.Scrips.ObjectPool_Module;
using My_Assets.Scrips.Utyles_Module;
using UnityEngine;

namespace My_Assets.Scrips.Game_module
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] private float objectsSpeed;
        [SerializeField] private int numberOfLanes;
        [SerializeField] private Transform laneReferencePoint;
        [SerializeField] private List<SerializableSet<ObjectPoolType, Transform>> objectsTransform;

        private bool isGameOver;
        private readonly Dictionary<ObjectPoolType, Vector3> objectsLastPosition = new Dictionary<ObjectPoolType, Vector3>();

        private void Awake()
        {
            InitializeMonoSingleton();
        }

        private void Start()
        {
            InitializeLastPositions();
            InitializeBatches();
            StartCoroutine(MoveObjects());
        }

        private void StartGame()
        {
            isGameOver = false;
        }


        public void SpawnGameObject(ObjectPoolType type)
        {
            if (type == ObjectPoolType.Lanes)
            {
                SpawnLanes();
            }
            else
            {
                SpawnGenericObject(type);
            }
        }


        private void SpawnLanes()
        {
            for (var i = numberOfLanes; i > 0; --i)
            {
                var objectPool = PoolManager.Instance.GetObjectPool(ObjectPoolType.Lanes);
                var objData = objectPool.GetPoolData();
                var obj = objectPool.GetPooledObject();
                var parent = objectsTransform.Find(set => set.GetKey() == objData.GetObjectPoolType()).GetValue();
            
                obj.SetActive(true);
                obj.transform.parent = parent;
                obj.transform.localPosition = laneReferencePoint.localPosition +
                                              new Vector3(-i * 3f, 0f, objData.GetSpaceBetween());

                if (i == 1)
                {
                    objectsLastPosition[objData.GetObjectPoolType()] = obj.transform.localPosition;
                    var lastPosition = obj.transform.localPosition;
                    lastPosition.x = 0f;
                    laneReferencePoint.localPosition = lastPosition;
                }
            }
        }

        private void SpawnGenericObject(ObjectPoolType type)
        {
            var objectPool = PoolManager.Instance.GetObjectPool(type);
            var objData = objectPool.GetPoolData();
            var obj = objectPool.GetPooledObject();
            var parent = objectsTransform.Find(set => set.GetKey() == objData.GetObjectPoolType()).GetValue();
            
            obj.SetActive(true);
            obj.transform.parent = parent;
            obj.transform.localPosition = objectsLastPosition[objData.GetObjectPoolType()] +
                                          new Vector3(0f, 0f, objData.GetSpaceBetween());
            objectsLastPosition[objData.GetObjectPoolType()] = obj.transform.localPosition;
        }

        private void InitializeLastPositions()
        {
            var objectPools = PoolManager.Instance.GetAllObjectPools();
            foreach (var pool in objectPools)
            {
                objectsLastPosition.Add(pool.GetPoolData().GetObjectPoolType(), Vector3.zero);
            }
        }

        private void InitializeBatches()
        {
            var objectPools = PoolManager.Instance.GetAllObjectPools();
            foreach (var pool in objectPools)
            {
                var poolData = pool.GetPoolData();
                for (var i = 0; i < poolData.GetBatchSize(); ++i)
                {
                    SpawnGameObject(poolData.GetObjectPoolType());
                }
            }
        }


        private IEnumerator MoveObjects()
        {
            while (!isGameOver)
            {
                foreach (var parent in objectsTransform.Select(set => set.GetValue()))
                {
                    parent.transform.Translate(-Vector3.forward * (objectsSpeed * Time.deltaTime));
                }

                yield return null;
            }
        }
    }
}