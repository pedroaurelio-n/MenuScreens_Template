using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace PedroAurelio.SOEventSystem
{
    public class AudioManager : MonoBehaviour
    {
        private AudioSource _audioSource;

        private Coroutine _disableCoroutine;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.enabled = false;
        }

        private void PlayAudio(AudioClipSO clipSO, Vector3 position, float delay)
        {
            if (_disableCoroutine != null)
                StopCoroutine(_disableCoroutine);

            _audioSource.enabled = true;
            _audioSource.clip = clipSO.Clip;
            _audioSource.outputAudioMixerGroup = clipSO.MixerGroup;
            transform.position = position;

            if (delay == 0f)
            {
                _audioSource.Play();
                _disableCoroutine = StartCoroutine(WaitForClipCoroutine(clipSO.Clip.length));
            }
            else
            {
                _audioSource.PlayDelayed(delay);
                _disableCoroutine = StartCoroutine(WaitForClipCoroutine(clipSO.Clip.length, delay));
            }
        }

        private IEnumerator WaitForClipCoroutine(float duration, float delay = 0f)
        {
            if (delay != 0f)
                yield return new WaitForSeconds(delay);

            yield return new WaitForSeconds(duration);
            _audioSource.enabled = false;
        }

        private void OnEnable()
        {
            AudioEventListener.onPlayAudio += PlayAudio;
        }

        private void OnDisable()
        {
            AudioEventListener.onPlayAudio -= PlayAudio;
        }
    }
}