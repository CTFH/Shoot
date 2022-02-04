using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GUIStyle scoreStyle;
    public GUIStyle msgStyle;
    private int score = 0;
    private string msg = "";

    void Update()
    {
        if(msg == "GameOver")
        {
            //動きを止める
            //時間の進む速度を0にする
            Time.timeScale = 0f;
            //スローモーションにするときに使う
            //Updateは動き続けているのでインスタンスの生成の処理があればインスタンスの生成は止まらない
            //ゲーム内の時間だけを止めている。ゲーム自体は止まらない
        }
    }

    private void OnGUI()//Inspectorから文字の色とか登録できるようになる
    {
        GUI.Label(new Rect(5, 5, 10, 10), score.ToString(), scoreStyle);
        //第3引数に渡すことでスタイルを設定できる（インスペクターから登録）
        GUI.Label(new Rect(Screen.width /2-150, Screen.height /2-25, 300, 50), msg, msgStyle);
        //ScreenWidth/2画面の真ん中　中点から長方形作ると右にずれるので半分戻す（‐150）
        //そこから300作る

    }
    public int GetScore()　//ゲッター
    {
        return score;
    }
    public void SetScore(int score)　//セッター
    {
        this.score = score;
    }
    public string GetMsg()
    {
        return msg;
    }
    public void SetMsg(string msg)
    {
        this.msg = msg;
    }
}
