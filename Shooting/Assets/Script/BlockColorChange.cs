using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColorChange : MonoBehaviour
{
    public GameObject blockPrefab;//Prefabのblock
    public block blockscript;

    bool CC = false;//CC == ColorChange
    int ACCB = 0;//ACCB == After ColorChange Blocks

    // Start is called before the first frame update
    void Start()
    {
        blockscript = blockPrefab.GetComponent<block>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColorChange()
    {
        CC = true;
    }

    private void OnTriggerStay(Collider col)
    {
        Debug.Log(col.gameObject.name); // ぶつかった相手の名前を取得

        if (blockscript.BB <= 990) //残存block(50未満の場合、緊急生産)の20%(最低10個)を色替えする
        {
           
        }
        else
        {
           // BlockControl.gameobject.SendMessage("EBC");//Emergency Block Clone
            //BlockControl.gameObject
        }

        if (CC == true && col.gameObject.tag == "block")
        {

        }
        //　ランダムで10個のブロックを抽出。色を敵の体の大部分を構成している色に変えて、ブロックの耐久値を増やす。
        //　足りない場合は、10個になるようにblock_cloneで増やす。

        //　もし今後スコア制を導入するなら、色付き +500 、色付き全破壊 +500*X体目 。通常は、100とかで
        //　さらに時間制限も設けるなら、色付き全破壊で +1;00　。
    }
}
