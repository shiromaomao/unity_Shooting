using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    public int BB = 0;//BlockBrake

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Break()
    {
        //ÉuÉçÉbÉNÇè¡Ç∑
        Destroy(this.gameObject);
        BB++;
    }

}