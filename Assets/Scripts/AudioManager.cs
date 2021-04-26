using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public enum Track
    {
        one,
        two,
        three,
        four
    }

    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();

    [SerializeField] private List<AudioSource> audioSource = new List<AudioSource>();

    [SerializeField] private AudioSource sfx;

    public AudioClip startingTrack;

    public int numberOfOneShots;

    private int currentTrack;

    private void Start()
    {
        currentTrack = 0;
        audioSource[currentTrack].clip = GetTrack(GameManager.trackKeeper.nextTrack);
        audioSource[currentTrack].Play();
    }

    public void SetNextTrack(Track trackToSet, bool waitForCurrentToEnd)
    {
        AudioClip nextTrack;

        switch(trackToSet)
        {
            case Track.one:
                nextTrack = audioClips[0];
                break;
            case Track.two:
                nextTrack = audioClips[1];
                break;
            case Track.three:
                nextTrack = audioClips[2];
                break;
            case Track.four:
                nextTrack = audioClips[3];
                break;
            default:
                nextTrack = audioClips[0];
                break;
        }

        audioSource[1 - currentTrack].clip = nextTrack;

        if(waitForCurrentToEnd)
        {
            
            double duration = (double)audioSource[currentTrack].clip.samples / audioSource[currentTrack].clip.frequency;

            double remaining = duration - audioSource[currentTrack].time;

            audioSource[1 - currentTrack].PlayScheduled(AudioSettings.dspTime + remaining);

        }
        else
        {
            audioSource[1 - currentTrack].Play();
        }

        currentTrack = 1 - currentTrack;
    }

    private IEnumerator VolumeFade(AudioSource audioSourceToFade, bool fadeIn, float fadeTime)
    {
        float currentTime = 0;

        while(currentTime < fadeTime)
        {
            currentTime += Time.deltaTime;
            if(fadeIn)
            {
                audioSourceToFade.volume = Mathf.Lerp(0, 1, currentTime / fadeTime);
            }
            else
            {
                audioSourceToFade.volume = Mathf.Lerp(1, 0, currentTime / fadeTime);
                if(audioSourceToFade.volume <= 0)
                {
                    audioSourceToFade.Stop();
                }
            }
            yield return null;
        }
        yield break;
    }

    private bool canPlay = true;

    public void PlaySoundEffect(AudioClip clip)
    {
            sfx.PlayOneShot(clip);

    }

    

    private IEnumerator SoundEffectReset()
    {
        canPlay = false;
        yield return new WaitForSeconds(1f);
        canPlay = true;
    }

    public void StopPlaying()
    {
        audioSource[currentTrack].Stop();
    }

    private AudioClip GetTrack(Track trackToSet)
    {
        AudioClip nextTrack;
        switch(trackToSet)
        {
            case Track.one:
                nextTrack = audioClips[0];
                break;
            case Track.two:
                nextTrack = audioClips[1];
                break;
            case Track.three:
                nextTrack = audioClips[2];
                break;
            case Track.four:
                nextTrack = audioClips[3];
                break;
            default:
                nextTrack = audioClips[0];
                break;
        }

        return nextTrack;
    }
}
