using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Fire prefabToInstantiate; // インスタンス化するオブジェクト
    private float forceMagnitude = 5f; // 飛ばす力の初期値
    private IDisposable _disposable;

    private void Start()
    {
        // UniTask.Delay を使って2秒ごとにログを出すループ処理を設定し、IDisposableを取得
        _disposable = Observable.Interval(TimeSpan.FromSeconds(2))
            .Subscribe(_ => Fire());
    }

    public void Dispose()
    {
        // IDisposableを破棄することでタスクをキャンセルする
        _disposable?.Dispose();
    }

    private void OnDestroy()
    {
        // IDisposableを破棄することでタスクをキャンセルする
        Dispose();
    }


    private void Fire()
    {
        // インスペクターで指定したプレハブをインスタンス化
        var obj = Instantiate(prefabToInstantiate, transform.position, Quaternion.identity);

        // 重力の影響を受けないように設定
        obj.SetGravityScale(0f);

        // プレイヤーの方向に力を加える
        Vector3 upDirection = PlayerCore.I.transform.position;
        obj.AddForce(upDirection * forceMagnitude, ForceMode2D.Impulse);

        // デストロイ設定
        obj.Vanish(2);
    }
}
