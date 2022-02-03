using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private GameManager gm;

    private void OnCollisionEnter(Collision coll)
        //テストで書けるように
    {
        if (coll.gameObject.tag == "Bullet")
        {
            gm.SetScore(gm.GetScore() + 1);
            Destroy(gameObject, 0.1f);
        }
        if (coll.gameObject.tag == "floor")
        {
            Debug.Log("ok");
            gm.SetMsg("GameOver");
        }
    }
    public void SetGameManager(GameManager gm)
    {
        this.gm = gm;
    }
}
