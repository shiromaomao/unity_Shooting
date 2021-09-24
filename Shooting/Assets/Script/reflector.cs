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


    // Update is called once per frame
    void Update()
    {
        player_position.x = transform.position.x;
        player_position.y = transform.position.y;

        //ˆÚ“®(x 12‚©‚ç-12  y 1.275‚©‚ç8.75)
        //player_position.x = Mathf.Clamp(player_position.x, -12, 12);
        //player_position.y = Mathf.Clamp(player_position.y, -8.75f, 1.275f);

        if (Input.GetKey("w"))
        {
            //transform.position += transform.up * 0.025f;
            player_position.y = Mathf.Clamp(transform.position.y + 0.075f, 1.275f, 8.75f);

        }
        if (Input.GetKey("s"))
        {
            //transform.position -= transform.up * 0.025f;
            player_position.y = Mathf.Clamp(transform.position.y - 0.075f, 1.275f, 8.75f);
        }

        if (Input.GetKey("a"))
        {
            //transform.position -= transform.right * 0.05f;
            player_position.x = Mathf.Clamp(transform.position.x - 0.1f, -12, 12);
        }

        if (Input.GetKey("d"))
        {
            //transform.position += transform.right * 0.05f;
            player_position.x = Mathf.Clamp(transform.position.x + 0.1f, -12, 12);
        }

        transform.position = new Vector3(player_position.x, player_position.y, -22);

    }
}
