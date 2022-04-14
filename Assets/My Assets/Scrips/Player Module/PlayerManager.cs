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

        public void OnStartGame()
        {
            var animator = controller.GetAnimator();
            animator.SetBool(PlayerState.IsRunning.ToString(), true);
        }

        public void OnEndGame()
        {
            var animator = controller.GetAnimator();
            animator.SetTrigger(PlayerState.Dead.ToString());
        }

        public PlayerController GetController()
        {
            return controller;
        }
    }
}