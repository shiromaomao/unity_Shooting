using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPsensor : MonoBehaviour
{
    //î≠éÀë‰Ç…Ç»Ç¢Ç∆ÅAêVÇµÇ¢ãÖÇ™èoÇπÇ»Ç¢

    bool isS = false;
    int STeleport = 0;//(0 notTP /1 TPcheck /2 SphereTP!!)
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SphereCheck");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Sphere" || col.gameObject.tag == "ESphere")
        {
            isS = true;//ã Ç†ÇË
            STeleport = 0;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Sphere" || col.gameObject.tag == "ESphere")
        {
            isS = false;//íeñ≥Çµ         
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
