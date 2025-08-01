using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    private AudioSource _audioSource;
    private Coroutine _changingCoroutine;
    private float _volumeInterval = 0.1f;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private float _delay = 1f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;
    }

    public void PlayAlarm()
    {
        _audioSource.Play();
        _changingCoroutine = StartCoroutine(AddVolume());
    }

    public void StopAlarm()
    {
        StopCoroutine(_changingCoroutine);
        _changingCoroutine = StartCoroutine(ReduceVolume());
    }

    private IEnumerator AddVolume()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (_audioSource.volume < _maxVolume)
        {
            _audioSource.volume += _volumeInterval;
            yield return wait;
        }
    }

    private IEnumerator ReduceVolume()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (_audioSource.volume > _minVolume)
        {
            _audioSource.volume -= _volumeInterval;
            yield return wait;
        }

        _audioSource.Stop();
    }
}

