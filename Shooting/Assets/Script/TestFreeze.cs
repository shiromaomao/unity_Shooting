using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFreeze : MonoBehaviour
{
    bool AF = true;
    float stopx = 0;/*(ball) stop x */ float stopx1 = 0;
    float stopy = 0;/*            y */ float stopy1 = 0;
    float stopz = 0;/*            z */ float stopz1 = 0;

    bool GetSpeed = true;//���x�Ď擾�܂łɃC���^�[�o����݂��邽��

    float SMaxSpeed = 51.9f;//S=Sphere
    Vector3 Fspeed = new Vector3(0, 0, 0);
    Vector3 Sv = new Vector3(0, 0, 0);
    bool Fx = false;//�ڐG�ʔ���p//true �E�ɂ���
    bool Fy = false;//����//true ��ɂ���
    bool Fz = false;//����//true ���ɂ���
    float Dx = 0;//distance x
    float Dy = 0;//distance y
    float Dz = 0;//distance z

    int Fnum = 0;//Debug�p

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
           // StartCoroutine("AddForce");//�e���~�܂������p//5�b������
        }
    }
   /* public IEnumerator AddForce()
    {
        stopx = this.transform.position.x; stopy = this.transform.position.y; stopz = this.transform.position.z;
        yield return new WaitForSeconds(5);//5�b�H�t���[���H
        stopx1 = this.transform.position.x; stopy1 = this.transform.position.y; stopz1 = this.transform.position.z;
        Debug.Log("�v������");
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
    public IEnumerator testFloat()//test topic / UNITY���ŉ��Z������ɑ��x�擾���Œ�ҋ@���Œ���������x���
    {  
        //yield return new WaitForSeconds(0.01f);// 1f==1/60s
        if(GetSpeed == true)
        {
            Fspeed = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);        //���x�擾   //��x�擾������Ď擾�܂�3�b�J����
            GetSpeed = false;  
        }

        rb.constraints = RigidbodyConstraints.FreezeAll;                          //�Œ�
        Debug.Log("freeze");
        ObjectCollider.isTrigger = false;
        yield return new WaitForSeconds(3);                                       //�ҋ@
        GetSpeed = true;                                                          //���x�Ď擾����
        rb.constraints = RigidbodyConstraints.None;                               //�Œ����
        rb.velocity = Fspeed;
    }
    //����Ȃ����́@
    //judge2() judge6()
}
