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

    int num = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //　もし今後スコア制を導入するなら、色付き +500 、色付き全破壊 +500*X体目 。通常は、100とかで
    //　さらに時間制限も設けるなら、色付き全破壊で +1;00　。
    void Update()
    {
        //横:10   縦:25   高:4　　総数 10*25*4=10*100=1000
        if (pop == true)
        {
            for (int high = 0; high < 4; high++)
            {
                for (int vert = 0; vert < 25; vert++)
                {
                    for (int widt = 0; widt < 10; widt++)
                    {
                        num++;
                        GameObject copied = Object.Instantiate(original) as GameObject;//oliginalをcopiする
                        copied.transform.Translate( wi, hi, ve);//copiの出てくる場所を(x=-25,y=30,z=-6~7)とする
                        copied.name = "block" + num;
                        wi+= 2;
                    }
                    ve--;
                    wi = -9;
                }
                hi++;
                ve = 17;
            }
            hi = 3;
            
            int Y = 0;
            int Z = 0;
            for (int X = 0; X < 10; X++)
            {
              /*  Y = Random.Range(2, 450);
                if (Y >= 50 && Y <= 104)
                {*/
                    Z = Random.Range(1, 250);
                    Debug.Log(Z);
                    GameObject ColorBlock = GameObject.Find("block" + Z);
                    ColorBlock.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
                //}
            }

            pop = false;
        }   
    }

    public void EBC()//blockが10個未満の時使用
    {

    }
}
