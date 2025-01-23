using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class JSONLoader : MonoBehaviour
{
    public UnitListSO unitList;

    public void SaveToJson(string filePath)
    {
        if (unitList == null || unitList.units.Length == 0)
        {
            Debug.LogError("UnitListSO пустой или не назначен!");
            return;
        }

        // Сохраняем список данных юнитов в JSON
        var serializedUnits = new List<UnitData>();

        foreach (var unit in unitList.units)
        {
            if (unit is CombatUnitSO combatUnit)
            {
                serializedUnits.Add(new CombatUnitData
                {
                    unitType = "CombatUnit",
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
                    unitType = "Healer",
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
                    unitType = "Worker",
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
                Debug.LogError($"Неизвестный тип юнита: {unit.GetType()}");
            }
        }

        // Используем Newtonsoft.Json для сериализации
        string json = JsonConvert.SerializeObject(new UnitList { units = serializedUnits }, Newtonsoft.Json.Formatting.Indented);

        try
        {
            File.WriteAllText(filePath, json);
            Debug.Log($"Данные успешно сохранены в файл: {filePath}");
        }
        catch (IOException e)
        {
            Debug.LogError($"Ошибка при сохранении файла: {e.Message}");
        }
    }

    [SerializeField] private string saveFilePath = "Assets/Resources/DataGame.json";

    void Start()
    {
        SaveToJson(saveFilePath);
    }
}