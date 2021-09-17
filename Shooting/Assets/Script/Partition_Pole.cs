using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partition_Pole : MonoBehaviour
{
    bool PPC = false;

    float PPCtime = 0;
    //’e‚Ì’Ç‰Á
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("A");
        if (Input.GetKey(KeyCode.C) && transform.position.x >= 14)
        {
            Debug.Log("C");
            
            if(PPC == false)
            {
                PPC = true;
            }

            if(PPC == true)
            {
                PPCtime += Time.deltaTime;
                transform.Rotate(0, 0, 2);
            }

            if(PPCtime > 1)
            {
                PPCtime = 0;
                PPC = false;
            }
            
        }
    }
}
