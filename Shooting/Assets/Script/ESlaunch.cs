using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*private Transform reflector;
reflector = GetComponentInParent<Transform>();
reflector.transform.position*/
public class ESlaunch : MonoBehaviour
{
    public GameObject ESphere;
    
    int ESLcount = 0;
    int num = 0;

    public static List<GameObject> ESphereList = new List<GameObject>();//���L�ł���ɂ���悤�ɂ���

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if(num > 0 )
        {
            for (int i = 0; i < ESphereList.Count; ++i)
            {
                Debug.Log("ESphere"+ i);               //  i �Ԗڂ̗v�f��\��
            }
        }
    }

    public GameObject ESl()
    {
        GameObject ES;
        num++;

        ES = GameObject.Instantiate (ESphere);
        ES.transform.position = transform.position;
        ES.GetComponent<Rigidbody>().AddForce(transform.forward* 1000);
        ESphereList.Add(ES);//GameObject�����X�g�ɓ����
        return ES;//�����������\�b�h�̑O�ɕԂ�l�Ƃ��đ���
    }
}
