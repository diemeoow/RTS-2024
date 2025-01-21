using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONLoader : MonoBehaviour
{
    public UnitListSO unitList;
    void Start()
    {
        string jsonFilePath = "Assets/Resources/DataGame.json";
        string json = System.IO.File.ReadAllText(jsonFilePath);

        // Преобразуем JSON в ScriptableObject
        UnitListSO loadedData = JsonUtility.FromJson<UnitListSO>(json);
    }
}
