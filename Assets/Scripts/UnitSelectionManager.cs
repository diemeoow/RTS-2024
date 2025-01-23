//using System.Collections.Generic;
//using UnityEngine;

//public class UnitSelectionManager : MonoBehaviour
//{
//    public static UnitSelectionManager Instance;

//    private List<SelectableUnit> selectedUnits = new List<SelectableUnit>();
    
//    private void Awake()
//    {
//        Instance = this;
//    }

//    public void SelectUnit(SelectableUnit unit)
//    {
//        // Снимаем выделение с других юнитов
//        DeselectAll();
//        selectedUnits.Add(unit);
//        unit.Select();
//    }

//    public void DeselectAll()
//    {
//        foreach (SelectableUnit unit in selectedUnits)
//        {
//            unit.Deselect();
//        }
//        selectedUnits.Clear();
//    }
//    public List<SelectableUnit> GetSelectedUnits()
//    {
//        return selectedUnits; 
//    }
//}