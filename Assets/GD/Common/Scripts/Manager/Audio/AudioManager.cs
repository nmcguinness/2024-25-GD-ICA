using UnityEngine;
using UnityEngine.Audio;
using GD.Pool;
using GD.Types;
using Sirenix.OdinInspector;
using System.Collections;

namespace GD.Audio
{
    /// <summary>
    /// AudioManager is a Singleton class that manages the audio in the game.
    /// </summary>
    public class AudioManager : Singleton<AudioManager>
    {
        [Title("AudioSource & Pool")]
        [SerializeField]
        [Tooltip("The prefab used to instantiate AudioSources.")]
        private AudioSource audioSourcePrefab;

        [SerializeField]
        [Tooltip("The initial size of the AudioSource pool.")]
        [Range(1, 32)]
        private int initialPoolSize = 8;

        [Title("Audio Mixer")]
        [SerializeField]
        [Tooltip("The AudioMixer used to control the audio groups.")]
        private AudioMixer audioMixer;

        [Title("Audio Mixer Groups")]
        [SerializeField]
        private AudioMixerGroup masterGroup;

        [SerializeField]
        private AudioMixerGroup ambientGroup;

        [SerializeField]
        private AudioMixerGroup backgroundGroup;

        [SerializeField]
        private AudioMixerGroup sfxGroup;

        [SerializeField]
        private AudioMixerGroup uiGroup;

        [SerializeField]
        private AudioMixerGroup voiceoverGroup;

        [SerializeField]
        private AudioMixerGroup weaponGroup;

        private ObjectPool<AudioSource> audioSourcePool;

        protected override void Awake()
        {
            base.Awake();

            // Initialize the AudioSource pool
            audioSourcePool = new ObjectPool<AudioSource>(audioSourcePrefab,
                initialPoolSize);
        }

        /// <summary>
        /// Gets the AudioMixerGroup associated with the given AudioMixerGroupName.
        /// </summary>
        /// <param name="groupName">The AudioMixerGroupName enum value.</param>
        /// <returns>The corresponding AudioMixerGroup.</returns>
        public AudioMixerGroup GetAudioMixerGroup(AudioMixerGroupName groupName)
        {
            // Expression based switch from C# 8.0
            // https://www.c-sharpcorner.com/article/c-sharp-8-0-new-feature-swtich-expression/
            return groupName switch
            {
                AudioMixerGroupName.Master => masterGroup,
                AudioMixerGroupName.Ambient => ambientGroup,
                AudioMixerGroupName.Background => backgroundGroup,
                AudioMixerGroupName.SFX => sfxGroup,
                AudioMixerGroupName.UI => uiGroup,
                AudioMixerGroupName.Weapon => weaponGroup,
                AudioMixerGroupName.Voiceover => voiceoverGroup,
                _ => null,
            };
        }

        public void PlaySound(AudioClip clip, AudioMixerGroupName groupName, Vector3 position = default)
        {
            AudioSource audioSource = audioSourcePool.Get();
            audioSource.transform.position = position;
            audioSource.clip = clip;
            audioSource.outputAudioMixerGroup = GetAudioMixerGroup(groupName);
            audioSource.Play();

            StartCoroutine(ReturnAudioSourceAfterPlaying(audioSource));
        }

        private IEnumerator ReturnAudioSourceAfterPlaying(AudioSource audioSource)
        {
            yield return new WaitForSeconds(audioSource.clip.length);
            audioSourcePool.ReturnToPool(audioSource);
        }
    }
}