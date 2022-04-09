using My_Assets.Scrips.Abilities_Module;
using My_Assets.Scrips.Game_module;
using My_Assets.Scrips.Utyles_Module;
using UnityEngine;

namespace My_Assets.Scrips.ObjectPool_Module
{
    public class AbilitiesSendToPool : BaseSendToPoolTrigger
    {
        private void Awake()
        {
            Initialize();
            tagType = ObjectPoolType.Ability;
        }
        
        protected override void OnTriggerEnter(Collider other)
        {
            if(!other.CompareTag(tagType.ToString()))
                return;

            var ability = other.GetComponent<BaseAbility>();
            if(ability.IsActivated)
                return;
            
            PoolManager.Instance.SendBackToPool(tagType, other.gameObject);
            GameManager.Instance.SpawnGameObject(tagType);
        }
    }
}