using UnityEngine;

[CreateAssetMenu(fileName = "CombatUnit", menuName = "Data/Combat Unit")]
public class CombatUnitSO : UnitDataSO
{
    public int attackPower;// Сила атаки
    public float detectionRadius;// Радиус обнаружения
    public float minAttackRange;// Мин. дистанция атаки
    public float maxAttackRange;// Макс. дистанция атаки
    public float attackDelay;// Задержка атаки
}