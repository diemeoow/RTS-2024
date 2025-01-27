using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class EnemyPanelManager : MonoBehaviour
{
	public TMP_Dropdown enemyCountDropdown; // ������ �� Dropdown
	public GameObject enemyPanelPrefab; // ������ ������ ��� ����������
	public Transform enemyPanelContainer; // ��������� ��� ���������� �������

	private List<Vector3> enemyPositions = new List<Vector3>(); // ������� ������

	private void Start()
	{
		if (enemyCountDropdown == null || enemyPanelPrefab == null || enemyPanelContainer == null)
		{
			Debug.LogError("Dropdown, Enemy Panel Prefab, or Container not assigned!");
			return;
		}

		UpdateEnemyPanels();

		enemyCountDropdown.onValueChanged.AddListener(delegate { UpdateEnemyPanels(); });
	}

	private void UpdateEnemyPanels()
	{
		int enemyCount = enemyCountDropdown.value;

		foreach (Transform child in enemyPanelContainer)
		{
			Destroy(child.gameObject); // ������� ������ ������
		}

		enemyPositions.Clear();

		for (int i = 0; i < enemyCount; i++)
		{
			Instantiate(enemyPanelPrefab, enemyPanelContainer);

			// ��������� ������� ��� ������ (������� ������, ���������� ������ ������)
			float angle = i * (360f / enemyCount) * Mathf.Deg2Rad;
			float radius = 10f; // ������ �������
			float x = Mathf.Cos(angle) * radius;
			float z = Mathf.Sin(angle) * radius;

			enemyPositions.Add(new Vector3(x, 0, z));
		}

		SaveEnemyDataToJson(enemyCount, enemyPositions);
	}

	private void SaveEnemyDataToJson(int enemyCount, List<Vector3> positions)
	{
		string filePath = Path.Combine(Application.dataPath, "enemyData.json");

		EnemyDataContainer dataContainer = new EnemyDataContainer
		{
			enemyCount = enemyCount,
			enemyPositions = positions
		};

		string json = JsonUtility.ToJson(dataContainer, true);
		File.WriteAllText(filePath, json);

		Debug.Log($"Enemy data saved to {filePath}");
	}
}


