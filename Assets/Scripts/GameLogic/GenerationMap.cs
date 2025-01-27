using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class GenerationMap : MonoBehaviour
{
	public GameObject treePrefab;
	public GameObject rockPrefab;
	public GameObject playerBasePrefab;
	public GameObject enemyBasePrefab;
	public GameObject unitPrefab;
	public GameObject plane;
	public float density = 0.005f; // Плотность объектов (0.005 = 1 объект на 200 единиц площади)
	public float perlinScale = 10f; // Масштаб шума Перлина
	public float perlinThreshold = 0.5f; // Порог значения шума для размещения объектов
	public float minDistance = 5f; // Минимальное расстояние между объектами
	public float baseRadius = 10f; // Радиус, в пределах которого нельзя размещать объекты
	public NavMeshSurface navMeshSurface;

	private List<Vector3> placedObjectPositions = new List<Vector3>();
	private int enemyBaseCount;
	private Difficulty currentDifficulty;

	void Start()
	{
		LoadSettings();
		GenerateMap();
	}

	public void LoadSettings()
	{
		GameSessionConfig sessionConfig = Resources.Load<GameSessionConfig>("GameSessionConfig");
		if (sessionConfig != null)
		{
			enemyBaseCount = 1; // Пример настройки НУЖНО ДЕЛАТЬ ЧЕРЕЗ НАСТРОКИ ИГРЫ!!!!!!!!!!!!!!!!!!
			currentDifficulty = sessionConfig.gameSession.difficultyModifiers.medium; // Устанавливаем текущую сложность
		}
		else
		{
			Debug.LogError("GameSessionConfig не найден. Проверьте ресурс или путь.");
		}
	}

	public void GenerateMap()
	{
		Vector3 planeSize = plane.GetComponent<Renderer>().bounds.size;
		float planeArea = planeSize.x * planeSize.z;
		int objectCount = Mathf.RoundToInt(planeArea * density);

		// Генерация баз игрока и врагов
		List<Vector3> basePositions = GenerateBasePositions(enemyBaseCount, planeSize);
		foreach (Vector3 basePosition in basePositions)
		{
			placedObjectPositions.Add(basePosition);
		}

		// Размещение баз
		PlaceBases(basePositions);

		// Генерация ресурсов
		int placedObjects = 0;
		while (placedObjects < objectCount)
		{
			float randomX = Random.Range(-planeSize.x / 2, planeSize.x / 2);
			float randomZ = Random.Range(-planeSize.z / 2, planeSize.z / 2);
			Vector3 randomPosition = new Vector3(randomX, 0, randomZ);

			if (IsPositionInReservedArea(randomPosition, basePositions, baseRadius))
			{
				continue;
			}

			float perlinValue = Mathf.PerlinNoise((randomX + planeSize.x / 2) / perlinScale, (randomZ + planeSize.z / 2) / perlinScale);
			if (perlinValue >= perlinThreshold && !IsTooCloseToOtherObjects(randomPosition))
			{
				GameObject prefab = Random.value > 0.5f ? treePrefab : rockPrefab;
				Instantiate(prefab, randomPosition, Quaternion.identity);
				placedObjectPositions.Add(randomPosition);
				placedObjects++;
			}
		}

		// Строим NavMesh
		if (navMeshSurface != null)
		{
			navMeshSurface.BuildNavMesh();
		}
	}

	private List<Vector3> GenerateBasePositions(int enemyCount, Vector3 planeSize)
	{
		List<Vector3> positions = new List<Vector3>();

		// Центр карты для базы игрока
		Vector3 playerBasePosition = Vector3.zero;
		positions.Add(playerBasePosition);

		// Расчёт окружности для баз врагов
		float radius = Mathf.Min(planeSize.x, planeSize.z) / 3;
		float angleStep = 360f / enemyCount;

		for (int i = 0; i < enemyCount; i++)
		{
			float angle = i * angleStep * Mathf.Deg2Rad;
			float x = Mathf.Cos(angle) * radius;
			float z = Mathf.Sin(angle) * radius;
			positions.Add(new Vector3(x, 0, z));
		}

		return positions;
	}

	private void PlaceBases(List<Vector3> basePositions)
	{
		for (int i = 0; i < basePositions.Count; i++)
		{
			GameObject basePrefab = i == 0 ? playerBasePrefab : enemyBasePrefab;
			GameObject baseObject = Instantiate(basePrefab, basePositions[i], Quaternion.identity);

			// Добавляем имя над базой
			string baseName = i == 0 ? "Player Base" : $"Enemy Base {i}";
			CreateBaseLabel(baseObject, baseName);

			// Добавляем юнитов к базе врага в зависимости от сложности
			if (i > 0) // Игрок — первая база
			{
				SpawnEnemyUnits(baseObject.transform.position, currentDifficulty);
			}
		}
	}

	private void SpawnEnemyUnits(Vector3 basePosition, Difficulty difficulty)
	{
		foreach (string unitType in difficulty.enemyUnits)
		{
			int unitCount = difficulty.initialArmyLimit;
			for (int i = 0; i < unitCount; i++)
			{
				Vector3 spawnPosition = basePosition + new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
				Instantiate(unitPrefab, spawnPosition, Quaternion.identity);
			}
		}
	}

	private void CreateBaseLabel(GameObject baseObject, string baseName)
	{
		GameObject label = new GameObject("BaseLabel");
		label.transform.SetParent(baseObject.transform);
		label.transform.localPosition = new Vector3(0, 5, 0);

		TextMesh textMesh = label.AddComponent<TextMesh>();
		textMesh.text = baseName;
		textMesh.fontSize = 18;
		textMesh.color = Color.white;
		textMesh.alignment = TextAlignment.Center;
	}

	private bool IsPositionInReservedArea(Vector3 position, List<Vector3> basePositions, float radius)
	{
		foreach (Vector3 basePosition in basePositions)
		{
			if (Vector3.Distance(position, basePosition) < radius)
			{
				return true;
			}
		}
		return false;
	}

	private bool IsTooCloseToOtherObjects(Vector3 position)
	{
		foreach (Vector3 placedPosition in placedObjectPositions)
		{
			if (Vector3.Distance(position, placedPosition) < minDistance)
			{
				return true;
			}
		}
		return false;
	}
}
