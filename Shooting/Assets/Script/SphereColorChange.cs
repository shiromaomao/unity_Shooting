using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColorChange : MonoBehaviour
{
    public Material Spherecolor;

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name); // ‚Ô‚Â‚©‚Á‚½‘ŠŽè‚Ì–¼‘O‚ðŽæ“¾
        if (col.gameObject.tag == "Sphere" || col.gameObject.tag == "ESphere")
        {
            GetComponent<Renderer>().material.color = Spherecolor.color;
        }
    }
    /*private void OnDestroy()
    {
        if (Spherecolor != null)
        {
            Destroy(Spherecolor);
        }
    }*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
