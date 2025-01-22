using UnityEngine;

[CreateAssetMenu(fileName = "CombatUnit", menuName = "Data/Combat Unit")]
public class CombatUnitSO : UnitDataSO
{
    public int attackPower;// ���� �����
    public float detectionRadius;// ������ �����������
    public float minAttackRange;// ���. ��������� �����
    public float maxAttackRange;// ����. ��������� �����
    public float attackDelay;// �������� �����
}