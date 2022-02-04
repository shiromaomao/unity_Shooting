using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{
    private GameObject MainCamera;
    private GameObject SubCamera;

    bool MCactive = true;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = GameObject.Find("MainCamera");
        SubCamera = GameObject.Find("SubCamera");

        SubCamera.SetActive(false);
    }
    void Update()
    {
        Debug.Log("CCF2");//ここまで行った
        if (MCactive == true)
        {
            if (Input.GetKeyDown("space"))
            {
                Debug.Log("McA");
                MainCamera.SetActive(false);
                SubCamera.SetActive(true);
                MCactive = false;
            }
        }
        else
        {
            if (Input.GetKeyDown("space"))
            {
                Debug.Log("ScA");
                SubCamera.SetActive(false);
                MainCamera.SetActive(true);
                MCactive = true;
            }
        }
    }
}
