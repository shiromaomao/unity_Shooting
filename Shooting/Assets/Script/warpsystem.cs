using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpsystem : MonoBehaviour
{
    int count= 0;
    private void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name); // ぶつかった相手の名前を取得
        if (col.gameObject.tag == "Block")
        {
            if (count == 10)
            {
                transform.position = new Vector3(17, 34, -3);
                count = 0;
            }
            count += 1;
        }
    }
                                        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
