using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using TMPro;

public class ResultPresenter : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject finish;
    [SerializeField] GameObject score;
    private bool canExecute = false;
    [SerializeField] TMP_Text textMeshPro;
    [SerializeField] PlayerCore core;


    void Start()
    {
        GameManager.I.Phase
            .Where(p => p == GamePhase.Result)
            .Subscribe(_ => {
                canvas.enabled = true;
                StartCoroutine(StartCountdown());
            })
            .AddTo(this);
    }

    void Update()
    {
        // スペースキーが押され、実行が許可されている場合にログを出力
        if (canExecute && Input.GetKeyDown(KeyCode.Space))
        {
            ReTry();
        }
    }

    System.Collections.IEnumerator StartCountdown()
    {
        //スコア更新
        textMeshPro.text = core.score.ToString();
        
        canvas.enabled = true;
        yield return new WaitForSeconds(2); // 2秒待つ
        Debug.Log("1秒");
        
        finish.SetActive(false);
        score.SetActive(true);
        canExecute = true;
    }

    void ReTry()
    {
        // リトライ
        GameManager.I.ReTry();
        canvas.enabled = false;
        canExecute = false;
    }
}
