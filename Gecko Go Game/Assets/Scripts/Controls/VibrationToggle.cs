using UnityEngine;

public class VibrationToggle : ToggleButtons
{
    private const string vibrationKey = "Vibration";

    private void Start()
    {
        bool saved = GetBool(vibrationKey);
        ToggleButton(saved);
    }

    public void ToggleVibration()
    {
        bool newState = !GetBool(vibrationKey);
        SetBool(vibrationKey, newState);

        ToggleButton(newState);
    }
}
