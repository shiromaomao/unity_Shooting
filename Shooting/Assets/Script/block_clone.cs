using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block_clone : MonoBehaviour
{
    public GameObject original;
    bool pop = true;

    int hi = 3;//height    ����//3~6
    int ve = 17;//vertical�@�c  //17~-7
    int wi = -9;//width�@�@ ��  //-9~9

    int num = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //�@��������X�R�A���𓱓�����Ȃ�A�F�t�� +500 �A�F�t���S�j�� +500*X�̖� �B�ʏ�́A100�Ƃ���
    //�@����Ɏ��Ԑ������݂���Ȃ�A�F�t���S�j��� +1;00�@�B
    void Update()
    {
        //��:10   �c:25   ��:4�@�@���� 10*25*4=10*100=1000
        if (pop == true)
        {
            for (int high = 0; high < 4; high++)
            {
                for (int vert = 0; vert < 25; vert++)
                {
                    for (int widt = 0; widt < 10; widt++)
                    {
                        num++;
                        GameObject copied = Object.Instantiate(original) as GameObject;//oliginal��copi����
                        copied.transform.Translate( wi, hi, ve);//copi�̏o�Ă���ꏊ��(x=-25,y=30,z=-6~7)�Ƃ���
                        copied.name = "block" + num;
                        wi+= 2;
                    }
                    ve--;
                    wi = -9;
                }
                hi++;
                ve = 17;
            }
            hi = 3;
            
            int Y = 0;
            int Z = 0;
            for (int X = 0; X < 10; X++)
            {
              /*  Y = Random.Range(2, 450);
                if (Y >= 50 && Y <= 104)
                {*/
                    Z = Random.Range(1, 250);
                    Debug.Log(Z);
                    GameObject ColorBlock = GameObject.Find("block" + Z);
                    ColorBlock.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
                //}
            }

            pop = false;
        }   
    }

    public void EBC()//block��10�����̎��g�p
    {

    }
}
