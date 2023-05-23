using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_skill : MonoBehaviour
{
  //åªèÛñäÑÇ»Çµ
}



/*

    private void TouchedBlock(Collision col)
    {
        if (col.string.tag == "Block")
        {
            if (count >= 20)
            {
                transform.position = new Vector3(17, 48, -3);
                count = 0;
            }
            count += 1;
            col.string.GetComponent<block>().Break();
        }

        if (col.string.tag == "blockBomb")
        {
            if (count >= 20)
            {
                transform.position = new Vector3(17, 48, -3);
                count = 0;
            }
            count += 5;
            col.string.GetComponent<block>().Break();
        }

        if (col.string.tag == "blockFreeze")
        {
            if (count >= 20)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
                StartCoroutine("Freeze");
            }
            count -= 3;
            col.string.GetComponent<block>().Break();
        }

        if (col.string.tag == "blockBarrier")
        {
            if (count >= 20)
            {
                transform.position = new Vector3(17, 48, -3);
                count = 0;
            }
            count += 1;
            col.string.GetComponent<block>().Barrier();
        }

        if (col.string.tag == "blockAnnihilation")
        {
            transform.position = new Vector3(17, 48, -3);
            count = 0;
            col.string.GetComponent<block>().Break();
        }
    }
    public IEnumerator Freeze()
    {
        yield return (3);
        transform.position = new Vector3(17, 48, -3);
        BallHP = 0;
        rb.constraints = RigidbodyConstraints.None;//å≈íËâèú
    }
}*/
