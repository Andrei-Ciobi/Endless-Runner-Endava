using My_Assets.Scrips.Utyles_Module;
using UnityEngine;

namespace My_Assets.Scrips.Game_module
{
    public class GameInventoryManager : MonoSingleton<GameInventoryManager>
    {
        [SerializeField] private GameInventoryData gameData;
        [SerializeField] private float currentRunScore;
        [SerializeField] private int currentRunCoins;

        private void Awake()
        {
            InitializeMonoSingleton();
        }


        public void UpdateCurrentRunScore(float value)
        {
            currentRunScore += value;
        }

        public void UpdateCurrentRunCoins(int value)
        {
            currentRunCoins += value;
        }

        public void OnEndGame()
        {
            if (NewHighScore())
            {
                gameData.SetHighScore(currentRunScore);
            }
            
            gameData.UpdateCurrentCoins(currentRunCoins);
        }
        
        public bool NewHighScore()
        {
            return currentRunScore >= gameData.GetHighScore();
        }

        public float GetCurrentRunScore()
        {
            return currentRunScore;
        }
        
        
    }
}