using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "ScriptableObjects/UnitData", order = 1)]
public class UnitData : ScriptableObject
{
    public Unit[] units;
}

[System.Serializable]
public class Unit
{
    public string name;
    public float speed;
    public int health;
    public ResourceCost trainingCost;
    public int detectionRange;
    public int minAttackRange;
    public int maxAttackRange;
    public float attackDelay;
    public int damage;
    public int resourceGatheringSpeed;
    public int repairSpeed;
    public int repairEfficiency;
    public int minHealRange;
    public int maxHealRange;
    public float healDelay;
    public int healAmount;
    public int capacity;
}

[System.Serializable]
public class ResourceCost
{
    public int wood;
    public int stone;
    public int metal;
    public int food;
}
