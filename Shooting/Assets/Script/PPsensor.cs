using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPsensor : MonoBehaviour
{
    public GameObject Partition_Pole;
    private void OnTriggerExit (Collider col)
    {
        Debug.Log(col.gameObject.name); // �Ԃ���������̖��O���擾
        if (col.gameObject.tag == "Sphere" || col.gameObject.tag == "ESphere")
        {
            Debug.Log("BSignal");
            Partition_Pole.SendMessage("WithoutSphere");
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
