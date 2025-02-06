using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Button pauseButton;
    public GameObject settingsPanel;

    private bool isPaused = false;

    void Start()
    {
        pauseButton.onClick.AddListener(OnPauseButtonClick);
        settingsPanel.SetActive(false);
    }

    void OnPauseButtonClick()
    {
        if (!isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // ��������� ������� � ����
        settingsPanel.SetActive(true); // �������� ���� ��������
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // ������������� ������� � ����
        settingsPanel.SetActive(false); // ������ ���� ��������
    }
}
