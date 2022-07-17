using UnityEngine;

namespace Core
{
    public class TemporaryObject : MonoBehaviour
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private SoundPlayer _soundPlayer;

        private void OnEnable()
        {
            _soundPlayer.Play();
            StartCoroutine(Timer.Start(_lifeTime, () => gameObject.SetActive(false)));
        }
    }
}