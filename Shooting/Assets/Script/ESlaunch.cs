using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESlaunch : MonoBehaviour
{
    public GameObject ESphere;
    
    int ESLcount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("up") && ESLcount < 3)
        {
            ESl();
            ESLcount++;
        }
    }

    void ESl()
    {
        GameObject ES;
       
        ES = GameObject.Instantiate (ESphere);
        ES.transform.position = transform.position;
        ES.GetComponent<Rigidbody>().AddForce(transform.forward* 1000);
}
}
