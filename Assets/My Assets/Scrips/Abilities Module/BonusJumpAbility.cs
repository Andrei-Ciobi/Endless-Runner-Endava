using System;
using System.Collections;
using My_Assets.Scrips.Game_module;
using My_Assets.Scrips.ObjectPool_Module;
using My_Assets.Scrips.Player_Module;
using My_Assets.Scrips.Utyles_Module;
using UnityEngine;

namespace My_Assets.Scrips.Abilities_Module
{
    public class BonusJumpAbility : BaseAbility
    {
        [SerializeField] private float bonusJump;
        [SerializeField] private float duration;

        private static bool running;
        private static bool forceStop;
        private MeshRenderer meshRenderer;

        private void Awake()
        {
            InitializeBaseAbility();
            meshRenderer = GetComponent<MeshRenderer>();
        }

        protected override void PerformAbility()
        {
            if (running)
            {
                forceStop = true;
            }

            StartCoroutine(BonusJumpCoroutine());
        }

        private IEnumerator BonusJumpCoroutine()
        {
            // Start running the new coroutine after the current on is stopped, if we have a current one running
            while (forceStop)
            {
                yield return null;
            }
            
            running = true;
            var currentTime = 0f;
            meshRenderer.enabled = false;
            PlayerManager.Instance.GetController().SetBonusJumpHeight(bonusJump);
            
            while (currentTime <= duration && !GameManager.Instance.IsGameOver && !forceStop)
            {
                currentTime += Time.deltaTime;
                yield return null;
            }

            running = false;
            forceStop = false;
            
            meshRenderer.enabled = true;
            PlayerManager.Instance.GetController().ResetBonusJumpHeight();
            PoolManager.Instance.SendBackToPool(ObjectPoolType.Ability, gameObject);
            GameManager.Instance.SpawnGameObject(ObjectPoolType.Ability);
        }
        
        
    }
}