//using UnityEngine;

//public class MovementController : MonoBehaviour
//{
//    private void Update()
//    {
//        if (Input.GetMouseButtonDown(1)) // ПКМ для перемещения
//        {
//            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//            if (Physics.Raycast(ray, out RaycastHit hit))
//            {
//                foreach (SelectableUnit unit in UnitSelectionManager.Instance.GetSelectedUnits())
//                {
//                    unit.GetComponent<UnitMovement>().MoveTo(hit.point);
//                }
//            }
//        }
//    }
//}