using System.Collections;
using System.Collections.Generic;
using My_Assets.Scrips.Input_Module;
using My_Assets.Scrips.ObjectPool_Module;
using My_Assets.Scrips.Player_Module;
using My_Assets.Scrips.UI_Module;
using My_Assets.Scrips.Utyles_Module;
using UnityEngine;

namespace My_Assets.Scrips.Game_module
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public bool IsGameOver => isGameOver;
        
        [SerializeField] private int numberOfLanes;
        [SerializeField] private List<GameManagerSet<ObjectPoolType, Transform, float>> objectsTransform;

        private bool isGameOver;
        private bool gameStarted;
        private readonly Dictionary<ObjectPoolType, Vector3> objectsLastPosition = new Dictionary<ObjectPoolType, Vector3>();

        private void Awake()
        {
            InitializeMonoSingleton();
        }

        private void Start()
        {
            InitializeLastPositions();
            InitializeBatches();
        }

        public void StartGame()
        {
            if(gameStarted)
                return;
            
            gameStarted = true;
            isGameOver = false;
            GameInputManager.Instance.EnablePlayerActionMap();
            UIManager.Instance.OnStartGame();
            PlayerManager.Instance.OnStartGame();
            StartCoroutine(MoveObjects());
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

        public void EndGame()
        {
            isGameOver = true;
            GameInputManager.Instance.DisablePlayerActionMap();
            PlayerManager.Instance.OnEndGame();
            GameInventoryManager.Instance.OnEndGame();
            UIManager.Instance.OnEndGame();
        }
        
        private void SpawnLanes()
        {
            for (var i = numberOfLanes - 1; i >= 0; --i)
            {
                var objectPool = PoolManager.Instance.GetObjectPool(ObjectPoolType.Lanes);
                var objData = objectPool.GetPoolData();
                var obj = objectPool.GetPooledObject();
                var parent = objectsTransform.Find(set => set.GetKey() == objData.GetObjectPoolType()).GetValue();
            
                obj.SetActive(true);
                obj.transform.parent = parent;
                obj.transform.localPosition = objectsLastPosition[objData.GetObjectPoolType()] +
                                              new Vector3(-i * 3f, 0f, objData.GetSpaceBetween());

                if (i == 0)
                {
                    var pos = obj.transform.localPosition;
                    pos.x = 0f;
                    objectsLastPosition[objData.GetObjectPoolType()] = pos;
                }
            }
        }

        private void SpawnGenericObject(ObjectPoolType type)
        {
            var objectPool = PoolManager.Instance.GetObjectPool(type);
            var objData = objectPool.GetPoolData();
            var obj = objectPool.GetPooledObject();
            var parent = objectsTransform.Find(set => set.GetKey() == objData.GetObjectPoolType()).GetValue();

            var r = Random.Range(0, numberOfLanes);
            obj.SetActive(true);
            obj.transform.parent = parent;
            obj.transform.localPosition = objectsLastPosition[objData.GetObjectPoolType()] +
                                          new Vector3(-r * 3f, 0f, objData.GetSpaceBetween());
            var pos = obj.transform.localPosition;
            pos.x = 0f;
            objectsLastPosition[objData.GetObjectPoolType()] = pos;
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
                if (UIManager.Instance.IsGamePaused)
                    yield return null;

                var time = Time.deltaTime;
                foreach (var set in objectsTransform)
                {
                    var parent = set.GetValue();
                    var objectsSpeed = set.GetSecondValue();
                    parent.transform.Translate(-Vector3.forward * (objectsSpeed * time));
                }
                
                GameInventoryManager.Instance.UpdateCurrentRunScore(time);
                UIManager.Instance.GetPlayerUI().UpdateScore(GameInventoryManager.Instance.GetCurrentRunScore());

                yield return null;
            }
        }
    }
}