using UnityEngine;
using System.IO;

public class JSONLoader : MonoBehaviour
{
    public UnitData unitData;               // ScriptableObject для юнитов
    public BuildingData buildingData;       // ScriptableObject для зданий
    public GameSettings gameSettings;       // ScriptableObject для настроек
    public GameSessionConfig gameSessionConfig; // ScriptableObject для игровой сессии

    private const string FilePath = "/Resources/gameData.json";

    public void Start()
    {
        LoadOrCreateJsonFile();
    }

    public void LoadOrCreateJsonFile()
    {
        string filePath = Application.dataPath + FilePath;

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            GameDataContainer container = JsonUtility.FromJson<GameDataContainer>(json);

            // Загружаем данные из контейнера
            unitData.units = container.units;
            buildingData.buildings = container.buildings;
            gameSettings.settings = container.settings;
            gameSessionConfig.gameSession = container.gameSession;
        }
        else
        {
            // Создаем контейнер с начальными данными
            GameDataContainer container = new GameDataContainer
            {
                units = unitData.units,
                buildings = buildingData.buildings,
                settings = gameSettings.settings,
                gameSession = gameSessionConfig.gameSession
            };

            // Сохраняем контейнер в JSON
            string json = JsonUtility.ToJson(container, true);
            File.WriteAllText(filePath, json);
        }
    }
}
[System.Serializable]
public class GameDataContainer
{
    public Unit[] units;                 // Юниты
    public Building[] buildings;         // Здания
    public Settings settings;            // Настройки игры
    public GameSession gameSession;      // Конфигурация игровой сессии
}