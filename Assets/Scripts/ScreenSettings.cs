using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSettings : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    private Resolution[] resolutions;

    void Start()
    {
        // Получаем список разрешений
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        int[] targetWidths = { 1280, 1366, 1600, 1920 };
        int[] targetHeights = { 720, 768, 900, 1080 };

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            for (int j = 0; j < targetWidths.Length; j++)
            {
                if (resolutions[i].width == targetWidths[j] && resolutions[i].height == targetHeights[j])
                {

                    string option = resolutions[i].width + " x " + resolutions[i].height;
                    resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(option));


                    if (resolutions[i].width == Screen.currentResolution.width &&
                        resolutions[i].height == Screen.currentResolution.height)
                    {
                        currentResolutionIndex = resolutionDropdown.options.Count - 1;
                    }
                    break;
                }
            }
        }

        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        fullscreenToggle.isOn = Screen.fullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
