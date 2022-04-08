using UnityEngine;

namespace My_Assets.Scrips.Game_module
{
    [CreateAssetMenu(fileName = "New inventory data", menuName = "ScriptableObjects/Player/InventoryData", order = 0)]
    public class InventoryData : ScriptableObject
    {
        [SerializeField] private float highScore;
        [SerializeField] private int currentCoins;

        public float GetHighScore()
        {
            return highScore;
        }

        public int GetCurrentCoins()
        {
            return currentCoins;
        }

        public void SetHighScore(float score)
        {
            highScore = score;
        }

        public void SetCurrentCoins(int value)
        {
            currentCoins = value;
        }

        public void UpdateCurrentCoins(int value)
        {
            currentCoins += value;
        }
    }
}