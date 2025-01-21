using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "Data/Unit")]
public class UnitDataSO : ScriptableObject
{
	public string unitName;         // ��� �����
	public float speed;             // ��������
	public int health;              // ��������
	public int attackPower;         // ���� �����
	public int trainingCost;        // ��������� ����������
	public float detectionRadius;   // ������ �����������
	public float minAttackRange;    // ����������� ��������� �����
	public float maxAttackRange;    // ������������ ��������� �����
	public float attackDelay;

	[System.Serializable]
	public class UnitData//� ���� ���� �� ��������, ������ ��� ��������� �������/�������� ������ ��� ��������
	{
		public string unitName;         // ��� �����
		public float speed;             // ��������
		public int health;              // ��������
		public int attackPower;         // ���� �����
		public int trainingCost;        // ��������� ����������
		public float detectionRadius;   // ������ �����������
		public float minAttackRange;    // ����������� ��������� �����
		public float maxAttackRange;    // ������������ ��������� �����
		public float attackDelay;
	}
}
