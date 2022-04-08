using My_Assets.Scrips.Game_module;
using My_Assets.Scrips.Utyles_Module;
using UnityEngine;

namespace My_Assets.Scrips.ObjectPool_Module
{
    [RequireComponent(typeof(BoxCollider))]
    public class BaseSendToPoolTrigger : MonoBehaviour
    {
        [SerializeField] protected ObjectPoolType tagType;
        private Collider triggerCollider;
        private void Awake()
        {
           Initialize();
        }

        protected void Initialize()
        {
            triggerCollider = GetComponent<Collider>();
            triggerCollider.isTrigger = true;
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if(!other.CompareTag(tagType.ToString()))
                return;
            
            PoolManager.Instance.SendBackToPool(tagType, other.gameObject);
            GameManager.Instance.SpawnGameObject(tagType);
        }
        
    }
}