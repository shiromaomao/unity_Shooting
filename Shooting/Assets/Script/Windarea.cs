using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windarea : MonoBehaviour
{
    int z = 0;
    int zC = 0;//zCount
    public float coefficient = 0;   // ‹ó‹C’ïRŒW”
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider col)
    {
        Vector3 velocity = new Vector3(0, -2, z);    // •—‘¬//è‘O‘¤‰º•û‚É
        zC++;
        if (zC >= 15)
        {
            z--; zC = 0;
            if(z <= -10) 
            {
                z = 0;
            }
        }
        if (col.GetComponent<Rigidbody>() == null)
        {
            return;
        }
        // ‘Š‘Î‘¬“xŒvZ
        var relativeVelocity = velocity - col.GetComponent<Rigidbody>().velocity;
        // ‹ó‹C’ïR‚ğ—^‚¦‚é
        col.GetComponent<Rigidbody>().AddForce(coefficient * relativeVelocity);
    }
}
