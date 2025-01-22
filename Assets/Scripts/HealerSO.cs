
using UnityEngine;

[CreateAssetMenu(fileName = "Healer", menuName = "Data/Healer")]
public class HealerSO : UnitDataSO
{
    public int healingPower;         // ���� �������
    public float minHealingRange;    // ���. ��������� �������
    public float maxHealingRange;    // ����. ��������� �������
    public float healingDelay;       // �������� ����� ��������
}