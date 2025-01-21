using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "Data/Unit")]
public class UnitDataSO : ScriptableObject
{
	public string unitName;         // Имя юнита
	public float speed;             // Скорость
	public int health;              // Здоровье
	public int attackPower;         // Сила атаки
	public int trainingCost;        // Стоимость тренировки
	public float detectionRadius;   // Радиус обнаружения
	public float minAttackRange;    // Минимальная дистанция атаки
	public float maxAttackRange;    // Максимальная дистанция атаки
	public float attackDelay;

	[System.Serializable]
	public class UnitData//я чета ваще не вкуриваю, почему для упрощения импорта/экспорта только эти атрибуты
	{
		public string unitName;         // Имя юнита
		public float speed;             // Скорость
		public int health;              // Здоровье
		public int attackPower;         // Сила атаки
		public int trainingCost;        // Стоимость тренировки
		public float detectionRadius;   // Радиус обнаружения
		public float minAttackRange;    // Минимальная дистанция атаки
		public float maxAttackRange;    // Максимальная дистанция атаки
		public float attackDelay;
	}
}
