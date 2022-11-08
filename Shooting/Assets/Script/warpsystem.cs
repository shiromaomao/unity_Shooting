using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpsystem : MonoBehaviour
{
    //warpとsphereについて
    int Ss = 5;//Spheres
    int count = 0;

    public GameObject block;
    public GameObject Sphere3;
    public GameObject ESphere;

    public Rigidbody rb;

    //色の変化（全て→黒）

    public Material red;//　　赤
    public Material black;//　黒 
    private void OnCollisionEnter(Collision col)//無重力と弾破壊、加速に関する部分
    {
        if (col.gameObject.tag == "Block")// ぶつかった相手の名前を取得
        {
            if (count >= 20)
            {
                transform.position = new Vector3(17, 48, -3);
                count = 0;
            }
            count += 1;

            col.gameObject.GetComponent<block>().Break();
        }

        if (col.gameObject.tag == "reflector")
        {
            count -= 1;
        }

        if(col.gameObject.tag == "Wall")
        {
            rb.useGravity = false;
            rb.AddForce(transform.up, ForceMode.Impulse);          
        }
    }

    private void OnTriggerExit (Collider col) // ぶつかった相手の名前を取得
    {
        if (col.gameObject.tag == "RigidbodyGrant")
        {
            rb.useGravity = true;
            
            if (gameObject.GetComponent<Renderer>().material != black)
            {
                gameObject.GetComponent<Renderer>().material = black;
            }
        }
    }
    // Start is called before the first frame update

    void Start()
    {
             
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -5)
        {
            transform.position = new Vector3(15, 48, 0);
        }

        Mathf.Clamp(this.gameObject.transform.position.x, -100, 100);//100~-100に制限
        Mathf.Clamp(this.gameObject.transform.position.y, -100, 100);
        Mathf.Clamp(this.gameObject.transform.position.z, -100, 100);
    }

    public void Restart()//シグナルを受け取って実行(block_clone)
    {
        for (int Sw = 0; Sw < Ss; Sw++)//Sw==SphereWarp
        {
            transform.position = new Vector3(17, 35, -2);
            Sphere3.transform.position = new Vector3(16.4f, 15, -2.35f);
        }
    }

    public void ERestart()//シグナルを受け取って実行(block_clone)
    {
        Destroy(ESphere);
    }
}
