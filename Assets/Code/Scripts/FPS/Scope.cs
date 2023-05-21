using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public GameObject scopeOverlay;
    public GameObject wepCam;
    public Camera cam;
    private MouseLook ml;

    public float scopedFOV = 15f;
    private float normFOV;

    private bool isScoped = false;

    private void Start()
    {
        normFOV = cam.fieldOfView;
        ml = GetComponent<MouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            scopeOverlay.SetActive(isScoped);
            ml.SetScoped(isScoped);
            wepCam.SetActive(!isScoped);
        }

        if (isScoped)
        {
            cam.fieldOfView = scopedFOV;
        } else
        {
            cam.fieldOfView = normFOV;
        }
    }
}
