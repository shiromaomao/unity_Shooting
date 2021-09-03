using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reflector : MonoBehaviour
{
    private Vector3 player_postion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ˆÚ“®(x 12‚©‚ç-12  y 1.275‚©‚ç8.75)
        




        if (Input.GetKey("w"))
        {
            transform.position += transform.up * 0.025f;
        }


        if (Input.GetKey("s"))
        {
            transform.position -= transform.up * 0.025f;
        }

        if (Input.GetKey("a"))
        {
            transform.position -= transform.right * 0.05f;
        }

        if (Input.GetKey("d"))
        {
            transform.position += transform.right * 0.05f;
        }
    }
}
