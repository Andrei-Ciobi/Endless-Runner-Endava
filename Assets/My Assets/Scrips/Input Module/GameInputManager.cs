using System;
using My_Assets.Scrips.Utyles_Module;

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
            inputAction.Player.Enable();
            inputAction.UI.Enable();
        }

        private void OnDisable()
        {
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
            
        }
        
    }
}