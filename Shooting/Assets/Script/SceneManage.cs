using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public static int Sc = 0;//Scene count
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Sc == 0)//title
        {
            if (Input.GetKey("m"))//ëÄçÏê‡ñæÇ…
            {
                Debug.Log("manual");
                SceneManager.LoadScene("Playmanual");//Sc == 1
                Sc++;
            }
        }
        if (Sc <= 2)//playâÊñ Ç…
        {
            if (Input.GetKey("p"))
            {
                Debug.Log("play");
                SceneManager.LoadScene("Shooting");//Sc == 2
                Sc = 2;
            }
        }
        if (Sc == 2)//playâÊñ Å®ëÄçÏê‡ñæ
        {
            if (Input.GetKey("m"))
            {
                Debug.Log("manual");
                SceneManager.LoadScene("Playmanual");//Sc == 1
                Sc--;
            }
        }
    }
}
