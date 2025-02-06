using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

public class AppSettingsManager : MonoBehaviour
{
    public TMP_Dropdown DropdownSize;
    private string configFilePath;
    public Toggle fullscreenToggle;
    public Toggle soundToggle;
    public Slider musicVolumeSlider;
    public Button saveButton;
    public Button exitButton;


    private Settings settings;
    private void Awake()
    {
        // ����� ���� � ����� ��������, ��������, � Application.persistentDataPath
        configFilePath = Path.Combine(Application.persistentDataPath, "D:\\Projects\\RTS 2024\\Assets\\Resources\\gameData.json");
        //configFilePath = Path.Combine(Application.persistentDataPath, "C:\\Users\\B-ZONE\\OneDrive\\������� ����\\RTS_2024\\Assets\\Scrips\\GameScene\\JsonBuilding\\BuilduingAndUnit.json");
    }

    private void Start()
    {
        LoadSettings();
        fullscreenToggle.isOn = Screen.fullScreen;
        soundToggle.isOn = AudioListener.volume > 0;
        musicVolumeSlider.value = AudioListener.volume;

        saveButton.onClick.AddListener(OnSaveButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }
    public void DropSize()
    {
        // ��������� ������� ����� ������
        bool isFullScreen = Screen.fullScreen;
        string newResolution = "1920x1080";

        if (DropdownSize.value == 0)
        {
            Screen.SetResolution(1280, 720, isFullScreen);
            newResolution = "1280x720";
        }
        else if (DropdownSize.value == 1)
        {
            Screen.SetResolution(1366, 768, isFullScreen);
            newResolution = "1366x768";
        }
        else if (DropdownSize.value == 2)
        {
            Screen.SetResolution(1600, 900, isFullScreen);
            newResolution = "1600x900";
        }
        else if (DropdownSize.value == 3)
        {
            Screen.SetResolution(1920, 1080, isFullScreen);
            newResolution = "1920x1080";
        }

        // ����� ����� ���������� ��������� JSON
        UpdateGameSettingsResolution(newResolution);
    }
    private void UpdateGameSettingsResolution(string newResolution)
    {
        if (!File.Exists(configFilePath))
        {
            Debug.LogError("���� GameConfig.json �� ������ �� ����: " + configFilePath);
            return;
        }

        // ������ JSON �� �����
        string json = File.ReadAllText(configFilePath);

        // ������ ������ � JObject
        JObject jObject = JObject.Parse(json);

        // ���� ������ "GameSettings" � ��������� �������� "screenResolution"
        if (jObject["settings"] != null)
        {
            jObject["settings"]["resolution"] = newResolution;
        }
        else
        {
            Debug.LogError("������ 'GameSettings' �� ������� � JSON.");
            return;
        }

        // ����������� ���������� JObject ������� � ������
        string newJson = jObject.ToString();

        // ���������� ���������� JSON � ����
        File.WriteAllText(configFilePath, newJson);
        Debug.Log("��������� ���������� ������ � JSON: " + newResolution);
    }

    private void OnSaveButtonClicked()
    {
     
        AudioListener.volume = musicVolumeSlider.value;
        AudioListener.pause = !soundToggle.isOn;

        settings.windowMode = fullscreenToggle.isOn ? "fullscreen" : "windowed";
        settings.sound = soundToggle.isOn;
        settings.musicVolume = musicVolumeSlider.value;

        SaveSettings();

        Debug.Log("Settings saved.");
    }

    private void OnExitButtonClicked()
    {
        // ������������ � �������� ����
        gameObject.SetActive(false);
    }

    private void LoadSettings()
    {
        string settingsJson = File.ReadAllText(Application.dataPath + "/Resources/gameData.json");
        settings = JsonUtility.FromJson<Settings>(settingsJson);
    }

    private void SaveSettings()
    {
        string settingsJson = JsonUtility.ToJson(settings, true);
        File.WriteAllText(Application.dataPath + "/Resources/gameData.json", settingsJson);
    }
}
