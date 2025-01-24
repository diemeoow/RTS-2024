using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "ScriptableObjects/BuildingData", order = 2)]
public class BuildingData : ScriptableObject
{
    public Building[] buildings;
}

[System.Serializable]
public class Building
{
    public string name;
    public int durability;
    public ResourceCost constructionCost;
    public string[] trainsUnits;
    public string producesResource;
    public int detectionRadius;
    public int constructionRadius;
    public int archerCapacity;
    public int minAttackRange;
    public int maxAttackRange;
    public float attackDelay;
    public int damage;
    public bool increasesResourceMax;
}
