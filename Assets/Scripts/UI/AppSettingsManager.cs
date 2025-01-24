using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.IO;

public class AppSettingsManager : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    public Toggle soundToggle;
    public Slider musicVolumeSlider;
    public Button saveButton;
    public Button exitButton;

    private Resolution[] resolutions;
    private Settings settings;

    private void Start()
    {
        LoadSettings();

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(new TMP_Dropdown.OptionData(option));

            if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        fullscreenToggle.isOn = Screen.fullScreen;
        soundToggle.isOn = AudioListener.volume > 0;
        musicVolumeSlider.value = AudioListener.volume;

        saveButton.onClick.AddListener(OnSaveButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void OnSaveButtonClicked()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, fullscreenToggle.isOn);
        AudioListener.volume = musicVolumeSlider.value;
        AudioListener.pause = !soundToggle.isOn;

        settings.resolution = resolutions[resolutionDropdown.value].width + " x " + resolutions[resolutionDropdown.value].height;
        settings.windowMode = fullscreenToggle.isOn ? "fullscreen" : "windowed";
        settings.sound = soundToggle.isOn;
        settings.musicVolume = musicVolumeSlider.value;

        SaveSettings();

        Debug.Log("Settings saved.");
    }

    private void OnExitButtonClicked()
    {
        // Возвращаемся к главному меню
        gameObject.SetActive(false);
    }

    private void LoadSettings()
    {
        string settingsJson = File.ReadAllText(Application.dataPath + "/Resources/settings.json");
        settings = JsonUtility.FromJson<Settings>(settingsJson);
    }

    private void SaveSettings()
    {
        string settingsJson = JsonUtility.ToJson(settings, true);
        File.WriteAllText(Application.dataPath + "/Resources/settings.json", settingsJson);
    }
}
