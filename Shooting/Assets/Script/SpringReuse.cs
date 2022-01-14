using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringReuse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            transform.position = new Vector3(16.4f, 10.5f, 10.74f);
        }
    }
}
