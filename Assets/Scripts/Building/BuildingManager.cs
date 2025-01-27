using UnityEngine;
using System.Collections.Generic;

public class BuildingManager : MonoBehaviour
{
    public List<Building> buildings = new List<Building>();

    public void Initialize(Building[] buildingArray)
    {
        // ������� �������� ������ ������
        buildings.Clear();

        // ���������� ������ �� �������
        foreach (Building building in buildingArray)
        {
            if (building != null)
            {
                buildings.Add(building);
            }
        }

        Debug.Log($"���������������� {buildings.Count} ������.");
    }

    public void AddBuilding(Building building)
    {
        if (building != null && !buildings.Contains(building))
        {
            buildings.Add(building);
            Debug.Log($"������ {building.name} ���������.");
        }
    }

    public void RemoveBuilding(Building building)
    {
        if (building != null && buildings.Contains(building))
        {
            buildings.Remove(building);
            Debug.Log($"������ {building.name} �������.");
        }
    }
}