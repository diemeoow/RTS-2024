using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class GameSettingsManager : MonoBehaviour
{
    public TMP_InputField[] playerNames;
    public TMP_InputField[] enemyNames; // Добавляем поля для имен врагов
    public TMP_InputField mapSizeInput;
    public Button startButton;
    public Button backButton;
    //public ColorPicker[] colorPickers; // Добавляем поля для выбора цветов

    private GameSession gameSession;

    private void Start()
    {
        LoadGameSession();

        startButton.onClick.AddListener(OnStartButtonClicked);
        backButton.onClick.AddListener(OnBackButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        bool validSettings = true;
        HashSet<string> names = new HashSet<string>();
        HashSet<Color> colors = new HashSet<Color>();

        foreach (var inputField in playerNames)
        {
            if (string.IsNullOrEmpty(inputField.text))
            {
                validSettings = false;
                break;
            }

            if (!names.Add(inputField.text))
            {
                validSettings = false;
                break;
            }
        }

        foreach (var inputField in enemyNames)
        {
            if (string.IsNullOrEmpty(inputField.text))
            {
                validSettings = false;
                break;
            }

            if (!names.Add(inputField.text))
            {
                validSettings = false;
                break;
            }
        }

        //foreach (var colorPicker in colorPickers)
        //{
        //    if (!colors.Add(colorPicker.currentColor))
        //    {
        //        validSettings = false;
        //        break;
        //    }
        //}

        int mapSize = int.Parse(mapSizeInput.text);
        if (mapSize < 2500 || mapSize > 10000)
        {
            validSettings = false;
        }
        else
        {
            int side = Mathf.RoundToInt(Mathf.Sqrt(mapSize));
            mapSize = side * side;
            mapSizeInput.text = mapSize.ToString();
        }

        if (validSettings)
        {
            // Сохраняем настройки игры и начинаем игру
            List<string> allNames = new List<string>();
            allNames.AddRange(playerNames.Select(p => p.text));
            allNames.AddRange(enemyNames.Select(e => e.text));

            gameSession.difficultyModifiers.easy.enemyUnits = allNames.ToArray();
            gameSession.freeZoneRadius = mapSize;

            SaveGameSession();

            // Здесь можно добавить логику для начала игры
            Debug.Log("Game started with valid settings.");
        }
        else
        {
            Debug.LogError("Invalid game settings.");
        }
    }

    private void OnBackButtonClicked()
    {
        // Возвращаемся к главному меню
        gameObject.SetActive(false);
    }

    private void LoadGameSession()
    {
        string gameSessionJson = File.ReadAllText(Application.dataPath + "/Resources/gameSession.json");
        gameSession = JsonUtility.FromJson<GameSession>(gameSessionJson);
    }

    private void SaveGameSession()
    {
        string gameSessionJson = JsonUtility.ToJson(gameSession, true);
        File.WriteAllText(Application.dataPath + "/Resources/gameSession.json", gameSessionJson);
    }
}
