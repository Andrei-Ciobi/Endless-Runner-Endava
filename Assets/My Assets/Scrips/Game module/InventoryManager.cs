using System;
using My_Assets.Scrips.Utyles_Module;
using UnityEngine;

namespace My_Assets.Scrips.Game_module
{
    public class InventoryManager : MonoSingleton<InventoryManager>
    {
        [SerializeField] private InventoryData gameData;
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

        public bool NewHighScore(int score)
        {
            return score > gameData.GetHighScore();
        }
    }
}