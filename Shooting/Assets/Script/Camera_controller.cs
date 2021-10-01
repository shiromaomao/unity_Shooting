using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{
    private GameObject MainCamera;
    private GameObject SubCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = GameObject.Find("MainCamera");
        SubCamera = GameObject.Find("SubCamera");

        SubCamera.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKey("space"))
        {
            MainCamera.SetActive(false);
            SubCamera.SetActive(true);
        }
        else
        {
            SubCamera.SetActive(false);
            MainCamera.SetActive(true);
        }
    }
}
