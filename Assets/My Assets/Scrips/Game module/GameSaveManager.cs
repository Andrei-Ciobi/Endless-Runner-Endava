using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using My_Assets.Scrips.Utyles_Module;
using UnityEngine;

namespace My_Assets.Scrips.Game_module
{
    public class GameSaveManager : MonoSingleton<GameSaveManager>
    {
        [SerializeField] private GameInventoryData gameData;
        private float currentRunScore;
        private int currentRunCoins;

        private void Awake()
        {
            InitializeMonoSingleton();
        }

        private void Start()
        {
            LoadGameData();
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
                currentRunScore = Mathf.Round(currentRunScore * 100f) / 100f;
                gameData.SetHighScore(currentRunScore);
            }
            
            gameData.UpdateCurrentCoins(currentRunCoins);
            
            SaveGameData();
        }
        
        public bool NewHighScore()
        {
            return currentRunScore >= gameData.GetHighScore();
        }

        public float GetCurrentRunScore()
        {
            return currentRunScore;
        }

        public int GetCurrentRunCoins()
        {
            return currentRunCoins;
        }


        private bool IsSaveFile(string path)
        {
            return Directory.Exists(Application.persistentDataPath + path);
        }

        private void SaveGameData()
        {
            if (!IsSaveFile("game_save"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/game_save");
            }

            var binaryFormatter = new BinaryFormatter();
            var file = File.Create(Application.persistentDataPath + "/game_save/game_data.txt");

            var json = JsonUtility.ToJson(gameData);
            binaryFormatter.Serialize(file, json);
            file.Close();
        }

        private void LoadGameData()
        {
            if(!IsSaveFile("/game_save"))
                return;
            
            if(!File.Exists(Application.persistentDataPath + "/game_save/game_data.txt"))
                return;

            var binaryFormatter = new BinaryFormatter();
            var file = File.Open(Application.persistentDataPath + "/game_save/game_data.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string) binaryFormatter.Deserialize(file), gameData);
            file.Close();
        }
        
        
    }
}