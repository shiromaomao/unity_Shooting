using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block_clone : MonoBehaviour
{
    public GameObject original;
    public GameObject Eoriginal;//�ً}�p

    public GameObject[] Spheres;//�Ĕz�u�p
    public GameObject Sphere;
    public GameObject Sphere1;
    public GameObject Sphere2;
    public GameObject Sphere3;
    public GameObject Sphere4;

    public GameObject Muzzle;

    bool pop = true;
    int AllBreak = 0;//�S����

    int hi = 3;//height    ����//3~5
    int ve = 17;//vertical�@�c  //17~5
    int wi = -9;//width�@�@ ��  //-9~5

    int num = 0;

    int espheres_C = 0;

    int Ehi = 3;//����  3~5
    int Eve = 3;//�c    3~-3
    int Ewi = -9;//��    -9~5

    int stage = 0;//2�ʈȍ~
    int produse_t = 0;//true
    int skill_c = 0;//count

    public static List<string> blockList = new List<string>();//���L�ł���ɂ���悤�ɂ���

    public static List<GameObject> ESpheres = new List<GameObject>();//���L�ł���ɂ���悤�ɂ���

    // Start is called before the first frame update
    void Start()
    {
        Spheres = new GameObject[] { Sphere, Sphere1, Sphere2, Sphere3, Sphere4};
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
                        if (stage >= 1)//2�ʈȍ~
                        {
                            num++;
                            produse_t = Random.Range(0, 10 * stage);
                            if (produse_t >= 0 && produse_t <= 1.8*stage)//����
                            {
                                GameObject copied = Object.Instantiate(original) as GameObject;//oliginal��copi����
                                //if (skill_c > 0)
                                while (skill_c >= 0)//�\�͕t�^(script��inspector��Add����H)
                                {
                                    skill_c--;
                                    if (skill_c < 0)
                                    {
                                        break;
                                    }
                                }
                                copied.transform.Translate(wi, hi, ve);//copi�̏o�Ă���ꏊ��(x=-25,y=30,z=-6~7)�Ƃ���
                                copied.name = "block" + num;
                                blockList.Add("block" + num);
                            }
                            else
                            {
                                skill_c++;
                                if (produse_t >= 7 * stage)
                                {
                                    skill_c += (stage * 2);
                                }
                            }                            
                            wi += 4;
                        }
                        else//1��
                        {
                            num++;
                            GameObject copied = Object.Instantiate(original) as GameObject;//oliginal��copi����
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
        }

        if (Input.GetKeyDown("up") && espheres_C < 3)
        {
            ESpheres.Add(Muzzle.GetComponent<ESlaunch>().ESl());
            Debug.Log("ESadd");
            espheres_C++;
        }

        if (blockList.Count == 0 && pop == false)//block 0 //�Q�[����
        {
            for (int S = 0; S < Spheres.Length; S++)
            {   
                if (Spheres[S] != null) { break; }
                Spheres[S].SendMessage("Restart");//���ꂼ���Sphere��Restart���ĂƂ���ɃV�O�i���𑗂�(warpsystem.Restart) 
            }

            //prefab�ɒ���SendMessage�͂ł��Ȃ������̂�Clone�������ESphere��clone�ɃV�O�i���𑗂�(warpsystem.ERestart) 

            //ESphere.GetComponent<warpsystem>().ERestart();
            for (int ES = 0; ES < 3; ES++)
            {
                if (ESpheres[ES] != null)//�I�u�W�F�N�g�����݂��Ă���Ԃ͎��s
                {
                    if (ESpheres[ES] == null) { break; }
                    ESpheres[ES].GetComponent<warpsystem>().ERestart();

                }
            }

            AllBreak++;
            stage++;
            pop = true;
        }
    }

    public void ColorChange()
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
                        GameObject copied = Object.Instantiate(Eoriginal) as GameObject;//Eoliginal��copi����
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
/*�@�@�����_���łU���o���Ƃ��Ď��ۂ̃I�u�W�F�N�g�͂P�R���Ă��ƁH
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