using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 3)]
public class GameSettings : ScriptableObject
{
    public Settings settings;
}

[System.Serializable]
public class Settings
{
    public string resolution;
    public string windowMode;
    public bool sound;
    public float musicVolume;
}
