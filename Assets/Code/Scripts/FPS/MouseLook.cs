using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform cam;

    private float sensitivity;

    public float normalSensitivity = 100f;
    public float scopedSensitivity = 50f;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        sensitivity = normalSensitivity;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    public void SetScoped(bool isScoped)
    {
        if (isScoped)
        {
            sensitivity = scopedSensitivity;
        } else
        {
            sensitivity = normalSensitivity;
        }
    }
}
