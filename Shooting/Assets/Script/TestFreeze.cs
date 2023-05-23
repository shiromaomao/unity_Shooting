using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFreeze : MonoBehaviour
{
    bool AF = true;
    float stopx = 0;/*(ball) stop x */ float stopx1 = 0;
    float stopy = 0;/*            y */ float stopy1 = 0;
    float stopz = 0;/*            z */ float stopz1 = 0;

    bool GetSpeed = true;//速度再取得までにインターバルを設けるため

    float SMaxSpeed = 51.9f;//S=Sphere
    Vector3 Fspeed = new Vector3(0, 0, 0);
    Vector3 Sv = new Vector3(0, 0, 0);
    bool Fx = false;//接触面判定用//true 右にいる
    bool Fy = false;//同上//true 上にいる
    bool Fz = false;//同上//true 奥にいる
    float Dx = 0;//distance x
    float Dy = 0;//distance y
    float Dz = 0;//distance z

    int Fnum = 0;//Debug用

    public GameObject B3freeze;

    public Rigidbody rb;

    Collider ObjectCollider;
    // Start is called before the first frame update
    void Start()
    {
        ObjectCollider = GetComponent<Collider>();
        Fnum = 0;
        AF = true;
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GetSpeed = true;
    }
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("f"))//freeze
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        if (Input.GetKey("m"))//melt
        {
            rb.constraints = RigidbodyConstraints.None;
        }

        if (AF == true)
        {
            AF = false;
           // StartCoroutine("AddForce");//弾が止まった時用//5秒かかる
        }
    }
   /* public IEnumerator AddForce()
    {
        stopx = this.transform.position.x; stopy = this.transform.position.y; stopz = this.transform.position.z;
        yield return new WaitForSeconds(5);//5秒？フレーム？
        stopx1 = this.transform.position.x; stopy1 = this.transform.position.y; stopz1 = this.transform.position.z;
        Debug.Log("計測完了");
        if (stopx == stopx1 && stopy == stopy1 && stopz == stopz1)
        {
            //for()
            this.gameObject.GetComponent<Rigidbody>().AddForce(-40, 50, -10);
            Debug.Log("AddForce");
        }
        AF = true;
    }*/
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Wall")
        {
            rb.useGravity = false;       
        }

        if(col.gameObject.tag == "B3freeze")
        {
            ObjectCollider.isTrigger = true;
            StartCoroutine("testFloat");
            Fnum++;
        }
    }
    public IEnumerator testFloat()//test topic / UNITY側で演算した後に速度取得→固定待機→固定解除→速度代入
    {  
        //yield return new WaitForSeconds(0.01f);// 1f==1/60s
        if(GetSpeed == true)
        {
            Fspeed = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);        //速度取得   //一度取得したら再取得まで3秒開ける
            GetSpeed = false;  
        }

        rb.constraints = RigidbodyConstraints.FreezeAll;                          //固定
        Debug.Log("freeze");
        ObjectCollider.isTrigger = false;
        yield return new WaitForSeconds(3);                                       //待機
        GetSpeed = true;                                                          //速度再取得解禁
        rb.constraints = RigidbodyConstraints.None;                               //固定解除
        rb.velocity = Fspeed;
    }
    //いらないもの　
    //judge2() judge6()
}
