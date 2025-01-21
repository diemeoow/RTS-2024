using UnityEngine;
using System.IO;
using System.Collections.Generic;
using static UnitDataSO;

[CreateAssetMenu(fileName = "UnitList", menuName = "Data/Unit List")]
public class UnitListSO : ScriptableObject
{
    public UnitDataSO[] units;


	public void SaveFromScriptableObject(UnitListSO unitListSO)
	{
		UnitList unitList = new UnitList
		{
			units = new UnitData[unitListSO.units.Length]
		};

		for (int i = 0; i < unitListSO.units.Length; i++)
		{
			unitList.units[i] = new UnitData
			{
				unitName = unitListSO.units[i].unitName,
				speed = unitListSO.units[i].speed,
				health = unitListSO.units[i].health,
				attackPower = unitListSO.units[i].attackPower,
				trainingCost = unitListSO.units[i].trainingCost,
				detectionRadius = unitListSO.units[i].detectionRadius
			};
		}

		SaveToJson(unitList);
	}

	[System.Serializable]
	public class UnitList
	{
		public UnitData[] units; // массив данных юнитов для сериализации
	}
}
