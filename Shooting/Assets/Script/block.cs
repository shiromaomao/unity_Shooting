using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("n"))//二フラム（全消し？）
        {
            Destroy(this.gameObject);
            block_clone.blockList.Clear();//Clear == 全消し
        }
    }
    public void Break()
    {
        //ブロックを消す
        Destroy(this.gameObject);
        block_clone.blockList.Remove(name);
    }

}