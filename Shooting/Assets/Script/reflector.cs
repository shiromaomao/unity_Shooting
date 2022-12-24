using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reflector : MonoBehaviour
{
    private Vector3 player_position;
   
    private Vector3 player_rotation;
    // Update is called once per frame
    void Update()
    {
        player_position.x = transform.position.x;
        player_position.y = transform.position.y;      
        player_rotation.y = transform.localEulerAngles.y;

        if (Input.GetKey("w"))
        {
            player_position.y = Mathf.Clamp(transform.position.y + 0.15f, 2, 8);
        }
        if (Input.GetKey("s"))
        {
            player_position.y = Mathf.Clamp(transform.position.y - 0.15f, 2, 8);
        }
        if (Input.GetKey("a"))
        {
            player_position.x = Mathf.Clamp(transform.position.x - 0.2f, -10, 10);
        }
        if (Input.GetKey("d"))
        {
            player_position.x = Mathf.Clamp(transform.position.x + 0.2f, -10, 10);
        }
        transform.position = new Vector3(player_position.x, player_position.y, -22);
        if (Input.GetKey("r"))
        {
            transform.position = new Vector3(0, 5, -22);
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //330     335      340                   20      25      30
        //         -------------------------------                  右
        //                  ------------------------------　　　　　左
        if (Input.GetKey("left"))//-20~20で動かしたい　
        {                                                               
            if (transform.localEulerAngles.y <= 25 || transform.localEulerAngles.y >= 340)
            {
                transform.Rotate(0, -2, 0);
            }
        }

        if (Input.GetKey("right"))
        {
            if (transform.localEulerAngles.y <= 20 || transform.localEulerAngles.y >= 335)
            {
                transform.Rotate(0, 2, 0);
            }
        }
    }
}
