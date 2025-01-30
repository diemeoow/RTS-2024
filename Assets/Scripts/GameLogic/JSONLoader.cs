using UnityEngine;
using System.IO;

public class JSONLoader : MonoBehaviour
{
    public UnitData unitData;               // ScriptableObject ��� ������
    public BuildingData buildingData;       // ScriptableObject ��� ������
    public GameSettings gameSettings;       // ScriptableObject ��� ��������
    public GameSessionConfig gameSessionConfig; // ScriptableObject ��� ������� ������

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

            // ��������� ������ �� ����������
            unitData.units = container.units;
            buildingData.buildings = container.buildings;
            gameSettings.settings = container.settings;
            gameSessionConfig.gameSession = container.gameSession;
        }
        else
        {
            // ������� ��������� � ���������� �������
            GameDataContainer container = new GameDataContainer
            {
                units = unitData.units,
                buildings = buildingData.buildings,
                settings = gameSettings.settings,
                gameSession = gameSessionConfig.gameSession
            };

            // ��������� ��������� � JSON
            string json = JsonUtility.ToJson(container, true);
            File.WriteAllText(filePath, json);
        }
    }
}
[System.Serializable]
public class GameDataContainer
{
    public Unit[] units;                 // �����
    public Building[] buildings;         // ������
    public Settings settings;            // ��������� ����
    public GameSession gameSession;      // ������������ ������� ������
}