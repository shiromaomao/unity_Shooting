using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesControl : MonoBehaviour
{
    public GameObject BlockControl;

    public GameObject Enemy1;

    bool IFon= false;//ifの不活性化用
    int kC = 0;//      討伐数用   killcount
    int IFKC = 0;//    ifの討伐数条件用  IFkillcondition

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
        yield return new WaitForSeconds(300f);//300f待つ//test type 10f
        BlockControl.gameObject.SendMessage("ColorChange");
        Enemy1.gameObject.SendMessage("Encount");
    }
}
