using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        //OnBecameInvisibleはMonoBehaviourに含まれているのをオーバーライド
        //カメラのレンダリングの範囲から消えたら物体を消す
        Destroy(gameObject);
        //いきなりゲームオブジェクトはアタッチされているゲームオブジェクト
        //自分自身（弾丸）が消える
    }
   
}
