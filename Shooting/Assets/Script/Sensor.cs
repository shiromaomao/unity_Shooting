using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    bool opendoor = false;

    public GameObject Door;

    private void OnTriggerExit(Collider col)// ‚Ô‚Â‚©‚Á‚½‘ŠŽè‚Ì–¼‘O‚ðŽæ“¾
    {
        if (col.gameObject.tag == "Sphere" || col.gameObject.tag == "ESphere")
        {
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
