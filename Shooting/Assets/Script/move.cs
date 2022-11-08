using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    int x = 0;
    int z = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int x = 0; x == 60; x++)
        {
            gameObject.transform.position = new Vector3(x, 0, z);
        }
        for (int z = 0; z == 60; z++)
        {
            gameObject.transform.position = new Vector3(x, 0, z);
        }
        for (int x = 0; x == -60; x--)
        {
            gameObject.transform.position = new Vector3(x, 0, z);
        }
        for (int z = 0; z == -60; z--)
        {
            gameObject.transform.position = new Vector3(x, 0, z);
        }

    }
}
