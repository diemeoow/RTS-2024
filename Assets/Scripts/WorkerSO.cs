
using UnityEngine;

[CreateAssetMenu(fileName = "Worker", menuName = "Data/Worker")]
public class WorkerSO : UnitDataSO
{
    public float resourceGatherRate; // Скорость добычи ресурсов
    public float buildingSpeed;      // Скорость строительства
}