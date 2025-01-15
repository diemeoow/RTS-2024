using TMPro;
using TMPro.EditorUtilities;
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

		// Заполняем Dropdown доступными разрешениями
		int currentResolutionIndex = 0;
		for (int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + " x " + resolutions[i].height;
			resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(option));

			if (resolutions[i].width == Screen.currentResolution.width &&
				resolutions[i].height == Screen.currentResolution.height)
			{
				currentResolutionIndex = i;
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
