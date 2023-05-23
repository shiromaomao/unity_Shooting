using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{   
  /*�S�Ĕ�j�󎞂̃G�t�F�N�g�Ȃ�
    O  B1original;//nomal
    O  B2bomb;
    X  B3freeze;
    O  B4barrier;
    O  B5annihilation;
    X  B0Eoriginal;//�ً}�p
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
        tagId = this.gameObject.tag;      //�����@�I���@�Q�[���I�u�W�F�N�g
        sieldHP = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("n"))//��t�����i�S�����H�j
        {
            Destroy(this.gameObject);
            block_clone.blockList.Remove(name);
            Debug.Log("�S����");
        }
    }
    public void Break()
    {
        //�u���b�N������
        Destroy(this.gameObject);
        block_clone.blockList.Remove(name);
    }

    public void OnCollisionEnter(Collision collision)
    {   //sphere3��
        if (collision.gameObject.tag == "Sphere" || collision.gameObject.tag == "sphere3" || collision.gameObject.tag == "ESphere")
        {
            if (tagId == "B0Eoriginal" || tagId == "B1original"|| tagId == "B2bomb" || tagId == "B3freeze" || tagId == "B5annihilation")//nomals //bomb //annihilation
            {
                Break();
            }
            //freeze ���b�Œ�B���̌�Ăѓ����o��
            //���x�����擾�B�����S�Œ�Byield return�őҋ@�B�����Œ�����B���x�������B
            //������warpsystem�Ő���

            if (tagId == "B4barrier")//barrier 
                                     //barrier�̂ݕ�����ς���
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