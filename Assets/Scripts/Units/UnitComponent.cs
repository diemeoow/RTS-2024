using UnityEngine;

public class UnitComponent : MonoBehaviour
{
    public Unit unitData;

    private Vector3 targetPosition;
    private bool isMoving;
    private float stoppingDistance = 0.1f; // ���������� ��� ���������

    public void Initialize(Unit data)
    {
        unitData = data;
        targetPosition = transform.position; // ��������� ������� ��������� � �������
        isMoving = false;

        Debug.Log($"Unit {unitData.name} initialized at position {transform.position}");
    }

    private void Update()
    {
        if (isMoving)
        {
            MoveTowardsTarget();
        }
    }

    public void SetTargetPosition(Vector3 position)
    {
        targetPosition = position;
        isMoving = true;

        Debug.Log($"{unitData.name} moving to {targetPosition}");
    }

    private void MoveTowardsTarget()
    {
        float step = unitData.speed * Time.deltaTime; // �������� ������� �� ������ �����
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // �������� �� ���������� ����
        if (Vector3.Distance(transform.position, targetPosition) <= stoppingDistance)
        {
            isMoving = false;
            Debug.Log($"{unitData.name} reached target position: {targetPosition}");
        }
    }
}