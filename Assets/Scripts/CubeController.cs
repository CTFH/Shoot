using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private GameManager gm;//Null
    //cubeは最初にヒエラルキーにいないからpublicにできない
    //（find系は簡単だけどコストが高い）

    private void OnCollisionEnter(Collision coll)
        //ぶつかったときに走らせたいときに使用する
        //引数にぶつかってきた相手が入る
        //テストで書けるように
    {
        if (coll.gameObject.tag == "Bullet")
        {
            gm.SetScore(gm.GetScore() + 1);
            //gmは点数管理している　
            //gm.GetScoreで現在のスコア、に1点足したものをセットする
            Destroy(gameObject, 0.1f);
            //消すまでの時間を第2引数に設定できる
            //いきなりゲームオブジェクトはスクリプトがアタッチされているゲームオブジェクト（キューブ）
            //消えるのはキューブ
        }
        if (coll.gameObject.tag == "floor")
        {
            Debug.Log("ok");
            gm.SetMsg("GameOver");
        }
    }
    public void SetGameManager(GameManager gm)//セッター
    {
        this.gm = gm;
    }
}
