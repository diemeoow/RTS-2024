using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "Data/Unit")]
public class UnitDataSO : ScriptableObject
{
    public string unitName;
    public float speed;
    public int health;
    public int attackPower;
    public int trainingCost;
    public float detectionRadius;

}
