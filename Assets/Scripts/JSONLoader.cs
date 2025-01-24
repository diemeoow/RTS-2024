using UnityEngine;
using System.IO;

public class JSONLoader : MonoBehaviour
{
    public UnitData unitData;
    public BuildingData buildingData;
    public GameSettings gameSettings;
    public GameSessionConfig gameSessionConfig;

    public void Start()
    {
        LoadOrCreateJsonFiles();
    }

    public void LoadOrCreateJsonFiles()
    {
        LoadOrCreateUnits();
        LoadOrCreateBuildings();
        LoadOrCreateSettings();
        LoadOrCreateGameSession();
    }

    public void LoadOrCreateUnits()
    {
        string filePath = Application.dataPath + "/Resources/units.json";
        if (File.Exists(filePath))
        {
            string unitsJson = File.ReadAllText(filePath);
            unitData.units = JsonHelper.FromJson<Unit>(unitsJson);
        }
        else
        {
            string unitsJson = JsonUtility.ToJson(new JsonHelper.Wrapper<Unit> { Items = unitData.units }, true);
            File.WriteAllText(filePath, unitsJson);
        }
    }

    public void LoadOrCreateBuildings()
    {
        string filePath = Application.dataPath + "/Resources/buildings.json";
        if (File.Exists(filePath))
        {
            string buildingsJson = File.ReadAllText(filePath);
            buildingData.buildings = JsonHelper.FromJson<Building>(buildingsJson);
        }
        else
        {
            string buildingsJson = JsonUtility.ToJson(new JsonHelper.Wrapper<Building> { Items = buildingData.buildings }, true);
            File.WriteAllText(filePath, buildingsJson);
        }
    }

    public void LoadOrCreateSettings()
    {
        string filePath = Application.dataPath + "/Resources/settings.json";
        if (File.Exists(filePath))
        {
            string settingsJson = File.ReadAllText(filePath);
            gameSettings.settings = JsonUtility.FromJson<Settings>(settingsJson);
        }
        else
        {
            string settingsJson = JsonUtility.ToJson(gameSettings.settings, true);
            File.WriteAllText(filePath, settingsJson);
        }
    }

    public void LoadOrCreateGameSession()
    {
        string filePath = Application.dataPath + "/Resources/gameSession.json";
        if (File.Exists(filePath))
        {
            string gameSessionJson = File.ReadAllText(filePath);
            gameSessionConfig.gameSession = JsonUtility.FromJson<GameSession>(gameSessionJson);
        }
        else
        {
            string gameSessionJson = JsonUtility.ToJson(gameSessionConfig.gameSession, true);
            File.WriteAllText(filePath, gameSessionJson);
        }
    }
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    [System.Serializable]
    public class Wrapper<T>
    {
        public T[] Items;
    }
}
