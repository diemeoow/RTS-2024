using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToggleImageSwitcher : MonoBehaviour
{
    public Toggle toggle; // ���������� ��� Toggle ���� � ����������
    public GameObject image1; // ���������� ������ ����������� ���� � ����������
    public GameObject image2; // ���������� ������ ����������� ���� � ����������
    public TextMeshProUGUI textMeshProUGUI;

    void Start()
    {
        // ���������� ��������� ��������� �����������
        UpdateImages(toggle.isOn);

        // ����������� �� ������� ��������� ��������� Toggle
        toggle.onValueChanged.AddListener(OnToggleChanged);
    }
    void OnToggleChanged(bool isOn)
    {
        // �������� ��������� ����������� � ����������� �� ��������� Toggle
        UpdateImages(isOn);
    }

    void UpdateImages(bool isOn)
    {
        if (isOn)
        {
            textMeshProUGUI.text = "ON";
        }
        else 
        {
            textMeshProUGUI.text = "OFF";
        }
        image1.SetActive(isOn);
        image2.SetActive(!isOn);
    }
}
