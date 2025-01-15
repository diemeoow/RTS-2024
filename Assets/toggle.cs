using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToggleImageSwitcher : MonoBehaviour
{
    public Toggle toggle; // ѕеретащите ваш Toggle сюда в инспекторе
    public GameObject image1; // ѕеретащите первое изображение сюда в инспекторе
    public GameObject image2; // ѕеретащите второе изображение сюда в инспекторе
    public TextMeshProUGUI textMeshProUGUI;

    void Start()
    {
        // ”становите начальное состо€ние изображений
        UpdateImages(toggle.isOn);

        // ѕодпишитесь на событие изменени€ состо€ни€ Toggle
        toggle.onValueChanged.AddListener(OnToggleChanged);
    }
    void OnToggleChanged(bool isOn)
    {
        // »змените видимость изображений в зависимости от состо€ни€ Toggle
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
