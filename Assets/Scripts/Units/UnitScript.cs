using TMPro; // �������� ������������ ���� TMPro
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public string Name;
    public Sprite unitIcon;
    public TextMeshProUGUI nameUserText; // ������ �� ������ TextMeshProUGUI

    void Start()
    {
        GameObject nameUserObject = GameObject.Find("NameUser"); // ����� ������ �� �����
        if (nameUserObject != null)
        {
            nameUserText = nameUserObject.GetComponent<TextMeshProUGUI>();
            if (nameUserText != null)
            {
                nameUserText.text = Name; // ���������� ����� ������ �������� ���������� Name
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
