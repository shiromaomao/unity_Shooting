using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{   
  /*全て被破壊時のエフェクトなし
    O  B1original;//nomal
    O  B2bomb;
    X  B3freeze;
    O  B4barrier;
    O  B5annihilation;
    X  B0Eoriginal;//緊急用
   */
    public string tagId;
    int sieldHP = 0;

    //Barrier Color
    byte G = 0;//byte 0~255
    byte B = 0;
    byte A = 0;


    // Start is called before the first frame update
    void Start()
    {
        G = 255;  B = 39; A = 214;
        tagId = this.gameObject.tag;      //文字　！＝　ゲームオブジェクト
        sieldHP = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("n"))//二フラム（全消し？）
        {
            Destroy(this.gameObject);
            block_clone.blockList.Remove(name);
            Debug.Log("全消し");
        }
    }
    public void Break()
    {
        //ブロックを消す
        Destroy(this.gameObject);
        block_clone.blockList.Remove(name);
    }

    public void OnCollisionEnter(Collision collision)
    {   //sphere3種
        if (collision.gameObject.tag == "Sphere" || collision.gameObject.tag == "sphere3" || collision.gameObject.tag == "ESphere")
        {
            if (tagId == "B0Eoriginal" || tagId == "B1original"|| tagId == "B2bomb" || tagId == "B3freeze" || tagId == "B5annihilation")//nomals //bomb //annihilation
            {
                Break();
            }
            //freeze 数秒固定。その後再び動き出す
            //速度等を取得。ｒｂ全固定。yield returnで待機。ｒｂ固定解除。速度等を代入。
            //凍結はwarpsystemで制御

            if (tagId == "B4barrier")//barrier 
                                     //barrierのみ複数回耐える
            {
                if (sieldHP >= 1)
                {
                    sieldHP--;

                    G -= 85; B -= 13; A -= 40;

                    gameObject.GetComponent<Renderer>().material.color = new Color32(255, G, B, A);//RGBA
                    //255-85-85-85=0
                    //39-13-13-13=0
                    //214-40-40-40=96
                }
                else { Break(); sieldHP = 3; G = 255; B = 39; A = 214;}
                
            }

        }
        

    }
}