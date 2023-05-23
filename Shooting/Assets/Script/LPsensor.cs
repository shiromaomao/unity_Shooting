using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPsensor : MonoBehaviour
{
    //”­ŽË‘ä‚É‚È‚¢‚ÆAV‚µ‚¢‹…‚ªo‚¹‚È‚¢

    bool isS = false;
    public static bool MC2pass = false;
    int STeleport = 0;//(0 notTP /1 TPcheck /2 SphereTP!!)
    int ManualNum = 0;
    int ManuCheck = 0;
    int Cpush = 0;

    public GameObject PP;
    public GameObject LPvalve;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SphereCheck");
    }

    // Update is called once per frame
    void Update()
    {
        ManualNum = PlayManual.MC;
        if (Input.GetKey("m"))
        {
            MC2pass = false;
            ManuCheck = 0;
            Cpush = 0;
        }
        if (isS == false)
        {
            if (ManuCheck == 0)
            {
                ManuCheck++;
            }
            if (ManuCheck == 2)
            {
                ManuCheck++;
            }
        }
        if (isS == true && ManuCheck == 1)
        {
            ManuCheck++;
        }
        if (ManualNum == 2)//MC==2
        {
            if (Input.GetKeyDown("c"))
            {
                Cpush++;
            }
            if (Cpush >= 2 && ManuCheck >= 3)//“ñ‰ñ‰Ÿ‚µ‚½‚Æ‚« and ’e‚ª”­ŽË‚³‚ê‚½‚ç
            {
                MC2pass = true;
            }
        }
        else
        {
            MC2pass = false;
            ManuCheck = 0;
            Cpush = 0;
        }


        if (Input.GetKeyDown("c"))
        {
            StartCoroutine("SphereCheck");
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Sphere" || col.gameObject.tag == "ESphere" || col.gameObject.tag == "sphere3")
        {
            isS = true;//‹Ê‚ ‚è
            STeleport = 0;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Sphere" || col.gameObject.tag == "ESphere" || col.gameObject.tag == "sphere3")
        {
            isS = false;//’e–³‚µ         
        }
    }

    public GameObject Sphere;

    public IEnumerator SphereCheck()//(0 notTP /1 TPcheck /2 SphereTP!!)
    {
        if (isS == false)
        {
            Debug.Log("noSphere");
            yield return new WaitForSeconds(10);
            STeleport ++;
        }

        if (STeleport == 1 && isS == false)
        {
            STeleport++;
        }

        if (STeleport == 2)
        {
            PP.GetComponent<Partition_Pole>().PPmove();
            LPvalve.GetComponent<valve>().OPENtheGATE();
            //Sphere.gameObject.SendMessage("ReputS3");
            STeleport = 0;
        }
    }
}
