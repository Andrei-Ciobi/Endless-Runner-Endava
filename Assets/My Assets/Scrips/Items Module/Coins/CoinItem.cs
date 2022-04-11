using My_Assets.Scrips.Game_module;
using My_Assets.Scrips.ObjectPool_Module;
using My_Assets.Scrips.UI_Module;
using My_Assets.Scrips.Utyles_Module;
using UnityEngine;

namespace My_Assets.Scrips.Items_Module.Coins
{
    public class CoinItem : MonoBehaviour
    {
        [SerializeField] private CoinItemData coinData;

        private Collider coinCollider;

        private void Awake()
        {
            coinCollider = GetComponent<Collider>();
            coinCollider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!other.CompareTag("Player"))
                return;
            
            GameInventoryManager.Instance.UpdateCurrentRunCoins(coinData.GetCoinValue());
            UIManager.Instance.GetPlayerUI().UpdateCoins(GameInventoryManager.Instance.GetCurrentRunCoins());
            PoolManager.Instance.SendBackToPool(ObjectPoolType.Coins, gameObject);
            GameManager.Instance.SpawnGameObject(ObjectPoolType.Coins);
        }
    }
}