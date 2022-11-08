using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class valve : MonoBehaviour
{
    bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            transform.position = new Vector3(16.4f, 12.09f, 0);
        }
        else
        {
            transform.position = new Vector3(16.4f, 12.09f, -2.35f);
        }
    }
}
