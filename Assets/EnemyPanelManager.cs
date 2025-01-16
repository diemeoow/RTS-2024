using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPanelManager : MonoBehaviour
{
    public TMP_Dropdown enemyCountDropdown; // ������ �� Dropdown
    public GameObject enemyPanelPrefab; // ������ ������ ��� ����������
    public Transform enemyPanelContainer; // ��������� ��� ���������� �������

    private void Start()
    {
        // ���������, ��� Dropdown � ������ ����������������
        if (enemyCountDropdown == null || enemyPanelPrefab == null || enemyPanelContainer == null)
        {
            Debug.LogError("Dropdown, Enemy Panel Prefab, or Container not assigned!");
            return;
        }

        // ������������� ��������� ��������� �������
        UpdateEnemyPanels();

        // ������������� �� ������� ��������� �������� � Dropdown
        enemyCountDropdown.onValueChanged.AddListener(delegate { UpdateEnemyPanels(); });
    }

    private void UpdateEnemyPanels()
    {
        // �������� ���������� ����������� �� Dropdown
        int enemyCount = enemyCountDropdown.value;

        // ������� ����� ������ � ����������� �� ���������� ����������
        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemyPanelPrefab, enemyPanelContainer);
        }
    }
}
