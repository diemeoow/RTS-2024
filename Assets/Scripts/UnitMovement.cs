using UnityEngine;
using UnityEngine.AI; // Для использования навигации

public class UnitMovement : MonoBehaviour
{
    public float speed = 3.5f;
    private NavMeshAgent agent;
    private Vector3 targetPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Правая кнопка мыши для передвижения
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                targetPosition = hit.point;
                agent.SetDestination(targetPosition);
            }
        }
    }
}