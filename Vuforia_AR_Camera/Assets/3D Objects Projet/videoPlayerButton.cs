using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;

public class videoPlayerButton : MonoBehaviour, IVirtualButtonEventHandler 
{
    public GameObject vbBtnObj;
    //public Animator cubeAni;
    private VideoPlayer videoPlayer;
    private AudioSource audioSource;

    private bool pause;
    private bool pressed; 
    // Start is called before the first frame update
    void Start()
    {
        pressed = false;
        pause = false; 
        videoPlayer = GetComponent<VideoPlayer>();
        audioSource = GetComponent<AudioSource>();

        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        //cubeAni.GetComponent<Animator>();

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if ( pressed == false)
        {
            audioSource.Pause(); 
            videoPlayer.Play();
            pause = true;
            pressed = true;
        }
        else
        {
            audioSource.Play();
            videoPlayer.Pause();
            pause = false;
            pressed = false; 
        }

        Debug.Log("BTN pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        /*
        if (pause == true)
        {
            videoPlayer.Play();
            pause = false; 
        }
        else
        {
            videoPlayer.Pause();
            Debug.Log("BTN released");
        }
        */
    }
}
