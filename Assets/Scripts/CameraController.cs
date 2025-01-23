using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 50f; 
    public float scrollSpeed = 100f;

    [Header("Zoom Settings")]
    public float zoomSpeed = 10f;
    public float minZoom = 20f; 
    public float maxZoom = 80f;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main; 
    }

    private void Update()
    {
        HandleMovement();
        HandleZoom();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

  
    private void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - scroll * zoomSpeed, minZoom, maxZoom);
    }
}
