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

    public static List<GameObject> ESphereList = new List<GameObject>();//共有できるにするようにする

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
                Debug.Log("ESphere"+ i);               //  i 番目の要素を表示
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
        ESphereList.Add(ES);//GameObjectをリストに入れる
        return ES;//作ったやつをメソッドの前に返り値として送る
    }
}
