using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public GameObject crosshair;
    //public Camera cam;
    public Animator anim;
    public float scopedFOV = 15f;

    private MouseLook ml;
    private float normFOV;
    private bool isScoped = false;

    private void Start()
    {
        //normFOV = cam.fieldOfView;
        ml = GetComponent<MouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            anim.SetBool("isScoped", isScoped);
            crosshair.SetActive(!isScoped);
            ml.SetScoped(isScoped);
        }

        /*if (isScoped)
        {
            cam.fieldOfView = scopedFOV;
        } else
        {
            cam.fieldOfView = normFOV;
        }*/
    }
}
