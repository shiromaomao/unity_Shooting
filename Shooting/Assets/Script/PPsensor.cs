using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPsensor : MonoBehaviour
{
    public GameObject Partition_Pole;
    private void OnTriggerExit (Collider col)
    {
        if (col.gameObject.tag == "Sphere" || col.gameObject.tag == "ESphere")// ぶつかった相手の名前を取得
        {
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
