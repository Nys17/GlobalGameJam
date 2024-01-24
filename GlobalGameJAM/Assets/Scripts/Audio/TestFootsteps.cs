using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class TestFootsteps : MonoBehaviour
{

    private EventInstance footsteps;

    private void Start()
    {
         footsteps = AudioManager.instance.CreateInstance(FMODEvents.instance.playerFootsteps);
    }

    private void Update()
    {
        UpdateSound();
    }

    private void UpdateSound()
    {
        PLAYBACK_STATE playbackState;
        footsteps.getPlaybackState(out playbackState);
        if (playbackState == PLAYBACK_STATE.STOPPED)
        {
            footsteps.start();
        }
    }
}
