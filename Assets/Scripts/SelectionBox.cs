//using System.Collections.Generic;
//using UnityEngine;

//public class SelectionBox : MonoBehaviour
//{
//    public RectTransform selectionBox;
//    public Camera mainCamera;

//    private Vector3 startMousePosition;
//    private List<SelectableUnit> selectedUnits = new List<SelectableUnit>();

//    private void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            startMousePosition = Input.mousePosition;
//            selectionBox.gameObject.SetActive(true);
//        }

//        if (Input.GetMouseButton(0))
//        {
//            Vector3 endMousePosition = Input.mousePosition;
//            DrawSelectionBox(startMousePosition, endMousePosition);
//        }

//        if (Input.GetMouseButtonUp(0))
//        {
//            selectionBox.gameObject.SetActive(false);
//            SelectUnitsWithinBox();
//        }
//    }

//    private void DrawSelectionBox(Vector3 start, Vector3 end)
//    {
//        Vector3 center = (start + end) / 2;
//        selectionBox.position = center;

//        Vector2 size = new Vector2(Mathf.Abs(start.x - end.x), Mathf.Abs(start.y - end.y));
//        selectionBox.sizeDelta = size;
//    }

//    private void SelectUnitsWithinBox()
//    {
//        // Логика выбора юнитов в рамке
//        Vector2 min = (Vector2)selectionBox.position - (selectionBox.sizeDelta / 2);
//        Vector2 max = (Vector2)selectionBox.position +(selectionBox.sizeDelta / 2);

//        foreach (SelectableUnit unit in FindObjectsOfType<SelectableUnit>())
//        {
//            Vector3 screenPos = mainCamera.WorldToScreenPoint(unit.transform.position);

//            if (screenPos.x > min.x && screenPos.x < max.x && screenPos.y > min.y && screenPos.y < max.y)
//            {
//                selectedUnits.Add(unit);
//                unit.Select();
//            }
//            else
//            {
//                unit.Deselect();
//            }
//        }
//    }
//}