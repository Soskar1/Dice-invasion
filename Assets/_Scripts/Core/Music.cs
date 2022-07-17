using System.Collections;
using UnityEngine;

namespace Core
{
    public class Music : MonoBehaviour
    {
        [SerializeField] private AudioSource _hub;
        [SerializeField] private AudioSource _battle;
        [SerializeField] private AudioClip _diceSound;

        public void PlayHubMusic()
        {
            _battle.Stop();
            _hub.Play();
        }

        public void PlayBattleMusic()
        {
            _hub.Stop();
            StartCoroutine(PlayDiceSound());
        }

        private IEnumerator PlayDiceSound()
        {
            _battle.PlayOneShot(_diceSound);

            yield return new WaitForSeconds(_diceSound.length);

            _battle.Play();
        }
    }
}