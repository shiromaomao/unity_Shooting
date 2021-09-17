using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reflector : MonoBehaviour
{
    private Vector3 player_position;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    //ˆÚ“®(x 12‚©‚ç-12  y 1.275‚©‚ç8.75)
    /*void Clamp()
    {
        player_position.x = transform.position.x;
        player_position.y = transform.position.y;

        player_position.x = Mathf.Clamp(player_position.x, 12, -12);
        player_position.y = Mathf.Clamp(player_position.y, 1.275f, -8.75f);
    }*/
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.position += transform.up * 0.025f;
        }

        if (Input.GetKey("s"))
        {
            transform.position -= transform.up * 0.025f;
        }

        if (Input.GetKey("a"))
        {
            transform.position -= transform.right * 0.05f;
        }

        if (Input.GetKey("d"))
        {
            transform.position += transform.right * 0.05f;
        }
    }
}
