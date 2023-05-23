using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpsystem : MonoBehaviour //warpとsphereについて
{
    int Ss = 5;//Spheres
    public int BallHP = 0;//not static 　staticはファイルで共通の変数になる

    bool GetSpeed = true;
    float SMaxSpeed = 51.9f;//S=Sphere
    Vector3 Fspeed = new Vector3(0,0,0);
    Vector3 Sv = new Vector3(0, 0, 0);

    public GameObject block;
    public GameObject B3freeze;
    public GameObject Sphere3;
    public GameObject ESphere;

    public Rigidbody rb;
    //色の変化（全て→黒）

    public Material red;//　　赤
    public Material black;//　黒 

    // Start is called before the first frame update

    void Start()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        BallHP = 10;//最初は10
        Fspeed = new Vector3(0, 0, 0);
        Sv = new Vector3(0, 0, 0);
        GetSpeed = true;
    }

    // Update is called once per frame
    void Update()
    {      
        LimitSpeed();

        LimitPosition(100);//-100~100に制限
        if (this.gameObject.transform.position.y >= 100)
        {
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            BallHP = 10;
        }
        if (BallHP <= 0)
        {
            this.gameObject.transform.position = new Vector3(17, 35, -2);

            if (this.gameObject.tag == "sphere3")
            {
                Sphere3.transform.position = new Vector3(16.4f, 15, -2.35f);
                Debug.Log("Sphere3");
                Debug.Log("sph3" + BallHP);//0　どこで減ってる？
                Sphere3.GetComponent<Rigidbody>().useGravity = true;

            }
            BallHP = 10;
        }
       
    }
    private void OnCollisionEnter(Collision col)//無重力と弾破壊、加速に関する部分// ぶつかった相手の名前を取得
    {
      
        
        if (col.gameObject.tag == "reflector")
        {
            if(BallHP <= 14) { BallHP += 1; }//15まで
        }

        if(col.gameObject.tag == "Wall")
        {
            rb.useGravity = false;
           // rb.AddForce(transform.up, ForceMode.Impulse);          
        }
        if (col.gameObject.tag == "B0Eoriginal" || col.gameObject.tag == "B1original" || col.gameObject.tag == "B4barrier")
        { 
            BallHP--;
        }
        if (col.gameObject.tag == "B2bomb")
        { 
            BallHP -= 3;
        }
        if (col.gameObject.tag == "B3freeze")
        {
            B3freeze = col.gameObject;//col=接触した物体
            BallHP++;
            StartCoroutine ("Float");
        }
        if (col.gameObject.tag == "B5annihilation")
        {
            this.gameObject.transform.position = new Vector3(17, 47, -2);
        }
    }
    /*理想　　　　　　　　　　　　　　　　　　　　　 現状          
     * 弾とfreezeが接触後に弾の速度を取得　　　　　　Ｏ  1 //一度取得したら再取得まで3秒開ける
     * 弾のrigidbodyを座標と回転を全固定　　　　　　 Ｏ  3
     * 数秒(３)そのまま　3秒 　　　　　　　　　　　　Ｏ  4
     * 弾のrigidbodyを座標と回転の全固定を解除　　　 Ｏ  5
     * 取得した速度を代入　　                        Ｏ  6
     */
    public IEnumerator Float()  //全ての速度の符号を反転して代入→接触した面と垂直方向の速度のみ反転
    {
        if (GetSpeed == true)
        {
            Fspeed = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z); 　 //1 
            GetSpeed = false;
        }
        rb.constraints = RigidbodyConstraints.FreezeAll;                          //3
        yield return new WaitForSeconds(3);                                       //4
        GetSpeed = true;
        rb.constraints = RigidbodyConstraints.None;                               //5
        rb.velocity = Fspeed;                                                     //6
    }
    private void OnTriggerExit (Collider col) // ぶつかった相手の名前を取得
    {
        if (col.gameObject.tag == "RigidbodyGrant")
        {
            rb.useGravity = true;
            
            if (gameObject.GetComponent<Renderer>().material != black)//色変え
            {
                gameObject.GetComponent<Renderer>().material = black;
            }
        }
    }
    public void Restart()//シグナルを受け取って実行(block_clone)
    {
        for (int Sw = 0; Sw < 8; Sw++)//Sw==SphereWarp
        {
            transform.position = new Vector3(17, 35, -2);
            
        }
        Sphere3.transform.position = new Vector3(16.4f, 15, -2.35f);
        Sphere3.GetComponent<Rigidbody>().useGravity = true;
    }

    public void ERestart()//シグナルを受け取って実行(block_clone)
    {
        Destroy(ESphere);
    }

    private void LimitSpeed()
    { //　速度が一定値を超えたらその速さを求め、3つの速度成分を等倍して一定以下に収める　
        float Speed = (float)Math.Sqrt(Math.Pow(rb.velocity.x, 2) + Math.Pow(rb.velocity.y, 2) + Math.Pow(rb.velocity.z, 2));
        if (Speed >= SMaxSpeed)//SMaxSpeed = 51.9
        {
           
            rb.velocity = new Vector3(
                rb.velocity.x / (Speed / SMaxSpeed),
                rb.velocity.y / (Speed / SMaxSpeed),
                rb.velocity.z / (Speed / SMaxSpeed)
            );
        }
    }

    private void LimitPosition(int maxRange)
    {
        if(transform.position.y < -5)
        {
            transform.position = new Vector3(15, 48, 0);
            BallHP = 10;
        }

        Mathf.Clamp(this.gameObject.transform.position.x, -maxRange, maxRange);//-100~100に制限
        Mathf.Clamp(this.gameObject.transform.position.y, -maxRange, maxRange);
        Mathf.Clamp(this.gameObject.transform.position.z, -maxRange, maxRange);  
    }
}
