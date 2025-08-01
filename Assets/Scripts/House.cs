using UnityEngine;

[RequireComponent(typeof(Signalization))]
public class House : MonoBehaviour
{
    private Signalization _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<Signalization>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Crook>(out _))
            _audioSource.PlayAlarm();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Crook>(out _))
            _audioSource.StopAlarm();
    }
}
