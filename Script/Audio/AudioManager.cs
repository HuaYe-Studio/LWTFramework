using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager :PersistentSingieton<AudioManager>
{
    private const float MinPitch = 0.9f;
    private const float MaxPitch = 1.1f;
    // Start is called before the first frame update
    [SerializeField]private AudioSource sFXPlayer;

    public void PlaySFX(AudioClass audioDada)
    {
        sFXPlayer.clip = audioDada.audioClip;
        sFXPlayer.volume = audioDada.volume;
        sFXPlayer.Play();
    }
    public void PlayDelaySFX(AudioClass audioDada,float wait)
    {
        sFXPlayer.clip = audioDada.audioClip;
        sFXPlayer.volume = audioDada.volume;
        sFXPlayer.PlayDelayed(wait);
    }

    public void PlayRandomSFX(AudioClass audioDada)
    {
        sFXPlayer.pitch = Random.Range(MinPitch, MaxPitch);
        PlaySFX(audioDada);
    }

    public void StopSFX()
    {
        sFXPlayer.Stop();
    }
    public void SetLoopSFX(bool setLoop)
    {
        sFXPlayer.loop = setLoop;
    }
}

