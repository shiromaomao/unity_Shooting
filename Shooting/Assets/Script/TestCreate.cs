using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCreate : MonoBehaviour
{
    public GameObject[] Blocks;
    public GameObject B1original;//nomal
    public GameObject B2bomb;
    public GameObject B3freeze;
    public GameObject B4barrier;
    public GameObject B5annihilation;
    public GameObject B0Eoriginal;//�ً}�p

    bool pop = true;
    int AllBreak = 1;//�S���� == ��

    int hi = 3;//height    ����//3~5
    int ve = 17;//vertical�@�c  //17~5
    int wi = -9;//width�@�@ ��  //-9~5

    int num = 0;

    int wave = 0;
    int stage = 0;
    int produce_t = 0;//true
    int blocknum = 0;
    int BNR = 0;//blocknumrange

    public List<string> blockList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        Blocks = new GameObject[] { B0Eoriginal, B1original, B2bomb, B3freeze, B4barrier, B5annihilation };
    }

    // Update is called once per frame
    void Update()
    {
        if (pop == true)//(-9,3,17)��(7,5,-5)
        {
            for (int high = 0; high < 2; high++)
            {
                for (int vert = 0; vert < 2; vert++)
                {
                    for (int widt = 0; widt < 5; widt++)
                    {
                        if (wave >= 1)                                      
                                      //�������i�e�̕����j���������i����j����ǁ��Ώ��Ł@�@()�͖�����
                                      //bomb< (ballcopi) <freeze< (split) <barrier<annihilation
                                      // 0       X          <|1      X       <|2     O
                                      // O = �ł����@X = �ł��ĂȂ��@<|1 = �����Ɖ𓀂��ł��ĂȂ��@<|2 =�@�F�ω��A�G�t�F�N�g���ł��ĂȂ� 
                        {
                            num++;

                            BlockCreate();
                            wi += 4;
                        }
                        else//1��
                        {
                            num++;
                            //test �ꎞ�I��B1original��B3freeze
                            GameObject copied = Object.Instantiate(B3freeze) as GameObject;//oliginal��copi����
                            copied.transform.Translate(wi, hi, ve);//copi�̏o�Ă���ꏊ��(x=-25,y=30,z=-6~7)�Ƃ���
                            copied.name = "block" + num;
                            blockList.Add("block" + num);
                            wi += 4;
                        }
                    }
                    ve -= 2;
                    wi = -9;
                }
                hi += 2;
                ve = 17;
            }
            hi = 3;
            pop = false;
            num = 0;
        }
    }
    private void BlockCreate()
    {
        BNR = stage / 3;//�l�̌ܓ����Đ�����//�����������߂ɔ\�͕t���o���Ă����������@now stage 9^�@�o�Ă銴��
        Debug.Log(stage + "BNR" + BNR);
        if (BNR < 4)
        {
            blocknum = Random.Range(1, BNR + 1);
        }
        else //BNR >= 4
        {
            blocknum = Random.Range(1, BNR);
            if (BNR > 5) { BNR = 5; }
        }
        //produse_t �������邩���Ȃ����Ɋ֌W
        produce_t = Random.Range(0, 100);
        if (produce_t > 5)//5%�̊m���Ő������Ȃ�
        {
            GameObject kind = Blocks[blocknum];
            GameObject copied = Object.Instantiate(kind) as GameObject;//������block��copi����
            copied.transform.Translate(wi, hi, ve);
            copied.name = "block" + num;
            blockList.Add("block" + num);
        }

    }
}
