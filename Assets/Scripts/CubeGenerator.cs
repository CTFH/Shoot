using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject prefab;//ヒエラルキーにいる者同士なのでpublicに設定可能
    public GameManager gm;
    void Start()
    {
        StartCoroutine(Create());
    }
    //コルーチンで生成を行う
    IEnumerator Create()//Iはinterface enumerator
    {
        //生成間隔の初期値
        float delta = 1.5f;//1.5秒間間毎の差分のこと（にキューブを出したい）
        while (true)
        {
            GameObject obj = Instantiate(
                prefab,//何を
                new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(8.0f, 12.0f), Random.Range(-2.0f, 3.0f)),
                //どこに（ランダム）floatのとき端含む　intは端含まない
                Quaternion.identity//どの向きで
                );
            //GameManagerをセットする。
            obj.GetComponent<CubeController>().SetGameManager(gm);
            //セッターにGM参照が入っているので渡す
            //キューブにもゲームマネジャーの参照が到着する
            //obj=cube(上のinstantiateでcubeを作ってる）
            //cubeControllerはCubeについている
            //GMスコアを管理できるようにしたい
            
            //生成間隔時間停止
            yield return new WaitForSeconds(delta);

            //徐々に生成間隔を早める
            if (delta > 0.5f)
            {
                delta -= 0.05f;
            }
        }
    }
    
}
