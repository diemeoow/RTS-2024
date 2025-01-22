
using UnityEngine;

[CreateAssetMenu(fileName = "Healer", menuName = "Data/Healer")]
public class HealerSO : UnitDataSO
{
    public int healingPower;         // Сила лечения
    public float minHealingRange;    // Мин. дистанция лечения
    public float maxHealingRange;    // Макс. дистанция лечения
    public float healingDelay;       // Задержка между лечением
}