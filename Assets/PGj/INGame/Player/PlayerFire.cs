using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public SettingObject data;

    [SerializeField] private Fire prefabToInstantiate; // インスタンス化するオブジェクト
    private float forceMagnitude = 13f; // 飛ばす力の初期値
    [SerializeField] private float launchInterval = 2f; // ローンチ処理を実行する間隔

    private void Start()
    {
        forceMagnitude = data.PlayerForceMagnitude;
    }

    void Update()
    {
        // スペースキーが押されたら
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameManager.I.Phase.Value != GamePhase.InGame) return;
            PlayerSE.I.Fire();
            Fire();
        }
    }

    private void Fire()
    {

        // インスペクターで指定したプレハブをインスタンス化
        var obj = Instantiate(prefabToInstantiate, transform.position, Quaternion.identity);

        // 重力の影響を受けないように設定
        obj.SetGravityScale(0f);

        // ランダムな方向に力を加える
        //var randomDirection = Random.insideUnitCircle.normalized; // ランダムな単位ベクトル
        Vector3 upDirection = Vector3.up;
        obj.AddForce(upDirection * forceMagnitude, ForceMode2D.Impulse);

        // デストロイ設定
        obj.Vanish(2);
    }

    //private void Awake()
    //{
    //    _rigidbody2D = GetComponent<Rigidbody2D>();
    //}

    //// 当たり判定があったときに呼ばれるメソッド
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    // 武器に当たった相手がダメージを与えられる相手であるか
    //    //if (!other.TryGetComponent(out IDamaged attack)) return;
    //    //attack.Damage(1);
    //}

    //// オブジェクトがアタッチされたときに呼ばれるメソッド
    //public void Vanish(float n)
    //{
    //    if (n >= 1) Invoke("DestroyObject", n);
    //}

    //// 指定した秒数後に呼び出されるメソッド
    //private void DestroyObject()
    //{
    //    // オブジェクトを破棄する
    //    Destroy(gameObject);
    //    //DestroyImmediate(gameObject, true);
    //}

    ///// <summary>
    ///// 速度を設定するメソッド
    ///// </summary>
    ///// <param name="speed"></param>
    //public void SetVelocity(Vector3 speed)
    //{
    //    _rigidbody2D.velocity = speed;
    //}

    ///// <summary>
    ///// 重力の影響を受けるかどうかを設定するメソッド
    ///// </summary>
    ///// <param name="gravityScale"></param>
    //public void SetGravityScale(float gravityScale)
    //{
    //    _rigidbody2D.gravityScale = gravityScale;
    //}

    ///// <summary>
    ///// 力を加えるメソッド
    ///// </summary>
    ///// <param name="force"></param>
    ///// <param name="mode"></param>
    //public void AddForce(Vector3 force, ForceMode2D mode)
    //{
    //    _rigidbody2D.AddForce(force, mode);
    //}

}
