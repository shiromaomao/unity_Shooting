using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{
    private GameObject MainCamera;
    private GameObject SubCamera1;
    private GameObject SubCamera2;
    private GameObject SubCamera3A;
    private GameObject SubCamera3a;

    bool MCactive = true;
    int SceneNum = 0;
    int ManualNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        SceneNum = SceneManage.Sc;
        ManualNum = PlayManual.MC;

        MainCamera = GameObject.Find("ManualMainCamera");
        SubCamera1 = GameObject.Find("ManualSubCamera1");
        SubCamera2 = GameObject.Find("ManualSubCamera2");
        SubCamera3A = GameObject.Find("GameMainCamera");
        SubCamera3a = GameObject.Find("GameSubCamera");

        if (SceneNum == 1 && ManualNum < 3)//sence‚ªplaymanual‚ÌŽžƒJƒƒ‰•ÏX
        {
            //==0 ‚ÌŽžMainCamera‚Ítrue//WASD
            if (ManualNum == 1)//©¨R
            {
                MainCamera.SetActive(false);
                SubCamera1.SetActive(true);
            }
            if (ManualNum == 2)//C~C C
            {
                SubCamera1.SetActive(false);
                SubCamera2.SetActive(true);
            }
        }
        SubCamera1.SetActive(false); SubCamera2.SetActive(false); SubCamera3A.SetActive(false); SubCamera3a.SetActive(false);
    }
    void Update()//ManualNum == 3‚àŠÜ‚Þ//speace
    {
        if (MCactive == true)
        {
            if (Input.GetKeyDown("space"))
            {
                SubCamera3A.SetActive(false);
                SubCamera3a.SetActive(true);
                MCactive = false;
            }
        }
        else
        {
            if (Input.GetKeyDown("space"))
            {
                SubCamera3a.SetActive(false);
                SubCamera3A.SetActive(true);
                MCactive = true;
            }
        }
    }
}
