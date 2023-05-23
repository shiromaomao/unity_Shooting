using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpsystem : MonoBehaviour //warp��sphere�ɂ���
{
    int Ss = 5;//Spheres
    public int BallHP = 0;//not static �@static�̓t�@�C���ŋ��ʂ̕ϐ��ɂȂ�

    bool GetSpeed = true;
    float SMaxSpeed = 51.9f;//S=Sphere
    Vector3 Fspeed = new Vector3(0,0,0);
    Vector3 Sv = new Vector3(0, 0, 0);

    public GameObject block;
    public GameObject B3freeze;
    public GameObject Sphere3;
    public GameObject ESphere;

    public Rigidbody rb;
    //�F�̕ω��i�S�ā����j

    public Material red;//�@�@��
    public Material black;//�@�� 

    // Start is called before the first frame update

    void Start()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        BallHP = 10;//�ŏ���10
        Fspeed = new Vector3(0, 0, 0);
        Sv = new Vector3(0, 0, 0);
        GetSpeed = true;
    }

    // Update is called once per frame
    void Update()
    {      
        LimitSpeed();

        LimitPosition(100);//-100~100�ɐ���
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
                Debug.Log("sph3" + BallHP);//0�@�ǂ��Ō����Ă�H
                Sphere3.GetComponent<Rigidbody>().useGravity = true;

            }
            BallHP = 10;
        }
       
    }
    private void OnCollisionEnter(Collision col)//���d�͂ƒe�j��A�����Ɋւ��镔��// �Ԃ���������̖��O���擾
    {
      
        
        if (col.gameObject.tag == "reflector")
        {
            if(BallHP <= 14) { BallHP += 1; }//15�܂�
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
            B3freeze = col.gameObject;//col=�ڐG��������
            BallHP++;
            StartCoroutine ("Float");
        }
        if (col.gameObject.tag == "B5annihilation")
        {
            this.gameObject.transform.position = new Vector3(17, 47, -2);
        }
    }
    /*���z�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@ ����          
     * �e��freeze���ڐG��ɒe�̑��x���擾�@�@�@�@�@�@�n  1 //��x�擾������Ď擾�܂�3�b�J����
     * �e��rigidbody�����W�Ɖ�]��S�Œ�@�@�@�@�@�@ �n  3
     * ���b(�R)���̂܂܁@3�b �@�@�@�@�@�@�@�@�@�@�@�@�n  4
     * �e��rigidbody�����W�Ɖ�]�̑S�Œ�������@�@�@ �n  5
     * �擾�������x�����@�@                        �n  6
     */
    public IEnumerator Float()  //�S�Ă̑��x�̕����𔽓]���đ�����ڐG�����ʂƐ��������̑��x�̂ݔ��]
    {
        if (GetSpeed == true)
        {
            Fspeed = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z); �@ //1 
            GetSpeed = false;
        }
        rb.constraints = RigidbodyConstraints.FreezeAll;                          //3
        yield return new WaitForSeconds(3);                                       //4
        GetSpeed = true;
        rb.constraints = RigidbodyConstraints.None;                               //5
        rb.velocity = Fspeed;                                                     //6
    }
    private void OnTriggerExit (Collider col) // �Ԃ���������̖��O���擾
    {
        if (col.gameObject.tag == "RigidbodyGrant")
        {
            rb.useGravity = true;
            
            if (gameObject.GetComponent<Renderer>().material != black)//�F�ς�
            {
                gameObject.GetComponent<Renderer>().material = black;
            }
        }
    }
    public void Restart()//�V�O�i�����󂯎���Ď��s(block_clone)
    {
        for (int Sw = 0; Sw < 8; Sw++)//Sw==SphereWarp
        {
            transform.position = new Vector3(17, 35, -2);
            
        }
        Sphere3.transform.position = new Vector3(16.4f, 15, -2.35f);
        Sphere3.GetComponent<Rigidbody>().useGravity = true;
    }

    public void ERestart()//�V�O�i�����󂯎���Ď��s(block_clone)
    {
        Destroy(ESphere);
    }

    private void LimitSpeed()
    { //�@���x�����l�𒴂����炻�̑��������߁A3�̑��x�����𓙔{���Ĉ��ȉ��Ɏ��߂�@
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

        Mathf.Clamp(this.gameObject.transform.position.x, -maxRange, maxRange);//-100~100�ɐ���
        Mathf.Clamp(this.gameObject.transform.position.y, -maxRange, maxRange);
        Mathf.Clamp(this.gameObject.transform.position.z, -maxRange, maxRange);  
    }
}
