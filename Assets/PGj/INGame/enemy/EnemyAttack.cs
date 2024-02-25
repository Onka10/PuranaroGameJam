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
    private int attackinterval=2;
    private IDisposable _disposable;
    public SettingObject data;

    private void Start()
    {
        //攻撃
        _disposable = Observable.Interval(TimeSpan.FromSeconds(attackinterval))
            .Subscribe(_ => Fire());

        forceMagnitude = data.enemyForceMagnitude;
        attackinterval = data.attackinterval;
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
