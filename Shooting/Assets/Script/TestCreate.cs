using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCreate : MonoBehaviour
{
    public GameObject[] Blocks;
    public GameObject B1original;//nomal
    public GameObject B2bomb;
    public GameObject B3freeze;
    public GameObject B4barrier;
    public GameObject B5annihilation;
    public GameObject B0Eoriginal;//緊急用

    bool pop = true;
    int AllBreak = 1;//全消し == 面

    int hi = 3;//height    高さ//3~5
    int ve = 17;//vertical　縦  //17~5
    int wi = -9;//width　　 横  //-9~5

    int num = 0;

    int wave = 0;
    int stage = 0;
    int produce_t = 0;//true
    int blocknum = 0;
    int BNR = 0;//blocknumrange

    public List<string> blockList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        Blocks = new GameObject[] { B0Eoriginal, B1original, B2bomb, B3freeze, B4barrier, B5annihilation };
    }

    // Update is called once per frame
    void Update()
    {
        if (pop == true)//(-9,3,17)→(7,5,-5)
        {
            for (int high = 0; high < 2; high++)
            {
                for (int vert = 0; vert < 2; vert++)
                {
                    for (int widt = 0; widt < 5; widt++)
                    {
                        if (wave >= 1)                                      
                                      //爆発＜（弾の複製）＜凍結＜（分裂）＜障壁＜対消滅　　()は未実装
                                      //bomb< (ballcopi) <freeze< (split) <barrier<annihilation
                                      // 0       X          <|1      X       <|2     O
                                      // O = できた　X = できてない　<|1 = 凍結と解凍ができてない　<|2 =　色変化、エフェクトができてない 
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
                    ve -= 2;
                    wi = -9;
                }
                hi += 2;
                ve = 17;
            }
            hi = 3;
            pop = false;
            num = 0;
        }
    }
    private void BlockCreate()
    {
        BNR = stage / 3;//四捨五入して整数に//もう少し早めに能力付き出してもいいかも　now stage 9^　出てる感じ
        Debug.Log(stage + "BNR" + BNR);
        if (BNR < 4)
        {
            blocknum = Random.Range(1, BNR + 1);
        }
        else //BNR >= 4
        {
            blocknum = Random.Range(1, BNR);
            if (BNR > 5) { BNR = 5; }
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
}
