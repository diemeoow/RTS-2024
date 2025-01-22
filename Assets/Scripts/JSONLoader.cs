using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSONLoader : MonoBehaviour
{
    public UnitListSO unitList;

    public void SaveToJson(string filePath)
    {
        if (unitList == null || unitList.units == null || unitList.units.Length == 0)
        {
            Debug.LogError("UnitListSO ������ ��� �� ��������!");
            return;
        }

        // ��������� ������ ������ ������ � JSON
        var serializedUnits = new List<UnitData>();

        foreach (var unit in unitList.units)
        {
            if (unit is CombatUnitSO combatUnit)
            {
                serializedUnits.Add(new CombatUnitData
                {
                   // unitType = "CombatUnit",
                    unitName = combatUnit.unitName,
                    speed = combatUnit.speed,
                    health = combatUnit.health,
                    trainingCost = combatUnit.trainingCost,
                    attackPower = combatUnit.attackPower,
                    detectionRadius = combatUnit.detectionRadius,
                    minAttackRange = combatUnit.minAttackRange,
                    maxAttackRange = combatUnit.maxAttackRange,
                    attackDelay = combatUnit.attackDelay
                });
            }
            else if (unit is HealerSO healer)
            {
                serializedUnits.Add(new HealerData
                {
                   // unitType = "Healer",
                    unitName = healer.unitName,
                    speed = healer.speed,
                    health = healer.health,
                    trainingCost = healer.trainingCost,
                    healingPower = healer.healingPower,
                    minHealingRange = healer.minHealingRange,
                    maxHealingRange = healer.maxHealingRange,
                    healingDelay = healer.healingDelay
                });
            }
            else if (unit is WorkerSO worker)
            {
                serializedUnits.Add(new WorkerData
                {
                   // unitType = "Worker",
                    unitName = worker.unitName,
                    speed = worker.speed,
                    health = worker.health,
                    trainingCost = worker.trainingCost,
                    resourceGatherRate = worker.resourceGatherRate,
                    buildingSpeed = worker.buildingSpeed
                });
            }
            else
            {
                Debug.LogError($"����������� ��� �����: {unit.GetType()}");
            }
        }

        // ����������� ������ � JSON � ���������� � ����
        string json = JsonUtility.ToJson(new UnitList  { units = serializedUnits}, true);
        try
        {
            File.WriteAllText(filePath, json);
            Debug.Log($"������ ������� ��������� � ����: {filePath}");
        }
        catch (IOException e)
        {
            Debug.LogError($"������ ��� ���������� �����: {e.Message}");
        }
    }

    [SerializeField] private string saveFilePath = "Assets/Resources/DataGame.json";

    void Start()
    {
        SaveToJson(saveFilePath);
    }
    //public void Save()
    //{
    //    SaveToJson(saveFilePath);
    //}
}