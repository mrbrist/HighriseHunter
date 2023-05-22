using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public GameObject crosshair;
    public Camera cam;
    public Animator anim;

    public float[] fovValues;
    public float[] sensitivityValues;
    public float scrollSensitivity = 10f;

    private MouseLook ml;
    private bool isScoped = false;
    private int currentFOVIndex = 0;

    private void Start()
    {
        ml = GetComponent<MouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // chnage scope zoom using scroll wheel input
        if (scrollInput != 0f && isScoped)
        {
            currentFOVIndex -= (int)Mathf.Sign(scrollInput);
            currentFOVIndex = Mathf.Clamp(currentFOVIndex, 0, fovValues.Length - 1);
            cam.fieldOfView = fovValues[currentFOVIndex];
            ml.SetZoom(isScoped, sensitivityValues[currentFOVIndex]);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            anim.SetBool("isScoped", isScoped);
            crosshair.SetActive(!isScoped);
            ml.SetZoom(isScoped, sensitivityValues[currentFOVIndex]);
        }
    }
}
