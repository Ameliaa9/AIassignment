using UnityEngine;

public class AIBreathingAudio : MonoBehaviour
{
    public Transform player;
    public AudioSource breathingAudio;

    public float maxBreathingVolume = 1f;
    public float minBreathingVolume = 0.1f;
    public float breathingMaxDistance = 15f;

    private void Update()
    {
        if (player == null || breathingAudio == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        float t = Mathf.Clamp01(distance / breathingMaxDistance);
        float volume = Mathf.Lerp(maxBreathingVolume, minBreathingVolume, t);
        breathingAudio.volume = volume;
    }
}

