using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using System;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance;  
    public GameObject OneUnitSelectedPanel;
    public List<GameObject> hudElements = new List<GameObject>();
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ShowUnitHUD(List<GameObject> selectedUnits)
    {
        ClearHUD(); // Очистим текущие элементы

        if (selectedUnits.Count == 1)
        {
            OneUnitSelectedPanel.SetActive(true);
            Transform unitIconTransform = OneUnitSelectedPanel.transform.Find("Icon");
            Image unitIcon = unitIconTransform.GetComponent<Image>();
            
            TextMeshProUGUI unitName = OneUnitSelectedPanel.GetComponentInChildren<TextMeshProUGUI>();
          
            GameObject unit = selectedUnits[0];
            if (unit.CompareTag("Unit"))
            {
                UnitScript unitScript = unit.GetComponent<UnitScript>();
                if (unitScript != null)
                {
                    unitIcon.sprite = unitScript.unitIcon;
                    unitName.text = unitScript.Name;

                }

            }
        }
    }
    public void ClearHUD()
    {
        foreach (GameObject hudElement in hudElements)
        {
            Destroy(hudElement);
        }
        hudElements.Clear();
    }
}

