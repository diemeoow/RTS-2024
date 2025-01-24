using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class GenerationMap : MonoBehaviour
{
    public GameObject Tree, Rock;
    public GameObject plane;
    private GameObject[] models;
    public float density = 0.005f; // ��������� �������� (��������, 0.01 = 1 ������ �� 100 ������ �������)
    private int objectCount; // ���������� ��������, �������������� �������������
    private Vector2 reservedAreaSize = new Vector2(20, 20); // ������ ����������������� �������
    public float perlinScale = 10f; // ������� ���� �������
    public float perlinThreshold = 0.5f; // ����� �������� ���� ��� ���������� �������
    public float minDistance = 5f; // ����������� ���������� ����� ���������
    public NavMeshSurface navMeshSurface;

    private List<Vector3> placedObjectPositions = new List<Vector3>(); // ������ ������� ����������� ��������

    void Start()
    {
        // �������� ��������� NavMeshSurface
        navMeshSurface = GetComponent<NavMeshSurface>();
        models = new GameObject[] { Tree, Rock };

        // �������� ������� Plane
        Vector3 planeSize = plane.GetComponent<Renderer>().bounds.size;

        // ������������ ���������� �������� �� ������ ���������
        float planeArea = planeSize.x * planeSize.z; // ������� ���������
        objectCount = Mathf.RoundToInt(planeArea * density); // ���������� �������� ��������������� ���������

        // ��������� ������� ������������� �������
        Vector2 reservedMin = new Vector2(-reservedAreaSize.x / 2, -reservedAreaSize.y / 2);
        Vector2 reservedMax = new Vector2(reservedAreaSize.x / 2, reservedAreaSize.y / 2);

        // ��������� �������
        int placedObjects = 0;
        while (placedObjects < objectCount)
        {
            // ���������� ��������� ����������
            float randomX = UnityEngine.Random.Range(-planeSize.x / 2, planeSize.x / 2);
            float randomZ = UnityEngine.Random.Range(-planeSize.z / 2, planeSize.z / 2);

            // ���������, ����� ������ �� ������� � ����������� �������
            if (randomX > reservedMin.x && randomX < reservedMax.x &&
                randomZ > reservedMin.y && randomZ < reservedMax.y)
            {
                continue; // ����������, ���� � ����������������� �������
            }

            // ���������� �������� ���� ������� ��� ���������
            float perlinValue = Mathf.PerlinNoise(
                (randomX + planeSize.x / 2) / perlinScale,
                (randomZ + planeSize.z / 2) / perlinScale);

            // ��������� ����� �������� ����
            if (perlinValue >= perlinThreshold)
            {
                Vector3 randomPosition = new Vector3(randomX, 0, randomZ);

                // ���������, ��� ����� ����� ���������� ������ �� ������ ��������
                bool isTooClose = false;
                foreach (Vector3 placedPosition in placedObjectPositions)
                {
                    if (Vector3.Distance(randomPosition, placedPosition) < minDistance)
                    {
                        isTooClose = true;
                        break;
                    }
                }

                if (isTooClose)
                {
                    continue; // ���������� �������� �������, ���� �� ������� ������ � �������
                }

                // ��������� ������� Plane
                if (Mathf.Abs(randomPosition.x + 10) > planeSize.x / 2 || Mathf.Abs(randomPosition.z - 10) > planeSize.z / 2)
                {
                    continue; // ���������� �������� �������, ���� �� ������� �� ������� Plane
                }

                // ��������� ������ �� ������
                GameObject randomModel = models[UnityEngine.Random.Range(0, models.Length)];
                //if (randomModel == Tree)
                //{
                //    randomPosition.y = 2; // ������������� ������ ��� ��������
                //}

                // ������� ������ �� ��������������� �����������
                Instantiate(randomModel, randomPosition, Quaternion.identity);

                // ��������� ������� � ������ ����������� ��������
                placedObjectPositions.Add(randomPosition);

                placedObjects++;
            }
        }

        // ������ NavMesh
        if (navMeshSurface != null)
        {
            navMeshSurface.BuildNavMesh();
        }
    }
}
