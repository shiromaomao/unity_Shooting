using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block_clone : MonoBehaviour
{
    public GameObject[] Blocks;
    public GameObject B1original;//nomal
    public GameObject B2bomb;
    public GameObject B3freeze;
    public GameObject B4barrier;
    public GameObject B5annihilation;
    public GameObject B0Eoriginal;//�ً}�p

    public GameObject[] Spheres;//�Ĕz�u�p
    public GameObject Sphere;
    public GameObject Sphere1;
    public GameObject Sphere2;
    public GameObject Sphere3;
    public GameObject Sphere4;

    public GameObject Muzzle;

    bool pop = true;
    int AllBreak = 1;//�S���� == ��

    int hi = 3;//height    ����//3~5
    int ve = 17;//vertical�@�c  //17~5
    int wi = -9;//width�@�@ ��  //-9~5

    int num = 0;

    int espheres_C = 0;

    int Ehi = 3;//����  3~5
    int Eve = 3;//�c    3~-3
    int Ewi = -9;//��    -9~5

    int wave = 0;
    int stage = 0;//2�ʈȍ~
    int produce_t = 0;//true
    int blocknum = 0;
    int BNR = 0 ;//blocknumrange

    public static List<string> blockList = new List<string>();//���L�ł���ɂ���悤�ɂ���

    public static List<GameObject> ESpheres = new List<GameObject>();//���L�ł���ɂ���悤�ɂ���

    // Start is called before the first frame update
    void Start()
    {
        Spheres = new GameObject[] { Sphere, Sphere1, Sphere2, Sphere3, Sphere4};
        Blocks = new GameObject[] { B0Eoriginal,B1original, B2bomb, B3freeze, B4barrier, B5annihilation};
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
                        if (wave >= 1)//2�ʈȍ~
                                       //�ʂ��i�ނ��ƂɃm�[�}�������炵�ċ����\�͕t���𑝂₷�B()�͖�����
                                       //�������i�e�̕����j���������i����j����ǁ��Ώ���
                                       //bomb< (ballcopi) <freeze< (split) <barrier<annihilation
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
                    ve-= 2;
                    wi = -9;
                }
                hi += 2;
                ve = 17;
            }
            hi = 3;
            pop = false;
            num = 0;
        }

        if (Input.GetKeyDown("up") && espheres_C < 3)
        {
            ESpheres.Add(Muzzle.GetComponent<ESlaunch>().ESl());
            Debug.Log("ESadd");
            espheres_C++;
        }

        if (blockList.Count == 0 && pop == false)//block 0 //�Q�[����
        {
            Sphere3.SendMessage("Restart");//���ꂼ���Sphere��Restart���ĂƂ���ɃV�O�i���𑗂�(warpsystem.Restart) 
           /* for (int S = 0; S < Spheres.Length; S++)
            {   
                if (Spheres[S] != null) { break; }
                
            }*/

            AllBreak++;
            
            if (wave == 5) { wave = 0;stage++; }
            wave++;
            Debug.Log("wave"+wave);
            Debug.Log("stage" + stage);

            pop = true;

            //prefab�ɒ���SendMessage�͂ł��Ȃ������̂�Clone�������ESphere��clone�ɃV�O�i���𑗂�(warpsystem.ERestart) 

            //ESphere.GetComponent<warpsystem>().ERestart();
         /*   for (int ES = 0; ES < 3; ES++)
            {
                if (ESpheres[ES] != null)//�I�u�W�F�N�g�����݂��Ă���Ԃ͎��s
                {
                   // if (ESpheres[ES] == null) { break; }
                    ESpheres[ES].GetComponent<warpsystem>().ERestart();
         }
                else
                {
                    break;
                }
            }*/


        }
    }

    private void BlockCreate()
    { 
        BNR = stage / 3;//�l�̌ܓ����Đ�����//�����������߂ɔ\�͕t���o���Ă����������@now stage 9^�@�o�Ă銴��
        Debug.Log(stage + "BNR" + BNR);
        if (BNR < 4) 
        {  
            blocknum = Random.Range(1,BNR + 1);
        } else //BNR >= 4
        {
            blocknum = Random.Range(1, BNR);
            if(BNR > 5) { BNR = 5; }
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

    public void ColorChange()//�{�X�p
    {
        int X = 0;
        float nX = 0; 
        int Y = 0;
        int ColorBlocks = 0;

        X = blockList.Count;//�c���̔c��
        nX = X * 0.2f;//20%�̎w��

        for (int Z = 0; Z <= nX; Z++)//120C24=120!/24!
        {
            Y = Random.Range(1, blockList.Count);//�c���u���b�N�̒�����F�t����I��
            string targetblock = blockList[Y+1];
            GameObject ColorBlock = GameObject.Find(targetblock);
            ColorBlock.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
            ColorBlocks++;
            blockList.Remove("block" + Y);
        }

        if (ColorBlocks <= 10)//�����F�t����10�ȉ��Ȃ�
        {
            for (int high = 0; high < 2; high++)//����  3~5      �c  3~-3       ��  -9~5
            {
                for (int vert = 0; vert < 6; vert++)
                {
                    for (int widt = 0; widt < 5; widt++)
                    {
                        num++;
                        if (num == 4080)
                        {
                            num = 0;
                        }
                        GameObject copied = Object.Instantiate(B0Eoriginal) as GameObject;//Eoliginal��copi����
                        copied.transform.Translate(Ewi, Ehi, Eve);//copi�̏o�Ă���ꏊ��(x=,y=,z=)�Ƃ���
                        copied.name = "Eblock" + num;
                        blockList.Add ("Eblock" + num);
                        Ewi += 2;
                    }
                    Eve--;
                    Ewi = -9;
                }
                Ehi++;
                Eve = 3;
            }
            Ehi = 3;
        }
    }
}
/*
 * stage-wave
 * 
 * 1-1  nomal only
 * 1-2~5  nomal bomb
 * 2-1~5  nomal bomb freeze
 * 3-1~5  nomal bomb freeze barrier
 * 4-1~5  nomal bomb freeze barrier annihilation
 * 5-1~5  nomal bomb freeze barrier annihilation
 * 6-1~5  nomal bomb freeze barrier annihilation
 * 
 *�@�@�����_���łU���o���Ƃ��Ď��ۂ̃I�u�W�F�N�g�͂P�R���Ă��ƁH
 * 
 * 
 * list          index
 * 1              1
 * 2              2
 * 3              5
 * 4              6
 * 5              12
 * 6              13
 * 7              14
 * 8              15
 * 9              18
 * 10             45
 * 
 * 
 * 
 */