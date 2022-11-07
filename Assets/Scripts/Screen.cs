using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

/* All Commented Segments Signify Foundations For Elements/Functions Awaiting Future Implementation */


/*[RequireComponent(typeof(AudioSource), typeof(CanvasGroup))]      //For future implementation of sound sources 
[DisallowMultipleComponent]*/
public class Screen : MonoBehaviour
{
    private AudioSource AudioSource;
    private RectTransform RectTransform;
    private CanvasGroup CanvasGroup;

    [SerializeField]
    private float AnimationSpeed = 1f;
    public bool ExitOnNewPagePush = false;
    [SerializeField]
    private AudioClip ExitClip;     //Placeholder for specific audio clips that are TBD
    [SerializeField]
    private AudioClip EntryClip;
    /*    [SerializeField]                                  //For future implementation of screen transition animations (TBD)
        private EntryMode EntryMode = EntryMode.SLIDE;*/
    /*    [SerializeField]
        private Direction EntryDirection = Direction.LEFT;*/
    /*    [SerializeField]
        private EntryMode ExitMode = EntryMode.SLIDE;*/
    /*    [SerializeField]
        private Direction ExitDirection = Direction.LEFT;*/

    private Coroutine AnimationCoroutine;
    private Coroutine AudioCoroutine;

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
        CanvasGroup = GetComponent<CanvasGroup>();
        AudioSource = GetComponent<AudioSource>();

        AudioSource.playOnAwake = false;
        AudioSource.loop = false;
        AudioSource.spatialBlend = 0;
        AudioSource.enabled = false;
    }

    /*public void Enter(bool PlayAudio)    
    {
        switch(EntryMode)                   //Use switch() to execute specific sounds for different entry modes
        {
            case EntryMode.SLIDE:           //Example of one kind of "EntryMode" for when pages are entered/switched to
                SlideIn(PlayAudio);
                break;

            // *Add alternate cases here* // Implement when getting to adding game audio :) //
        }
    }*/


    /*public void Exit(bool PlayAudio)     
    {
        switch(EntryMode)                   //Use switch() to execute specific sounds for different entry modes
        {
            case EntryMode.SLIDE:           //Example of one kind of "EntryMode" for when page is exited/switched
                SlideOut(PlayAudio);
                break;

            // *Add alternate cases here* // Implement when getting to adding game audio (Exact same as Enter(), but for exiting) //
        }
    }*/

    /*private void SlideIn(bool PlayAudio)
    {
        if (AnimationCoroutine != null)
        {
            StopCoroutine(AudioCoroutine);
        }
        AnimationCoroutine = StartCoroutine(AnimationHelper.SlideIn(RectTransform, EntryDirection, AnimationSpeed, null));

        AudioCoroutine = StartCoroutine(PlayClip(EntryClip));
    }

    private IEnumerator PlayClip(AudioClip Clip)
    {
        AudioSource.enabled = true;
        
        WaitForSeconds Wait = new WaitForSeconds(Clip.length);

        AudioSource.PlayOneShot(Clip);

        yield return Wait;
        
        AudioSource.enabled = false;
    }*/
}
