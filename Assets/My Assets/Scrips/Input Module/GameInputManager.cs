using My_Assets.Scrips.Game_module;
using My_Assets.Scrips.Player_Module;
using My_Assets.Scrips.UI_Module;
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
            inputAction.Player.Movement.performed += PlayerManager.Instance.GetController().Movement;
            inputAction.Player.Jump.performed += PlayerManager.Instance.GetController().Jump;
            inputAction.UI.LeftClick.performed += _ => GameManager.Instance.StartGame();
            inputAction.UI.MenuButton.performed += _ => UIManager.Instance.SwitchPauseGame();
        }
        
    }
}