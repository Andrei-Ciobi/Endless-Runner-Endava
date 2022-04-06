﻿using My_Assets.Scrips.Player_Module;
using My_Assets.Scrips.Utyles_Module;
using UnityEngine;

namespace My_Assets.Scrips.Input_Module
{
    public class GameInputManager : MonoSingleton<GameInputManager>
    {
        private GameInputAction inputAction;

        private void Awake()
        {
            InitializeMonoSingleton();
            inputAction = new GameInputAction();
        }

        private void Start()
        {
            InitializeInputCallbacks();
        }

        private void OnEnable()
        {
            inputAction.Enable();
            inputAction.Player.Enable();
            inputAction.UI.Enable();
        }

        private void OnDisable()
        {
            inputAction.Disable();
            inputAction.Player.Disable();
            inputAction.UI.Disable();
        }

        public void EnablePlayerActionMap()
        {
            inputAction.Player.Enable();
        }

        public void DisablePlayerActionMap()
        {
            inputAction.Player.Disable();
        }


        private void InitializeInputCallbacks()
        {
            if (!PlayerManager.Instance)
            {
                Debug.Log("Here");
            }
            
            Debug.Log("Again " + PlayerManager.Instance.GetController().gameObject.name);
            inputAction.Player.Movement.performed += PlayerManager.Instance.GetController().OnMovementStarted;
            inputAction.Player.Movement.canceled += PlayerManager.Instance.GetController().OnMovementEnded;
        }
        
    }
}