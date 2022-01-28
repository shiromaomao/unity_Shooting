using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    public void Open ()
    {
        StartCoroutine("OD");
    }

    private IEnumerator OD ()
    {
        BoxCollider col = GetComponent<BoxCollider>();
        col.isTrigger = true;
        yield return new WaitForSeconds(0.75f);
        col.isTrigger = false;
    }
}
