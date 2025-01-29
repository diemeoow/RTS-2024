using UnityEngine;

public class GameManager : MonoBehaviour
{
	public UnitData unitData;
	public BuildingData buildingData;
	public GameSettings gameSettings;
	public GameSessionConfig gameSessionConfig;
	public static GameManager Instance { get; private set; }

	public GameState gameState;
	public UnitManager unitManager;
	public BuildingManager buildingManager;
	public ResourceManager resourceManager;
	public UIManager uiManager;


	public void Start()
    {
        // Пример использования данных
        foreach (var unit in unitData.units)
        {
            Debug.Log($"Unit: {unit.name}, Health: {unit.health}");
        }

        foreach (var building in buildingData.buildings)
        {
            Debug.Log($"Building: {building.name}, Durability: {building.durability}");
        }

        Debug.Log($"Resolution: {gameSettings.settings.resolution}");
        Debug.Log($"Free Zone Radius: {gameSessionConfig.gameSession.freeZoneRadius}");
		// Инициализация ресурсов через UnitData
		ResourceCost initialResources = unitData.units[0].trainingCost;

		// Инициализация врагов
		Unit[] enemyUnitsData = new Unit[unitData.units.Length];  // Заполнение данных врагов
		for (int i = 0; i < unitData.units.Length; i++)
		{
			enemyUnitsData[i] = unitData.units[i];  // Просто копируем юнитов, можно заменить на реальные данные врагов
		}

		InitializeGame(initialResources, enemyUnitsData);
	}
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

	public Unit[] initialUnits; // Начальные юниты
	public Building[] initialBuildings; // Начальные здания

	public void InitializeGame(ResourceCost initialResources, Unit[] enemyUnitsData)
	{
		// Инициализация игровых данных
		unitManager.Initialize(initialUnits);
		buildingManager.Initialize(initialBuildings);
		resourceManager.Initialize(initialResources);
		uiManager.Initialize();

		// Установка начального состояния игры
		SetGameState(GameState.Playing);
	}

	public void SetGameState(GameState newState)
    {
        gameState = newState;
        switch (newState)
        {
            case GameState.Playing:
                Time.timeScale = 1.0f;
                break;
            case GameState.Paused:
                Time.timeScale = 0.0f;
                break;
            case GameState.GameOver:
                Time.timeScale = 0.0f;
                uiManager.ShowGameOverScreen();
                break;
        }
    }
}
public enum GameState
{
    Playing,
    Paused,
    GameOver
}
