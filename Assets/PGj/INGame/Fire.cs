using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Fire : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    protected virtual void Awake() 
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // 当たり判定があったときに呼ばれるメソッド
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        // ダメージを与えられる物であれば
        if (!other.TryGetComponent(out IDamage2Enemy attack)) return;
        attack.Damage(1);
    }

    // オブジェクトがアタッチされたときに呼ばれるメソッド
    public void Vanish(float n)
    {
        if (n >= 1) Invoke("DestroyObject", n);
    }

    // 指定した秒数後に呼び出されるメソッド
    private void DestroyObject()
    {
        // オブジェクトを破棄する
        Destroy(gameObject);
        //DestroyImmediate(gameObject, true);
    }

    /// <summary>
    /// 速度を設定するメソッド
    /// </summary>
    /// <param name="speed"></param>
    public void SetVelocity(Vector3 speed)
    {
        _rigidbody2D.velocity = speed;
    }

    /// <summary>
    /// 重力の影響を受けるかどうかを設定するメソッド
    /// </summary>
    /// <param name="gravityScale"></param>
    public void SetGravityScale(float gravityScale)
    {
        _rigidbody2D.gravityScale = gravityScale;
    }

    /// <summary>
    /// 力を加えるメソッド
    /// </summary>
    /// <param name="force"></param>
    /// <param name="mode"></param>
    public void AddForce(Vector3 force, ForceMode2D mode)
    {
        _rigidbody2D.AddForce(force, mode);
    }
}
