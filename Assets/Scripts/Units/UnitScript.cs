using TMPro; // Добавьте пространство имен TMPro
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public string Name;
    public Sprite unitIcon;
    public TextMeshProUGUI nameUserText; // Ссылка на объект TextMeshProUGUI

    void Start()
    {
        GameObject nameUserObject = GameObject.Find("NameUser"); // Найти объект по имени
        if (nameUserObject != null)
        {
            nameUserText = nameUserObject.GetComponent<TextMeshProUGUI>();
            if (nameUserText != null)
            {
                nameUserText.text = Name; // Установить текст равным значению переменной Name
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not found on NameUser object.");
            }
        }
        else
        {
            Debug.LogError("NameUser object not found in the scene.");
        }
    }
}
