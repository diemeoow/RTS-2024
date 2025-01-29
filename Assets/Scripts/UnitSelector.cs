using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UnitSelector : MonoBehaviour
{
    public RectTransform selectionBoxUI; // RectTransform ��� selection box
    public Camera mainCamera;
    public List<RectTransform> noSelectionAreas; // �������, ��� ������ �������� ������

    public static List<GameObject> SelectedUnits { get; private set; } = new List<GameObject>(); // ������ ��������� ������
    private Vector2 startMousePos; // ��������� ������� ����
    private Vector2 endMousePos; // �������� ������� ����
    private bool isSelecting = false; // ����, �����������, ��� ���������� �����
    private bool singleUnitSelected = false; // ����, �����������, ��� ��� ������ ���� ����
    private bool mouseMoved = false; // ����, �����������, ��� ���� ���������

    void Update()
    {
        HandleSelection();

        if (isSelecting && IsPointerOverNoSelectionArea())
        {
            isSelecting = false;
            selectionBoxUI.gameObject.SetActive(false);
        }
    }

    void HandleSelection()
    {
        if (Input.GetMouseButtonDown(0) && !IsPointerOverNoSelectionArea())
        {
            startMousePos = Input.mousePosition;
            isSelecting = true;
            singleUnitSelected = false;
            mouseMoved = false;

            // �������� �� ����� ������ �����
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;
                if (hitObject.CompareTag("Unit") || hitObject.CompareTag("Buildings"))
                {
                    DeselectAllUnits();
                    SelectUnit(hitObject);
                    singleUnitSelected = true;
                    HUDManager.Instance.ShowUnitHUD(SelectedUnits); // ������������� ����, ��� ��� ������ ���� ����
                    return;
                }
            }
        }

        if (Input.GetMouseButton(0) && isSelecting && !singleUnitSelected)
        {
            endMousePos = Input.mousePosition;
            if (startMousePos != endMousePos)
            {
                mouseMoved = true;
                selectionBoxUI.gameObject.SetActive(true);
                UpdateSelectionBox();
            }
        }

        if (Input.GetMouseButtonUp(0) && isSelecting && !singleUnitSelected && mouseMoved)
        {
            isSelecting = false;
            selectionBoxUI.gameObject.SetActive(false);
            SelectUnitsInBox();
        }
    }

    void UpdateSelectionBox()
    {
        float width = endMousePos.x - startMousePos.x;
        float height = endMousePos.y - startMousePos.y;
        selectionBoxUI.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));

        // ������������� selectionBox ����� startMousePos � endMousePos
        selectionBoxUI.anchoredPosition = startMousePos + new Vector2(width / 2, height / 2);
    }

    void SelectUnitsInBox()
    {
        DeselectAllUnits();

        Vector2 min = Vector2.Min(startMousePos, endMousePos);
        Vector2 max = Vector2.Max(startMousePos, endMousePos);

        foreach (GameObject unit in GameObject.FindGameObjectsWithTag("Unit"))
        {
            Vector3 screenPos = mainCamera.WorldToScreenPoint(unit.transform.position);

            if (screenPos.x >= min.x && screenPos.x <= max.x &&
                screenPos.y >= min.y && screenPos.y <= max.y)
            {
                SelectUnit(unit);
            }
        }
    }

    void SelectUnit(GameObject unit)
    {
        SelectedUnits.Add(unit);
        Transform selectionSprite = unit.transform.Find("SelectionSprite");
        if (selectionSprite != null)
        {
            selectionSprite.gameObject.SetActive(true);
        }
    }

    void DeselectAllUnits()
    {
        foreach (GameObject unit in SelectedUnits)
        {
            Transform selectionSprite = unit.transform.Find("SelectionSprite");
            if (selectionSprite != null)
            {
                selectionSprite.gameObject.SetActive(false);
            }
        }
        SelectedUnits.Clear();
    }

    bool IsPointerOverNoSelectionArea()
    {
        Vector2 mousePos = Input.mousePosition;
        foreach (RectTransform area in noSelectionAreas)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(area, mousePos))
            {
                return true;
            }
        }
        return false;
    }
}
