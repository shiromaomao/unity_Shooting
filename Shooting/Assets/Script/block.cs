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
        if (Input.GetKey("n"))//��t�����i�S�����H�j
        {
            Destroy(this.gameObject);
            block_clone.blockList.Clear();//Clear == �S����
        }
    }
    public void Break()
    {
        //�u���b�N������
        Destroy(this.gameObject);
        block_clone.blockList.Remove(name);
    }

}