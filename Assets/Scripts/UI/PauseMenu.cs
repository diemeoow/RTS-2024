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
        Time.timeScale = 0f; // Остановка времени в игре
        settingsPanel.SetActive(true); // Показать окно настроек
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Возобновление времени в игре
        settingsPanel.SetActive(false); // Скрыть окно настроек
    }
}
