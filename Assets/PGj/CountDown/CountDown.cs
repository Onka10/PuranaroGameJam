using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    int countdownTime = 3; // カウントダウンの初期値
    [SerializeField] CountDownView view;
    [SerializeField] PlayerCore core;


    void Start()
    {
        GameManager.I.Phase
            .Where(p => p==GamePhase.Load)
            .Subscribe(_ => {
                canvas.enabled = true;
                BGMManager.I.Stopped();
                //初期化
                core.InitGame();

                StartCoroutine(StartCountdown());
                })
            .AddTo(this);
    }

    System.Collections.IEnumerator StartCountdown()
    {
        // カウントダウンが0になるまで繰り返す
        while (countdownTime > 0)
        {
            SystemSE.I.Count();
            view.SetTime(countdownTime.ToString());
            yield return new WaitForSeconds(1); // 1秒待つ
            countdownTime--; // カウントダウンの値を減らす
        }

        // カウントダウン終了時の処理
        //Debug.Log("カウントダウン終了");
        SystemSE.I.Go();
        GameManager.I.NextPhase();
        canvas.enabled = false;
        countdownTime = 3;
        BGMManager.I.InGame();
    }
}
