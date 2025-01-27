using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<UnitComponent> enemyUnits;

    public void Initialize(Unit[] enemyUnitsData)
    {
        enemyUnits = new List<UnitComponent>();

        foreach (var unitData in enemyUnitsData)
        {
            SpawnEnemyUnit(unitData, new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10)));
        }
    }
    public void SpawnEnemyUnit(Unit unitData, Vector3 position)
    {
        GameObject unitObject = new GameObject(unitData.name);
        unitObject.transform.position = position;

        UnitComponent unitComponent = unitObject.AddComponent<UnitComponent>();
        unitComponent.Initialize(unitData);

        enemyUnits.Add(unitComponent);
    }
}