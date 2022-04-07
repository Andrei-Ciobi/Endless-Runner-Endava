using System;
using My_Assets.Scrips.Utyles_Module;
using UnityEngine;

namespace My_Assets.Scrips.Player_Module
{
    public class PlayerManager : MonoSingleton<PlayerManager>
    {
        [SerializeField] private PlayerController controller;


        private void Awake()
        {
            InitializeMonoSingleton();
        }

        public PlayerController GetController()
        {
            return controller;
        }
    }
}