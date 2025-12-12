using UnityEngine;

public class DarkModeToggle : ToggleButtons
{
    private const string darkKey = "DarkMode";

    [SerializeField] private GameObject darkPanel;
    [SerializeField] private GameObject lightPanel;

    private void Start()
    {
        bool saved = GetBool(darkKey);
        ApplyTheme(saved);
    }

    public void ToggleTheme()
    {
        bool newState = !GetBool(darkKey);
        SetBool(darkKey, newState);
        ApplyTheme(newState);
    }

    private void ApplyTheme(bool isDark)
    {
        darkPanel.SetActive(isDark);
        lightPanel.SetActive(!isDark);

        ToggleButton(isDark);
    }
}
