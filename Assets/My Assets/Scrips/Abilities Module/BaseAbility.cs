using UnityEngine;

namespace My_Assets.Scrips.Abilities_Module
{
    public abstract class BaseAbility : MonoBehaviour
    {
        private Collider abilityCollider;
        
        protected void InitializeBaseAbility()
        {
            abilityCollider = GetComponent<Collider>();
            abilityCollider.isTrigger = true;
        }
        protected abstract void PerformAbility();

        private void OnTriggerEnter(Collider other)
        {
            if(!other.CompareTag("Player"))
                return;
            
            PerformAbility();
        }
    }
}