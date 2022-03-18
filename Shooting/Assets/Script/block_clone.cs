using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block_clone : MonoBehaviour
{
    public GameObject original;
    public GameObject Eoriginal;//緊急用
    bool pop = true;

    int hi = 3;//height    高さ//3~5
    int ve = 17;//vertical　縦  //17~5
    int wi = -9;//width　　 横  //-9~5

    int num = 0;

    int Ehi = 3;//高さ  3~5
    int Eve = 3;//縦    3~-3
    int Ewi = -9;//横    -9~5

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //　もし今後スコア制を導入するなら、色付き +500 、色付き全破壊 +500*X体目 。通常は、100とかで
    //　さらに時間制限も設けるなら、色付き全破壊で +1;00　。
    void Update()
    {
        //横:10→5   縦:25→12   高:4→2　　総数 10*25*4=10*100=1000→→5*12*2=120
        if (pop == true)//(-9,3,17)→(7,5,-5)
        {
            for (int high = 0; high < 2; high++)
            {
                for (int vert = 0; vert < 12; vert++)
                {
                    for (int widt = 0; widt < 5; widt++)
                    {
                        num++;
                        GameObject copied = Object.Instantiate(original) as GameObject;//oliginalをcopiする
                        copied.transform.Translate( wi, hi, ve);//copiの出てくる場所を(x=-25,y=30,z=-6~7)とする
                        copied.name = "block" + num;
                        wi+= 4;
                    }
                    ve-= 2;
                    wi = -9;
                }
                hi += 2;
                ve = 17;
            }
            hi = 3;
           
            int Y = 0;
            int Z = 0;
            for (int X = 0; X < 10; X++)
            {
                Y = Random.Range(2, 450);
                if (Y >= 50 && Y <= 104)
                {
                    Z = Random.Range(1, 120);
                    GameObject ColorBlock = GameObject.Find("block" + Z);
                    ColorBlock.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
                }
            }

            pop = false;
        }   
    }


    //高さ  3~5      縦  3~-3       横  -9~5
    public void EBC()//blockが10個未満の時使用
    {
        for (int high = 0; high < 2; high++)
        {
            for (int vert = 0; vert < 6; vert++)
            {
                for (int widt = 0; widt < 5; widt++)
                {
                    num++;
                    GameObject copied = Object.Instantiate(Eoriginal) as GameObject;//Eoliginalをcopiする
                    copied.transform.Translate(Ewi, Ehi, Eve);//copiの出てくる場所を(x=,y=,z=)とする
                    copied.name = "Eblock" + num;
                    Ewi += 2;
                }
                Eve --;
                Ewi = -9;
            }
            Ehi ++;
            Eve = 3;
        }
        Ehi = 3;
    }
}
