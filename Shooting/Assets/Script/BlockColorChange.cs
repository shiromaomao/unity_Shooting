using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColorChange : MonoBehaviour
{
    public GameObject blockPrefab;//Prefab��block
    public block blockscript;

    bool CC = false;//CC == ColorChange
    int ACCB = 0;//ACCB == After ColorChange Blocks

    // Start is called before the first frame update
    void Start()
    {
        blockscript = blockPrefab.GetComponent<block>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColorChange()
    {
        CC = true;
    }

    private void OnTriggerStay(Collider col)
    {
        Debug.Log(col.gameObject.name); // �Ԃ���������̖��O���擾

        if (blockscript.BB <= 990) //�c��block(50�����̏ꍇ�A�ً}���Y)��20%(�Œ�10��)��F�ւ�����
        {
           
        }
        else
        {
           // BlockControl.gameobject.SendMessage("EBC");//Emergency Block Clone
            //BlockControl.gameObject
        }

        if (CC == true && col.gameObject.tag == "block")
        {

        }
        //�@�����_����10�̃u���b�N�𒊏o�B�F��G�̑̂̑啔�����\�����Ă���F�ɕς��āA�u���b�N�̑ϋv�l�𑝂₷�B
        //�@����Ȃ��ꍇ�́A10�ɂȂ�悤��block_clone�ő��₷�B

        //�@��������X�R�A���𓱓�����Ȃ�A�F�t�� +500 �A�F�t���S�j�� +500*X�̖� �B�ʏ�́A100�Ƃ���
        //�@����Ɏ��Ԑ������݂���Ȃ�A�F�t���S�j��� +1;00�@�B
    }
}
