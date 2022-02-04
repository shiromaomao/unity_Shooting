using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpsystem : MonoBehaviour
{
    //warpとsphereについて

    int count = 0;

    public GameObject block;

    public Rigidbody rb;


    //色の変化（全て→黒）

    public Material red;//　　赤
    public Material black;//　黒

    int BBC = 0;//BlockBreakCount
    
    private void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name); // ぶつかった相手の名前を取得
        if (col.gameObject.tag == "Block")
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
            Debug.Log("rb = F");
        }
    }

    private void OnTriggerExit (Collider col)
    {
        Debug.Log(col.gameObject.name); // ぶつかった相手の名前を取得

        if (col.gameObject.tag == "RigidbodyGrant")
        {
            rb.useGravity = true;
            Debug.Log("rb = T");

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
    }
}
