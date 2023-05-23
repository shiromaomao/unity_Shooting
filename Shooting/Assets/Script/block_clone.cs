using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block_clone : MonoBehaviour
{
    public GameObject[] Blocks;
    public GameObject B1original;//nomal
    public GameObject B2bomb;
    public GameObject B3freeze;
    public GameObject B4barrier;
    public GameObject B5annihilation;
    public GameObject B0Eoriginal;//緊急用

    public GameObject[] Spheres;//再配置用
    public GameObject Sphere;
    public GameObject Sphere1;
    public GameObject Sphere2;
    public GameObject Sphere3;
    public GameObject Sphere4;

    public GameObject Muzzle;

    bool pop = true;
    int AllBreak = 1;//全消し == 面

    int hi = 3;//height    高さ//3~5
    int ve = 17;//vertical　縦  //17~5
    int wi = -9;//width　　 横  //-9~5

    int num = 0;

    int espheres_C = 0;

    int Ehi = 3;//高さ  3~5
    int Eve = 3;//縦    3~-3
    int Ewi = -9;//横    -9~5

    int wave = 0;
    int stage = 0;//2面以降
    int produce_t = 0;//true
    int blocknum = 0;
    int BNR = 0 ;//blocknumrange

    public static List<string> blockList = new List<string>();//共有できるにするようにする

    public static List<GameObject> ESpheres = new List<GameObject>();//共有できるにするようにする

    // Start is called before the first frame update
    void Start()
    {
        Spheres = new GameObject[] { Sphere, Sphere1, Sphere2, Sphere3, Sphere4};
        Blocks = new GameObject[] { B0Eoriginal,B1original, B2bomb, B3freeze, B4barrier, B5annihilation};
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
                        if (wave >= 1)//2面以降
                                       //面が進むごとにノーマルを減らして強い能力付きを増やす。()は未実装
                                       //爆発＜（弾の複製）＜凍結＜（分裂）＜障壁＜対消滅
                                       //bomb< (ballcopi) <freeze< (split) <barrier<annihilation
                        {
                            num++;

                            BlockCreate();
                            wi += 4;
                        }
                        else//1面
                        {
                            num++;
                            //test 一時的にB1original→B3freeze
                            GameObject copied = Object.Instantiate(B3freeze) as GameObject;//oliginalをcopiする
                            copied.transform.Translate(wi, hi, ve);//copiの出てくる場所を(x=-25,y=30,z=-6~7)とする
                            copied.name = "block" + num;
                            blockList.Add("block" + num);
                            wi += 4;
                        }
                    }
                    ve-= 2;
                    wi = -9;
                }
                hi += 2;
                ve = 17;
            }
            hi = 3;
            pop = false;
            num = 0;
        }

        if (Input.GetKeyDown("up") && espheres_C < 3)
        {
            ESpheres.Add(Muzzle.GetComponent<ESlaunch>().ESl());
            Debug.Log("ESadd");
            espheres_C++;
        }

        if (blockList.Count == 0 && pop == false)//block 0 //ゲーム中
        {
            Sphere3.SendMessage("Restart");//それぞれのSphereのRestartってところにシグナルを送る(warpsystem.Restart) 
           /* for (int S = 0; S < Spheres.Length; S++)
            {   
                if (Spheres[S] != null) { break; }
                
            }*/

            AllBreak++;
            
            if (wave == 5) { wave = 0;stage++; }
            wave++;
            Debug.Log("wave"+wave);
            Debug.Log("stage" + stage);

            pop = true;

            //prefabに直でSendMessageはできなかったのでCloneした後のESphereのcloneにシグナルを送る(warpsystem.ERestart) 

            //ESphere.GetComponent<warpsystem>().ERestart();
         /*   for (int ES = 0; ES < 3; ES++)
            {
                if (ESpheres[ES] != null)//オブジェクトが存在している間は実行
                {
                   // if (ESpheres[ES] == null) { break; }
                    ESpheres[ES].GetComponent<warpsystem>().ERestart();
         }
                else
                {
                    break;
                }
            }*/


        }
    }

    private void BlockCreate()
    { 
        BNR = stage / 3;//四捨五入して整数に//もう少し早めに能力付き出してもいいかも　now stage 9^　出てる感じ
        Debug.Log(stage + "BNR" + BNR);
        if (BNR < 4) 
        {  
            blocknum = Random.Range(1,BNR + 1);
        } else //BNR >= 4
        {
            blocknum = Random.Range(1, BNR);
            if(BNR > 5) { BNR = 5; }
        }
        //produse_t 生成するかしないかに関係
        produce_t = Random.Range(0, 100);
        if (produce_t > 5)//5%の確率で生成しない
        {
            GameObject kind = Blocks[blocknum];
            GameObject copied = Object.Instantiate(kind) as GameObject;//いろんなblockをcopiする
            copied.transform.Translate(wi, hi, ve);
            copied.name = "block" + num;
            blockList.Add("block" + num);
        }

    }

    public void ColorChange()//ボス用
    {
        int X = 0;
        float nX = 0; 
        int Y = 0;
        int ColorBlocks = 0;

        X = blockList.Count;//残数の把握
        nX = X * 0.2f;//20%の指定

        for (int Z = 0; Z <= nX; Z++)//120C24=120!/24!
        {
            Y = Random.Range(1, blockList.Count);//残存ブロックの中から色付きを選ぶ
            string targetblock = blockList[Y+1];
            GameObject ColorBlock = GameObject.Find(targetblock);
            ColorBlock.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
            ColorBlocks++;
            blockList.Remove("block" + Y);
        }

        if (ColorBlocks <= 10)//もし色付きが10個以下なら
        {
            for (int high = 0; high < 2; high++)//高さ  3~5      縦  3~-3       横  -9~5
            {
                for (int vert = 0; vert < 6; vert++)
                {
                    for (int widt = 0; widt < 5; widt++)
                    {
                        num++;
                        if (num == 4080)
                        {
                            num = 0;
                        }
                        GameObject copied = Object.Instantiate(B0Eoriginal) as GameObject;//Eoliginalをcopiする
                        copied.transform.Translate(Ewi, Ehi, Eve);//copiの出てくる場所を(x=,y=,z=)とする
                        copied.name = "Eblock" + num;
                        blockList.Add ("Eblock" + num);
                        Ewi += 2;
                    }
                    Eve--;
                    Ewi = -9;
                }
                Ehi++;
                Eve = 3;
            }
            Ehi = 3;
        }
    }
}
/*
 * stage-wave
 * 
 * 1-1  nomal only
 * 1-2~5  nomal bomb
 * 2-1~5  nomal bomb freeze
 * 3-1~5  nomal bomb freeze barrier
 * 4-1~5  nomal bomb freeze barrier annihilation
 * 5-1~5  nomal bomb freeze barrier annihilation
 * 6-1~5  nomal bomb freeze barrier annihilation
 * 
 *　　ランダムで６が出たとして実際のオブジェクトは１３ってこと？
 * 
 * 
 * list          index
 * 1              1
 * 2              2
 * 3              5
 * 4              6
 * 5              12
 * 6              13
 * 7              14
 * 8              15
 * 9              18
 * 10             45
 * 
 * 
 * 
 */