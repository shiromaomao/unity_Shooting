using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    bool opendoor = false;

    public GameObject Door;

    private void OnTriggerExit(Collider col)
    {
        Debug.Log(col.gameObject.name); // ぶつかった相手の名前を取得

        if (col.gameObject.tag == "Sphere" || col.gameObject.tag == "ESphere")
        {
            Debug.Log("rb = T");
            opendoor = true;
            Door.gameObject.SendMessage("Open");
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
