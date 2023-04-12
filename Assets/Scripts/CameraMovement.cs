using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset = new Vector3(0f, 2f, -5f);
    public float rotateSpeed = 5f;
    public float verticalRotationRange = 30f;
    public float verticalSpeed = 2f;
    public float zoomSpeed = 5f; // uzakla�ma/yak�nla�ma h�z�
    public float maxZoomDistance = 20f; // maksimum uzakl�k de�eri

    private float currentX = 0f;
    private float currentY = 0f;
    private float currentZoom = 0f; // eklenen de�i�ken

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        currentX = transform.eulerAngles.y;
        playerTransform.rotation = Quaternion.Euler(0f, currentX, 0f);
    }

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed * verticalSpeed;

        currentX += mouseX;
        currentY -= mouseY;
        currentY = Mathf.Clamp(currentY, -verticalRotationRange, verticalRotationRange);

        float zoomAmount = Input.GetAxis("Mouse ScrollWheel") * -zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom + zoomAmount, 0f, maxZoomDistance); // uzakla�ma miktar� kontrol edilir

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0f);
        Vector3 position = playerTransform.position + rotation * offset - transform.forward * currentZoom; // uzakla�ma offset de�eri eklenir
        transform.position = position;
        transform.rotation = rotation;

    }
}