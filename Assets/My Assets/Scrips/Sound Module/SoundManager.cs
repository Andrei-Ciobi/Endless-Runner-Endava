using System.Collections.Generic;
using My_Assets.Scrips.Utyles_Module;
using UnityEngine;

namespace My_Assets.Scrips.Sound_Module
{
    public class SoundManager : MonoSingleton<SoundManager>
    {
        [SerializeField] private List<Sound> sounds;

        private void Awake()
        {
            InitializeMonoSingleton();
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            InitializeSounds();
        }

        private void Start()
        {
            Play("MusicTheme");
        }


        public void Play(string soundName)
        {
            var sound = sounds.Find(s => s.GetName() == soundName);
            
            if(sound == null)
                return;
            
            sound.GetSource().Play();
        }

        private void InitializeSounds()
        {
            foreach (var s in sounds)
            {
                s.SetSource(gameObject.AddComponent<AudioSource>());
                
                s.GetSource().clip = s.GetClip();
                s.GetSource().volume = s.GetVolume();
                s.GetSource().pitch = s.GetPitch();
                s.GetSource().loop = s.Loop();
            }
        }
        
        
        
    }
}