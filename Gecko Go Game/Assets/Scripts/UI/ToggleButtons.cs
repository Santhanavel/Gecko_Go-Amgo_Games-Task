using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ToggleButtons : MonoBehaviour 
{

    [SerializeField] private Image toggleOnImage;
    [Header("On Off Events")]
    [SerializeField] private UnityEvent toggleOnEvent;
    [SerializeField] private UnityEvent toggleOffEvent;
    

    protected void ToggleButton(bool isToggleOn)
    {
        if(isToggleOn)
        {
            toggleOnEvent.Invoke();
            toggleOnImage.gameObject.SetActive(true);
        }
        else
        {
            toggleOffEvent.Invoke();
            toggleOnImage.gameObject.SetActive(false);

        }
    }


    protected bool GetBool(string key, bool defaultValue = false)
    {
        return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) == 1;
    }

    protected void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
        PlayerPrefs.Save();
    }
}
