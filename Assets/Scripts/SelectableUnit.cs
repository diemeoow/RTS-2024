//using UnityEngine;

//public class SelectableUnit : MonoBehaviour
//{
//    private Renderer unitRenderer;
//    public Material defaultMaterial;
//    public Material selectedMaterial;

//    private void Start()
//    {
//        unitRenderer = GetComponent<Renderer>();
//        unitRenderer.material = defaultMaterial; // Устанавливаем базовый материал
//    }

//    private void OnMouseDown()
//    {
//        // Выделение юнита
//        UnitSelectionManager.Instance.SelectUnit(this);
//    }

//    public void Select()
//    {
//        unitRenderer.material = selectedMaterial; // Меняем материал на "выделенный"
//    }

//    public void Deselect()
//    {
//        unitRenderer.material = defaultMaterial; // Возвращаем материал обратно
//    }
//}