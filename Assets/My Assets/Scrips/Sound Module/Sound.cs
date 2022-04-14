using UnityEngine;

namespace My_Assets.Scrips.Sound_Module
{
    [System.Serializable]
    public class Sound
    {
        [SerializeField] private string name;
        [SerializeField] private AudioClip clip;

        [SerializeField] [Range(0f, 1f)] private float volume;
        [SerializeField] [Range(.1f, 3f)] private float pitch;
        [SerializeField] private bool loop;

        private AudioSource source;


        public string GetName()
        {
            return name;
        }

        public AudioClip GetClip()
        {
            return clip;
        }

        public float GetVolume()
        {
            return volume;
        }

        public float GetPitch()
        {
            return pitch;
        }

        public AudioSource GetSource()
        {
            return source;
        }

        public bool Loop()
        {
            return loop;
        }
        
        public void SetName(string newName)
        {
            name = newName;
        }

        public void SetClip(AudioClip newClip)
        {
            clip = newClip;
        }

        public void SetVolume(float newVolume)
        {
            volume = newVolume;
        }

        public void SetPitch(float newPitch)
        {
            pitch = newPitch;
        }

        public void SetSource(AudioSource newSource)
        {
            source = newSource;
        }
    }
}