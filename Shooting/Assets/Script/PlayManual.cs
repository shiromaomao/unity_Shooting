using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayManual : MonoBehaviour
{
    //�z�����ĂԂ�����
    public GameObject manual_object = null;

    public static int MC = 0;//ManualCount

    bool mcW = false;//0    //mc = manual check
    bool mcA = false;//0
    bool mcS = false;//0
    bool mcD = false;//0
    bool mcLeft = false;//1
    bool mcRight = false;//1
    bool mcR = false;//2
    bool mcHold = false;//2
    int LongPress = 10;//2
    int Pushing = 0;//2

    List<string> manual_list = new List<string>();

    // Start is called before the first frame update
    void Start()// \n (�o�b�N�X���b�V���{���ŉ��s)PC�ɂ���Ă̓o�b�N�X���b�V���������̃}�[�N�ɂȂ�
    {
        manual_list.Add("���F�̔�reflector��\nWASD�ŏ㉺�ړ����ł����");//0
        manual_list.Add("reflector�͍��E�̖��L�[\n�Ō�����ς�����\nR�L�[�Œ����ɖ߂��");//1
        manual_list.Add("C�L�[�������Œe�𑕓U\n������xC�L�[�������Ɣ��ˁI");//2
        manual_list.Add("�X�y�[�X�L�[�Ŏ��_��\n�؂�ւ��邱�Ƃ��ł����");//3
        manual_list.Add("m�L�[�Ń`���[�g���A��\n�ɖ߂��Ă�����I");//4
        manual_list.Add("PUSH�@P�@PLAY\n�@PUSH�@B�@BACK\n�@(PUSH�@N�@NEXT)");//5//PLAY�͂ł��Ă�
    }

    // Update is called once per frame
    public void Update()
    {   // �I�u�W�F�N�g����Text�R���|�[�l���g���擾
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
        if (mcW == true && mcA == true && mcS == true && mcD == true)
        {
            MC++;
            mcW = false; mcA = false; mcS = false; mcD = false;
        }
        //MC == 1
        if (Input.GetKeyDown("r") && MC == 1) { mcR = true; }
        if (Input.GetKeyDown("left") && MC == 1) { mcLeft = true; }
        if (Input.GetKeyDown("right") && MC == 1) { mcRight = true; }
        if (mcR == true && mcLeft == true && mcRight == true)
        {
            MC++;
            mcR = false; mcLeft = false; mcRight = false;
        }
        //MC == 2
        if (MC == 2)
        {
            if(Pushing == LongPress)
            {
                mcHold = true;
            }
            if (mcHold == true && Input.GetKeyDown("C"))
            {
                MC++;
                mcHold = false;Pushing = 0;
            }
            if (Input.GetKey("C"))
            {
                Pushing = Pushing + 1;
            }
            if (Input.GetKeyUp("C"))
            {
                Pushing = 0;
            }

        }
        //MC == 3
        //Camera�̐؂�ւ��� Camera_controller �Ő؂�ւ�������

    }
}
