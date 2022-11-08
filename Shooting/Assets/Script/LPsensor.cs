using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPsensor : MonoBehaviour
{
    //発射台にないと、新しい球が出せない

    bool isS = false;
    public static bool MC2pass = false;
    int STeleport = 0;//(0 notTP /1 TPcheck /2 SphereTP!!)
    int ManualNum = 0;
    int ManuCheck = 0;
    int Cpush = 0;
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
            if (Cpush >= 2 && ManuCheck >= 3)//二回押したとき and 弾が発射されたら
            {
                MC2pass = true;
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Sphere" || col.gameObject.tag == "ESphere")
        {
            isS = true;//玉あり
            STeleport = 0;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Sphere" || col.gameObject.tag == "ESphere")
        {
            isS = false;//弾無し         
        }
    }

    public GameObject Sphere;

    public IEnumerator SphereCheck()//(0 notTP /1 TPcheck /2 SphereTP!!)
    {
        if (isS == false)
        {     
            yield return new WaitForSeconds(10);
            STeleport ++;
        }

        if (STeleport == 1 && isS == false)
        {
            STeleport++;
        }

        if (STeleport == 2)
        {
            Sphere.gameObject.SendMessage("ReputS3");
            STeleport = 0;
        }
    }
}
