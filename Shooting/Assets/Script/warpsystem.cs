using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpsystem : MonoBehaviour
{
    //warp‚Æsphere‚É‚Â‚¢‚Ä

    int count = 0;

    bool opendoor = false;

    public GameObject Door;
    public GameObject block;

    public Rigidbody rb;

    public Material red;
    public Material black;

    int BBC = 0;//BlockBreakCount
    
    private void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name); // ‚Ô‚Â‚©‚Á‚½‘ŠŽè‚Ì–¼‘O‚ðŽæ“¾
        if (col.gameObject.tag == "Block")
        {
            if (count >= 20)
            {
                transform.position = new Vector3(17, 48, -3);
                count = 0;
            }
            count += 1;

            col.gameObject.GetComponent<block>().Break();
        }

        if (col.gameObject.tag == "reflector")
        {
            count -= 1;
        }

        if(col.gameObject.tag == "Wall")
        {
            rb.useGravity = false;
            Debug.Log("rb = F");
        }
    }

    private void OnTriggerExit (Collider col)
    {
        Debug.Log(col.gameObject.name); // ‚Ô‚Â‚©‚Á‚½‘ŠŽè‚Ì–¼‘O‚ðŽæ“¾


        if (col.gameObject.tag == "Sensor")
        {
            Debug.Log("rb = T");
            opendoor = true;
            Door.gameObject.SendMessage("Open");
        }

        /*if (opendoor == true && col.gameObject.tag == "Sensor")
        {
            Door.gameObject.SendMessage("Open");
        }*/

        if (col.gameObject.tag == "RigidbodyGrant")
        {
            rb.useGravity = true;
            Debug.Log("rb = T");

            if (gameObject.GetComponent<Renderer>().material != black)
            {
                gameObject.GetComponent<Renderer>().material = black;
            }
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
            transform.position = new Vector3(15, 48, 0);
        }
    }
}
