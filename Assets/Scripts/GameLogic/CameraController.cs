using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 50f; 
    public float scrollSpeed = 100f;
    public float edgeThreshold = 10f;

    [Header("Zoom Settings")]
    public float zoomSpeed = 10f;
    public float minZoom = 20f; 
    public float maxZoom = 80f;

    private Camera cam;

    void Start()
    {
        cam = Camera.main; 
    }

    void Update()
    {
        HandleMovement();
        HandleZoom();
        HandleEdgeScroll();
    }
    void HandleMovement()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            moveDirection += Vector3.forward;
        if (Input.GetKey(KeyCode.S))
            moveDirection += Vector3.back;
        if (Input.GetKey(KeyCode.A))
            moveDirection += Vector3.left;
        if (Input.GetKey(KeyCode.D))
            moveDirection += Vector3.right;

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    void HandleEdgeScroll()
    {
        Vector3 mousePosition = Input.mousePosition;

        if (mousePosition.x < edgeThreshold)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
        }
        if (mousePosition.x > Screen.width - edgeThreshold)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
        }
        if (mousePosition.y < edgeThreshold)
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.World);
        }
        if (mousePosition.y > Screen.height - edgeThreshold)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
        }
    }


    private void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - scroll * zoomSpeed, minZoom, maxZoom);
    }
}
