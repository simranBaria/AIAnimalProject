using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer instance = null;

    public AudioClip[] soundList;

    AudioSource source;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(SoundEffect sound)
    {
        instance.source.loop = false;
        instance.source.PlayOneShot(instance.soundList[(int)sound]);
    }

    public void PlayLoopingSound(SoundEffect sound)
    {
        instance.source.loop = true;
        instance.source.PlayOneShot(instance.soundList[(int)sound]);
    }

    public void StopSound()
    {
        instance.source.Stop();
    }
}

// Enum for sound effects
// Must be in the same order as the soundList
public enum SoundEffect
{
    Flap,
    Squeak1,
    Squeak2,
    WindBlowing,
    WaterSplash,
    Eating
}
