using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reflector : MonoBehaviour
{
    float TRY = 0;

    private Vector3 player_position;
   
    private Vector3 player_rotation;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        player_position.x = transform.position.x;
        player_position.y = transform.position.y;
       
        player_rotation.y = transform.localEulerAngles.y;

        //移動(x 12から-12  y 1.275から8.75)
        //player_position.x = Mathf.Clamp(player_position.x, -12, 12);
        //player_position.y = Mathf.Clamp(player_position.y, -8.75f, 1.275f);

        if (Input.GetKey("w"))
        {
            player_position.y = Mathf.Clamp(transform.position.y + 0.15f, 1.275f, 8.75f);

        }
        if (Input.GetKey("s"))
        {
            player_position.y = Mathf.Clamp(transform.position.y - 0.15f, 1.275f, 8.75f);
        }

        if (Input.GetKey("a"))
        {
            player_position.x = Mathf.Clamp(transform.position.x - 0.2f, -12, 12);
        }

        if (Input.GetKey("d"))
        {
            player_position.x = Mathf.Clamp(transform.position.x + 0.2f, -12, 12);
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
                Debug.Log(transform.localEulerAngles.y.ToString());//とても小さい値が出ている
                //player_rotation.y = Mathf.Clamp(transform.localEulerAngles.y - 0.5f, 340, 20);
            }
        }

        if (Input.GetKey("right"))
        {
            if (transform.localEulerAngles.y <= 20 || transform.localEulerAngles.y >= 335)
            {
                transform.Rotate(0, 2, 0);
                //player_rotation.y = Mathf.Clamp(transform.localEulerAngles.y + 0.5f, 340, 20);
            }
        }
    }
}
