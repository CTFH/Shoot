using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour//継承はコロン
{
    public GameObject prefab;
    void Update()//updateの直前に動くのがStart
    {
        if(Input.GetMouseButtonDown(0))//入力関係はinput
            //0はマウス左クリック　1は右クリック　3は真ん中
        {
            //引数一つでInstantiate
            //プレハブで作ったものをゲームに登場させるのがinstantiate
            //if文が無かったら1秒間に60回instantiate
            GameObject obj = Instantiate(prefab);

            //親要素設定（今回はカメラ)
            //shooterはカメラにアタッチされているので
            //いきなりトランスフォームはカメラのトランスフォームコンポーネント
            //子は弾丸　obj弾丸
            obj.transform.parent = transform;
            
            //親要素からのオフセットは0　
            //カメラの子要素（弾丸）　カメラとのズレ0＝カメラと同じ位置に弾丸くる
            obj.transform.localPosition = Vector3.zero;
            
            //メインカメラからマウスクリックした地点にray（光線）を飛ばす（結局光線は軌道ってこと）
            //Camera.mainはメインカメラというタグが付与されたから
            //（Camera.mainでMainCameraというタグがついているカメラを引っ張ってくる）
            //ScreenPointToRay...input.mousePositionに向けてのカメラから光線
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            //rayの方向を長さ1にして dirに代入
            //ray.direction　ray型（光線）からVector3型のベクトルに変わる
            //normalized長さを1にする（真ん中クリックしたときより端クリックしたときのほうが遅くなる
            //ということがないようにする。弾の速さ均一）
            Vector3 dir = ray.direction.normalized;
            
            //生成したObjのrigidbodyを取得し、速度をdir方向に与える
            //飛ばすのはAddForceかVelocityかの2択
            //弾丸のrigidbodyにアクセスして、そのVelocity（速度成分）に代入
            //Velocityはプロパティなので代入して使う
            //弾丸ベクトルに100をかける
            obj.GetComponent<Rigidbody>().velocity = dir * 100.0f;
            //obj.GetComponent<Rigidbody>().AddForce(dir*100f,Forcemode.Impulse);
            //↑メソッドで飛ばす方法　AddForceは力を加える
            //（現実世界はAddForce）
            //Forcemode.Impulse瞬時に力を加える
        }
    }
}
