using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesControl : MonoBehaviour
{
    public GameObject BlockControl;

    public GameObject Enemy1;

    bool IFon= false;//if�̕s�������p
    int kC = 0;//      �������p   killcount
    int IFKC = 0;//    if�̓����������p  IFkillcondition

    // Start is called before the first frame update
    void Start()
    {
        IFon = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(IFon = true && kC == IFKC)
        {
            IFon = false;
            IFKC += 1;
            StartCoroutine("Battle");
        }
    }

    public IEnumerator Battle ()
    {
        yield return new WaitForSeconds(300f);//300f�҂�//test type 10f
        BlockControl.gameObject.SendMessage("ColorChange");
        Enemy1.gameObject.SendMessage("Encount");
    }
}
