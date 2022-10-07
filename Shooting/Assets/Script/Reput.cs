using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reput : MonoBehaviour
{
   // public GameObject Sphere3;
    public Rigidbody rb;
    public void ReputS3()//from  "LPsensor"
    {
        transform.position = new Vector3(16.4f,14,-2.35f);
        Debug.Log("Step Reput");
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
