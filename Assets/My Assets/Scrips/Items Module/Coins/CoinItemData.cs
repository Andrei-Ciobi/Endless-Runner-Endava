using UnityEngine;

namespace My_Assets.Scrips.Items_Module.Coins
{
    [CreateAssetMenu(fileName = "New coin data", menuName = "ScriptableObjects/Player/Items/Coin", order = 0)]
    public class CoinItemData : ScriptableObject
    {
        [SerializeField] [Range(1, 10)] private int coinValue;


        public int GetCoinValue()
        {
            return coinValue;
        }
    }
}