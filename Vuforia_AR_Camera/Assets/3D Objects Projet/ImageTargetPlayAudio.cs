using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;


public class ImageTargetPlayAudio : MonoBehaviour,
                                            ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    private new AudioSource audio;
    private VideoPlayer videoPlayer;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        videoPlayer = GetComponent<VideoPlayer>();

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // Play audio when target is found
            audio.Play();
        }
        else
        {
            // Stop audio when target is lost
            audio.Stop();
            videoPlayer.Stop(); 
        }
    }
}
