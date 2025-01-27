using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverScreen;

    public void Initialize()
    {
        gameOverScreen.SetActive(false);
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }
}
