using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpsystem : MonoBehaviour
{
    int count= 0;
    private void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name); // ‚Ô‚Â‚©‚Á‚½‘ŠŽè‚Ì–¼‘O‚ðŽæ“¾
        if (col.gameObject.tag == "Block")
        {
            if (count == 10)
            {
                transform.position = new Vector3(17, 34, -3);
                count = 0;
            }
            count += 1;
        }
    }
                                        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -5)
        {
            transform.position = new Vector3(15, 35, 0);
        }
    }
}
