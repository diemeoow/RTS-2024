using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int wood;
    public int stone;
    public int metal;
    public int food;

    public void Initialize(ResourceCost initialResources)
    {
        wood = initialResources.wood;
        stone = initialResources.stone;
        metal = initialResources.metal;
        food = initialResources.food;

        Debug.Log("Resources initialized");
    }

    public void InitializeResources()
    {
        wood = 100;
        stone = 50;
        metal = 20;
        food = 150;
    }

    public bool CanAfford(ResourceCost cost)
    {
        return wood >= cost.wood && stone >= cost.stone && metal >= cost.metal && food >= cost.food;
    }

    public void SpendResources(ResourceCost cost)
    {
        if (CanAfford(cost))
        {
            wood -= cost.wood;
            stone -= cost.stone;
            metal -= cost.metal;
            food -= cost.food;
        }
    }

    public void AddResources(int woodAmount, int stoneAmount, int metalAmount, int foodAmount)
    {
        wood += woodAmount;
        stone += stoneAmount;
        metal += metalAmount;
        food += foodAmount;
    }
}
