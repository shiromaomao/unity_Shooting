using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block_clone : MonoBehaviour
{
    public GameObject original;
    public GameObject Eoriginal;//�ً}�p
    bool pop = true;

    int hi = 3;//height    ����//3~5
    int ve = 17;//vertical�@�c  //17~5
    int wi = -9;//width�@�@ ��  //-9~5

    int num = 0;

    int Ehi = 3;//����  3~5
    int Eve = 3;//�c    3~-3
    int Ewi = -9;//��    -9~5

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //�@��������X�R�A���𓱓�����Ȃ�A�F�t�� +500 �A�F�t���S�j�� +500*X�̖� �B�ʏ�́A100�Ƃ���
    //�@����Ɏ��Ԑ������݂���Ȃ�A�F�t���S�j��� +1;00�@�B
    void Update()
    {
        //��:10��5   �c:25��12   ��:4��2�@�@���� 10*25*4=10*100=1000����5*12*2=120
        if (pop == true)//(-9,3,17)��(7,5,-5)
        {
            for (int high = 0; high < 2; high++)
            {
                for (int vert = 0; vert < 12; vert++)
                {
                    for (int widt = 0; widt < 5; widt++)
                    {
                        num++;
                        GameObject copied = Object.Instantiate(original) as GameObject;//oliginal��copi����
                        copied.transform.Translate( wi, hi, ve);//copi�̏o�Ă���ꏊ��(x=-25,y=30,z=-6~7)�Ƃ���
                        copied.name = "block" + num;
                        wi+= 4;
                    }
                    ve-= 2;
                    wi = -9;
                }
                hi += 2;
                ve = 17;
            }
            hi = 3;
           
            int Y = 0;
            int Z = 0;
            for (int X = 0; X < 10; X++)
            {
                Y = Random.Range(2, 450);
                if (Y >= 50 && Y <= 104)
                {
                    Z = Random.Range(1, 120);
                    GameObject ColorBlock = GameObject.Find("block" + Z);
                    ColorBlock.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
                }
            }

            pop = false;
        }   
    }


    //����  3~5      �c  3~-3       ��  -9~5
    public void EBC()//block��10�����̎��g�p
    {
        for (int high = 0; high < 2; high++)
        {
            for (int vert = 0; vert < 6; vert++)
            {
                for (int widt = 0; widt < 5; widt++)
                {
                    num++;
                    GameObject copied = Object.Instantiate(Eoriginal) as GameObject;//Eoliginal��copi����
                    copied.transform.Translate(Ewi, Ehi, Eve);//copi�̏o�Ă���ꏊ��(x=,y=,z=)�Ƃ���
                    copied.name = "Eblock" + num;
                    Ewi += 2;
                }
                Eve --;
                Ewi = -9;
            }
            Ehi ++;
            Eve = 3;
        }
        Ehi = 3;
    }
}
