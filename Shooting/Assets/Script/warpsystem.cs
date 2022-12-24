using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpsystem : MonoBehaviour
{
    //warp��sphere�ɂ���
    int Ss = 5;//Spheres
    int count = 0;

    float SMaxSpeed = 51.9f;//S=Sphere

    public GameObject block;
    public GameObject Sphere3;
    public GameObject ESphere;

    public Rigidbody rb;

    //�F�̕ω��i�S�ā����j

    public Material red;//�@�@��
    public Material black;//�@�� 

    // Start is called before the first frame update

    void Start()
    {

    }
       
    // Update is called once per frame
    void Update()
    {
        LimitSpeed();

        LimitPosition(100);//-100~100�ɐ���
    }
    private void OnCollisionEnter(Collision col)//���d�͂ƒe�j��A�����Ɋւ��镔��
    {
        if (col.gameObject.tag == "Block")// �Ԃ���������̖��O���擾
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

    private void OnTriggerExit (Collider col) // �Ԃ���������̖��O���擾
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
    public void Restart()//�V�O�i�����󂯎���Ď��s(block_clone)
    {
        for (int Sw = 0; Sw < Ss; Sw++)//Sw==SphereWarp
        {
            transform.position = new Vector3(17, 35, -2);
            Sphere3.transform.position = new Vector3(16.4f, 15, -2.35f);
        }
    }

    public void ERestart()//�V�O�i�����󂯎���Ď��s(block_clone)
    {
        Destroy(ESphere);
    }

    private void LimitSpeed()
    {   //1�@���x�����l�𒴂����炻��Ɣ��Ε����ɉ����x��������
        //2�@���x�����l�𒴂����炻�̑��������߁A3�̑��x�����𓙔{���Ĉ��ȉ��Ɏ��߂�@
        //�@�I�΂ꂽ�̂͂Q�ł���
        float Speed = (float)Math.Sqrt(Math.Pow(rb.velocity.x, 2) + Math.Pow(rb.velocity.y, 2) + Math.Pow(rb.velocity.z, 2));
        if (Speed >= SMaxSpeed)//SMaxSpeed = 51.9
        {
            Debug.Log(Speed);
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
        }

        Mathf.Clamp(this.gameObject.transform.position.x, -maxRange, maxRange);//-100~100�ɐ���
        Mathf.Clamp(this.gameObject.transform.position.y, -maxRange, maxRange);
        Mathf.Clamp(this.gameObject.transform.position.z, -maxRange, maxRange);  
    }
}
