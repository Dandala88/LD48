using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackKeeper : MonoBehaviour
{
    
    public AudioManager.Track nextTrack;

    public int current = 1;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    

    public void QueueNextTrack()
    {
        switch(current)
        {
            case 1:
                nextTrack = AudioManager.Track.two;
                break;
            case 2:
                nextTrack = AudioManager.Track.three;
                break;
            case 3:
                nextTrack = AudioManager.Track.four;
                break;
            case 4:
                nextTrack = AudioManager.Track.one;
                break;
        }
        if(current < 4)
        {
            current++;
        }
        else
        {
            current = 1;
        }
    }
}
