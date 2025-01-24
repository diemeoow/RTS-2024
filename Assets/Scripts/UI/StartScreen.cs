using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public Button playButton;
    public Button settingsButton;
    public Button exitButton;
    public GameObject settingsGamePanel;
    public GameObject settingsWindowPanel;

    private void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);

        // ���������� ������ �������� ������
        settingsGamePanel.SetActive(false);
        settingsWindowPanel.SetActive(false);
    }

    private void OnPlayButtonClicked()
    {
        // ��������� ���� �������� ����
        settingsGamePanel.SetActive(true);
    }

    private void OnSettingsButtonClicked()
    {
        // ��������� ���� ��������
        settingsWindowPanel.SetActive(true);
    }

    private void OnExitButtonClicked()
    {
        // ����� �� ����
        Application.Quit();
    }
}
