using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private List<AudioClip> _clips;

        public void Play()
        {
            _source.clip = PickRandomClip();
            _source.Play();
        }

        private AudioClip PickRandomClip() => _clips[Random.Range(0, _clips.Count)];
    }
}