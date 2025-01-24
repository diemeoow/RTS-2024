using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UnitData unitData;
    public BuildingData buildingData;
    public GameSettings gameSettings;
    public GameSessionConfig gameSessionConfig;

    private void Start()
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
    }
}
