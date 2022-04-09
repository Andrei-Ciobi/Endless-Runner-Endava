using My_Assets.Scrips.Game_module;
using My_Assets.Scrips.Utyles_Module;
using UnityEngine;

namespace My_Assets.Scrips.ObjectPool_Module
{
    public class LanesSendToPoolTrigger : BaseSendToPoolTrigger
    {
        [SerializeField] private int numberOfLanes;
        private int counter;
        private void Awake()
        {
            Initialize();
            tagType = ObjectPoolType.Lanes;
        }


        protected override void OnTriggerEnter(Collider other)
        {
            if(!other.CompareTag(tagType.ToString()))
                return;
            
            PoolManager.Instance.SendBackToPool(tagType, other.gameObject);

            if (counter == numberOfLanes - 1)
            {
                GameManager.Instance.SpawnGameObject(tagType);
                counter = 0;
            }
            else
            {
                counter++;
            }
        }
    }
}