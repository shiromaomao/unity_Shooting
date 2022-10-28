using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayManual : MonoBehaviour
{
    //配列作ってぶっこむ
    public GameObject manual_object = null;

    public static int MC = 0;//ManualCount

    bool mcW = false;//0    //mc = manual check
    bool mcA = false;//0
    bool mcS = false;//0
    bool mcD = false;//0
    bool mcLeft = false;//1
    bool mcRight = false;//1
    bool mcR = false;//1
    bool MC2 = false;//2

    List<string> manual_list = new List<string>();

    // Start is called before the first frame update
    void Start()// \n (バックスラッシュ＋ｎで改行)PCによってはバックスラッシュがお金のマークになる
    {
        manual_list.Add("水色の板reflectorは\nWASDで上下移動ができるよ");//0
        manual_list.Add("reflectorは左右の矢印キー\nで向きを変えれるよ\nRキーで中央に戻るよ");//1
        manual_list.Add("Cキー長押しで弾を装填\nもう一度Cキーを押すと発射！");//2
        manual_list.Add("スペースキーで視点を\n切り替えることができるよ");//3
        manual_list.Add("mキーでチュートリアル\nに戻ってこれるよ！");//4
        manual_list.Add("PUSH　P　PLAY\n　PUSH　B　BACK\n　(PUSH　N　NEXT)");//5//PLAYはできてる
    }

    // Update is called once per frame
    public void Update()
    {
        //MC2 = LPsensor.MC2pass;//from LPsensor

        if (Input.GetKey("m"))
        {
            MC = 0;//ManualCount

            mcW = false;//0    //mc = manual check
            mcA = false;//0
            mcS = false;//0
            mcD = false;//0
            mcLeft = false;//1
            mcRight = false;//1
            mcR = false;//1
            MC2 = false;//2
        }
        // オブジェクトからTextコンポーネントを取得
        Text manual_text = manual_object.GetComponentInChildren<Text>();

        manual_text.text = manual_list[MC];
        //説明文を作って、条件達成で後に行けるようにしたい
        //0.1　プレイヤーの移動方法　、2　弾の装填と発射　、3　カメラの変更　、4　マニュアルに戻る方法
        // テキストの表示を入れ替える
        if (Input.GetKeyDown("n") && MC < 5)//test用
        {
            MC++;
        }
        if (Input.GetKeyDown("b") && MC > 0)//back
        {
            MC--;
        }
        //MC == 0
        if (Input.GetKeyDown("w") && MC == 0) { mcW = true; }
        if (Input.GetKeyDown("a") && MC == 0) { mcA = true; }
        if (Input.GetKeyDown("s") && MC == 0) { mcS = true; }
        if (Input.GetKeyDown("d") && MC == 0) { mcD = true; }
        if (mcW == true && mcA == true && mcS == true && mcD == true)
        {
            MC++;
            mcW = false; mcA = false; mcS = false; mcD = false;
        }
        //MC == 1
        if (Input.GetKeyDown("r") && MC == 1) { mcR = true; }
        if (Input.GetKeyDown("left") && MC == 1) { mcLeft = true; }
        if (Input.GetKeyDown("right") && MC == 1) { mcRight = true; }
        if (mcR == true && mcLeft == true && mcRight == true)
        {
            MC++;
            mcR = false; mcLeft = false; mcRight = false;
            Debug.Log("M1comp");
        }
        //MC == 2
        if (MC2 == true)//LPsensorで判別する
        {
            MC++;
            MC2 = false;
        }
        //MC == 3
        //Cameraの切り替えは Camera_controller で切り替えをする

    }
}
