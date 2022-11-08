using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{
    private GameObject TitleCamera;
    private GameObject MainCamera;
    private GameObject SubCamera1;
    private GameObject SubCamera2;
    private GameObject SubCamera3A;
    private GameObject SubCamera3a;

    bool MCactive = true;//ManualCamera
    int SceneNum = 0;
    int ManualNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        SceneNum = SceneManage.Sc;
        ManualNum = PlayManual.MC;
        //カメラを探してあったら代入//一回全部オフにする
        if (GameObject.Find("MainCamera") != null)
        { TitleCamera = GameObject.Find("MainCamera"); TitleCamera.SetActive(false);}
        if (GameObject.Find("ManualMainCamera") != null)
        { MainCamera = GameObject.Find("ManualMainCamera"); MainCamera.SetActive(false); }
        if (GameObject.Find("ManualSubCamera1") != null)
        { SubCamera1 = GameObject.Find("ManualSubCamera1"); SubCamera1.SetActive(false); }
        if (GameObject.Find("ManualSubCamera2") != null)
        { SubCamera2 = GameObject.Find("ManualSubCamera2"); SubCamera2.SetActive(false); }
        if (GameObject.Find("GameMainCamera") != null)
        { SubCamera3A = GameObject.Find("GameMainCamera"); SubCamera3A.SetActive(false); }
        if (GameObject.Find("GameSubCamera") != null)
        { SubCamera3a = GameObject.Find("GameSubCamera"); SubCamera3a.SetActive(false); }
    }


    void Update()//ManualNum == 3も含む//speace
    {
        if(SceneNum == 0)//title
        {
            TitleCamera.SetActive(true);
        }
        SceneNum = SceneManage.Sc;
        ManualNum = PlayManual.MC;
        if (SceneNum == 1 && ManualNum < 4)//senceがplaymanualの時のカメラ変更
        {
            if (ManualNum == 0)//WASD
            {
                MainCamera.SetActive(true);
            }
            if (ManualNum == 1)//←→R
            {
                MainCamera.SetActive(false);
                SubCamera1.SetActive(true);
            }
            if (ManualNum == 2)//C~C C
            {
                SubCamera1.SetActive(false);
                SubCamera2.SetActive(true);

            }
            if (ManualNum == 3)//MC3
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
                        Debug.Log("MC3comp");
                    }
                }        
            }
            
        }
        if (SceneNum == 2)
        {
            if (Input.GetKeyDown("p"))//title→play
            {
                MCactive = true;
            }
            if (MCactive == true)//Play
            {
                TitleCamera.SetActive(false);
                MainCamera.SetActive(false);
                SubCamera1.SetActive(false);
                SubCamera2.SetActive(false);
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
}
