using System.Collections.Generic;
using UnityEngine;

public class MusicManager : ToggleButtons
{

    public AudioSource audioSource;
    private const string stopBG = "StopBG";

    private void Start()
    {
        bool saved = GetBool(stopBG);
        ApplyMute(saved);
    }

    public void ToggleMute()
    {
        bool newState = !GetBool(stopBG);
        bool isSoundMuted = GetBool(SoundManager.muted);

        SetBool(stopBG, newState);

        // If sound is muted → mute music always.
        if (isSoundMuted)
            ApplyMute(true);
        else
            ApplyMute(newState);
    }

    private void ApplyMute(bool state)
    {
        audioSource.mute = state;
        ToggleButton(state);
    }
}