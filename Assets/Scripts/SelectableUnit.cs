//using UnityEngine;

//public class SelectableUnit : MonoBehaviour
//{
//    private Renderer unitRenderer;
//    public Material defaultMaterial;
//    public Material selectedMaterial;

//    private void Start()
//    {
//        unitRenderer = GetComponent<Renderer>();
//        unitRenderer.material = defaultMaterial; // ������������� ������� ��������
//    }

//    private void OnMouseDown()
//    {
//        // ��������� �����
//        UnitSelectionManager.Instance.SelectUnit(this);
//    }

//    public void Select()
//    {
//        unitRenderer.material = selectedMaterial; // ������ �������� �� "����������"
//    }

//    public void Deselect()
//    {
//        unitRenderer.material = defaultMaterial; // ���������� �������� �������
//    }
//}