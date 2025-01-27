using UnityEngine;
using System.Collections.Generic;

public class BuildingManager : MonoBehaviour
{
    public List<Building> buildings = new List<Building>();

    public void Initialize(Building[] buildingArray)
    {
        // Очистка текущего списка зданий
        buildings.Clear();

        // Добавление зданий из массива
        foreach (Building building in buildingArray)
        {
            if (building != null)
            {
                buildings.Add(building);
            }
        }

        Debug.Log($"Инициализировано {buildings.Count} зданий.");
    }

    public void AddBuilding(Building building)
    {
        if (building != null && !buildings.Contains(building))
        {
            buildings.Add(building);
            Debug.Log($"Здание {building.name} добавлено.");
        }
    }

    public void RemoveBuilding(Building building)
    {
        if (building != null && buildings.Contains(building))
        {
            buildings.Remove(building);
            Debug.Log($"Здание {building.name} удалено.");
        }
    }
}