using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpsystem : MonoBehaviour
{
    //warp��sphere�ɂ���
    int Ss = 5;//Spheres
    int count = 0;

    public GameObject block;
    public GameObject Sphere3;
    public GameObject ESphere;

    public Rigidbody rb;

    //�F�̕ω��i�S�ā����j

    public Material red;//�@�@��
    public Material black;//�@�� 
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

        Mathf.Clamp(this.gameObject.transform.position.x, -100, 100);//100~-100�ɐ���
        Mathf.Clamp(this.gameObject.transform.position.y, -100, 100);
        Mathf.Clamp(this.gameObject.transform.position.z, -100, 100);
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
}
