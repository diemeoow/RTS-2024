using UnityEngine;
using System.Collections.Generic;

public class UnitManager : MonoBehaviour
{
    public List<UnitComponent> playerUnits;
    public List<UnitComponent> enemyUnits;

    public void Initialize(Unit[] unitsData)
    {
        playerUnits = new List<UnitComponent>();
        enemyUnits = new List<UnitComponent>();

        // ������������� ������
        foreach (var unitData in unitsData)
        {
            SpawnPlayerUnit(unitData, Vector3.zero); // ������, ��� ��� ����� ���������� � ����� �����
        }
    }

    public void SpawnPlayerUnit(Unit unitData, Vector3 position)
    {
        GameObject unitObject = new GameObject(unitData.name);
        unitObject.transform.position = position;

        UnitComponent unitComponent = unitObject.AddComponent<UnitComponent>();
        unitComponent.Initialize(unitData);

        playerUnits.Add(unitComponent);
    }



    public void MoveUnit(UnitComponent unit, Vector3 targetPosition)
    {
        unit.SetTargetPosition(targetPosition);
    }
}
