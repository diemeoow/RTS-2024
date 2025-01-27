using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSessionConfig", menuName = "ScriptableObjects/GameSessionConfig", order = 4)]
public class GameSessionConfig : ScriptableObject
{
    public GameSession gameSession;
}

[System.Serializable]
public class GameSession
{
    public DifficultyModifiers difficultyModifiers;
    public int freeZoneRadius;
    public int resourceSpawnInterval;
    public int resourceAmount;
}

[System.Serializable]
public class DifficultyModifiers
{
    public Difficulty easy;
    public Difficulty medium;
    public Difficulty hard;
}

[System.Serializable]
public class Difficulty
{
    public int enemySpawnInterval;
    public string[] enemyUnits;
    public int initialArmyLimit;
    public int armyIncreasePerAttack;
}

[System.Serializable]
public class EnemyDataContainer
{
	public int enemyCount; // Количество противников
	public List<Vector3> enemyPositions; // Позиции противников
}