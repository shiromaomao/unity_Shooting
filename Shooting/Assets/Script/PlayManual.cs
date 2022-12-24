using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PlayManual : MonoBehaviour
{
    //�z�����ĂԂ�����
    public GameObject manual_object = null;
    public GameObject SceneManager = null;
    public static int MC = 0;//ManualCount

    bool mcW = false;//0    //mc = manual check
    bool mcA = false;//0
    bool mcS = false;//0
    bool mcD = false;//0
    bool mcLeft = false;//1
    bool mcRight = false;//1
    bool mcR = false;//1
    bool MC2 = false;//2
    bool MC2judge = false;//2
    bool MC3 = false;//3
    bool MClast = false;//4,5

    List<string> manual_list = new List<string>();

    // Start is called before the first frame update
    void Start()// \n (�o�b�N�X���b�V���{���ŉ��s)PC�ɂ���Ă̓o�b�N�X���b�V���������̃}�[�N�ɂȂ�
    {
        MC = 0;
        manual_list.Add("���F�̔�reflector��\nWASD�ŏ㉺�ړ����ł����");//0
        manual_list.Add("reflector�͍��E�̖��L�[\n�Ō�����ς�����\nR�L�[�Œ����ɖ߂��");//1
        manual_list.Add("C�L�[�������Œe�𑕓U\n������xC�L�[�������Ɣ��ˁI");//2
        manual_list.Add("�X�y�[�X�L�[�Ŏ��_��\n�؂�ւ��邱�Ƃ��ł����");//3
        manual_list.Add("m�L�[�Ń`���[�g���A��\n�ɖ߂��Ă�����I");//4
        manual_list.Add("PUSH�@P�@PLAY\n�@PUSH�@B�@BACK\n�@(PUSH�@N�@NEXT)");//5//PLAY�͂ł��Ă�
    }

    // Update is called once per frame
    public void Update()
    {
        //MC2 = LPsensor.MC2pass;//from LPsensor

        if (Input.GetKey("m"))
        {
            MC = 0;//ManualCount

            mcW = false;//0    //mc = manual check
            mcA = false;//0
            mcS = false;//0
            mcD = false;//0
            mcLeft = false;//1
            mcRight = false;//1
            mcR = false;//1
            MC2 = false;//2
            MC2judge = false;//2
            MC3 = false;//3
            MClast = false;//4,5
        }
        // �I�u�W�F�N�g����Text�R���|�[�l���g���擾
        Text manual_text = manual_object.GetComponentInChildren<Text>();

        manual_text.text = manual_list[MC];
        //������������āA�����B���Ō�ɍs����悤�ɂ�����
        //0.1�@�v���C���[�̈ړ����@�@�A2�@�e�̑��U�Ɣ��ˁ@�A3�@�J�����̕ύX�@�A4�@�}�j���A���ɖ߂���@
        // �e�L�X�g�̕\�������ւ���
        if (Input.GetKeyDown("n") && MC < 5)//test�p
        {
            MC++;
        }
        if (Input.GetKeyDown("b") && MC > 0)//back
        {
            MC--;
        }
        //MC == 0
        if (Input.GetKeyDown("w") && MC == 0) { mcW = true; }
        if (Input.GetKeyDown("a") && MC == 0) { mcA = true; }
        if (Input.GetKeyDown("s") && MC == 0) { mcS = true; }
        if (Input.GetKeyDown("d") && MC == 0) { mcD = true; }
        if (mcW && mcA && mcS && mcD)
        {
            MC = 1;
            mcW = false; mcA = false; mcS = false; mcD = false;
        }
        //MC == 1
        if (Input.GetKeyDown("r") && MC == 1) { mcR = true; }
        if (Input.GetKeyDown("left") && MC == 1) { mcLeft = true; }
        if (Input.GetKeyDown("right") && MC == 1) { mcRight = true; }
        if (mcR && mcLeft && mcRight)
        {
            MC = 2;
            mcR = false; mcLeft = false; mcRight = false;
            Debug.Log("M1comp");
        }
        //MC == 2
        MC2 = LPsensor.MC2pass;
        if (MC2 && !MC2judge)//LPsensor�Ŕ��ʂ���
        {
            MC = 3;
            MC2 = false;
            MC2judge = true;
            Debug.Log("M2comp");
        }
        if(MC != 2) { MC2judge = false; }
        //MC == 3
        //Camera�̐؂�ւ��� Camera_controller �Ő؂�ւ�������
        if (MC == 3)
        {
            Debug.Log("M3start");
            MC3 = Camera_controller.MC3comp;//3
            MClast = true;
            if (MC3)
            {
                Debug.Log("M3comp");
                MC = 4;
                MC3 = false;
            }
        }
        if(MClast && MC == 4)
        {
            MClast = false;
            StartCoroutine("ManualCount");
        }
    }

    public IEnumerator ManualCount()
    {
        MC = 4;
        yield return new WaitForSeconds(5);
        MC = 5;
        yield return new WaitForSeconds(10);
        SceneManager.SendMessage("play");
        yield break;
    }
}
