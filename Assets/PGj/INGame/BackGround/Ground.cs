using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Ground : MonoBehaviour
{
    float speed = 3.0f; // 変化の速さ
    private bool isMoving = false; // 移動中かどうかを示すフラグ

    void Start()
    {
        GameManager.I.Phase
            .Where(p => p== GamePhase.InGame)
            .Subscribe(_ => StartCoroutine(MoveCoroutine()))
            .AddTo(this);

        GameManager.I.Phase
            .Where(p => p == GamePhase.Load)
            .Subscribe(_ => transform.position = Vector3.zero)
            .AddTo(this);
    }

    IEnumerator MoveCoroutine()
    {
        isMoving = true; // 移動中フラグをtrueに設定

        float elapsedTime = 0.0f; // 経過時間

        while (elapsedTime < 3.0f)
        {
            // 3秒間経過するまで移動を続ける
            transform.position -= new Vector3(0, Time.deltaTime * speed, 0);
            elapsedTime += Time.deltaTime;
            yield return null; // 1フレーム待つ
        }

        // 移動が終了したら位置をリセットし、移動中フラグをfalseに設定
        isMoving = false; // 移動中フラグをfalseに設定
    }
}
