using UnityEngine;

namespace Utility
{
    public class AudioController : MonoBehaviour
    {
        private AudioSource _audioSource;
        private AudioSource _audioSfx;
        public static AudioController Instance { get; private set; }
        [Header("MUSIC")]
        public AudioClip sadMusic;
        public AudioClip chillMusic;
        public AudioClip mainMenuMusic;

        [Header("AMBIENCE")]
        public AudioClip noiseSound;
        
        [Header("SFX")]
        public AudioClip buttonHover;
        public AudioClip playClick;
        public AudioClip exitClick;
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        void Start()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSfx = gameObject.AddComponent<AudioSource>();
            _audioSource.loop = true;
        }

        public void PlaySadMusic()
        {
            print("Playing SAD MUSIC");
            _audioSource.clip = sadMusic;
            _audioSource.Play();
        }

        public void PlayChillMusic()
        {
            _audioSource.clip = chillMusic;
            _audioSource.Play();
        }

        public void PlayMainMenuMusic()
        {
            _audioSource.clip = mainMenuMusic;
            _audioSource.Play();
        }

        public void StopMusic()
        {
            _audioSource.Stop();
        }

        public void PlayButton()
        {
            _audioSfx.clip = playClick;
            _audioSfx.Play();
        }

        public void HoverButton()
        {
            _audioSfx.clip = buttonHover;
            _audioSfx.Play();
        }

        public void ExitButton()
        {
            _audioSfx.clip = exitClick;
            _audioSource.Play();
        }
    }
}
