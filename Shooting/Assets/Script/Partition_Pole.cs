using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partition_Pole : MonoBehaviour
{
    int Rx = 0;

    bool move = true;

    //’e‚Ì’Ç‰Á
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void WithoutSphere()
    {
        Debug.Log("Signal");
        if(move == true)
        {
            move = false;

            StartCoroutine("PPmove");
        }
    }

    private IEnumerator PPmove()
    {

        for (int i = 0; i < 10; i++)
        {
            Rx += 12;
            yield return new WaitForSeconds(0.25f);
        }
        move = true;

    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log("Rx:" + Rx);
        transform.rotation = Quaternion.Euler(Rx, 0, 0);

        if(Rx == 1200)
        {
            Rx = 0;
        }
    }
}
