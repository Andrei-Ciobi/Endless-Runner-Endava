using UnityEngine;

namespace My_Assets.Scrips.Utyles_Module
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        public static T Instance;
        private static T instance;

        protected void InitializeMonoSingleton()
        {
            if (!instance)
            {
                instance = this as T;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
