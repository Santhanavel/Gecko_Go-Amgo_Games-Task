using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : ToggleButtons
{
    public List<AudioSource> audioSources;
    public const string muted = "Muted";

    private void Start()
    {
        bool savedMute = GetBool(muted);
        ApplyMute(savedMute);
    }

    public void ToggleMute()
    {
        bool currentState = GetBool(muted);
        bool newState = !currentState;

        SetBool(muted, newState);
        ApplyMute(newState);
    }

    private void ApplyMute(bool state)
    {
        foreach (AudioSource src in audioSources)
            src.mute = state;

        ToggleButton(state);
    }
}