using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    //スクロールスピード
    float speed = 3;

    void Update()
    {
        if (GameManager.I.Phase.Value != GamePhase.InGame) return;
        //下方向に動かす
        transform.position -= new Vector3(0, Time.deltaTime * speed);

        //Yが-19.17まで下がったら、19.17まで戻す
        if (transform.position.y <= -22.17f)
        {
            transform.position = new Vector2(0, 44.2f);
        }
    }
}