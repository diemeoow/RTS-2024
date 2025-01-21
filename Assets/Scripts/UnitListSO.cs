using UnityEngine;

[CreateAssetMenu(fileName = "UnitList", menuName = "Data/Unit List")]
public class UnitListSO : ScriptableObject
{
    public UnitDataSO[] units;
}
