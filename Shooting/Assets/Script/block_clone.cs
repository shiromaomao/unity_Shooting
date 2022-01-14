using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block_clone : MonoBehaviour
{
    public GameObject original;
    bool pop = true;

    int hi = 3;//height    高さ//3~6
    int ve = 17;//vertical　縦  //17~-7
    int wi = -9;//width　　 横  //-9~9
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //横:10   縦:25   高:3
        if (pop == true)
        {
            for (int high = 0; high < 4; high++)
            {
                for (int vert = 0; vert < 25; vert++)
                {
                    for (int widt = 0; widt < 10; widt++)
                    {
                        GameObject copied = Object.Instantiate(original) as GameObject;//oliginalをcopiする
                        copied.transform.Translate( wi, hi, ve);//copiの出てくる場所を(x=-25,y=30,z=-6~7)とする
                        wi+= 2;
                    }
                    ve--;
                    wi = -9;
                }
                hi++;
                ve = 17;
            }
            hi = 3;
            pop = false;

        }
    }

}
