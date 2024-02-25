using UnityEngine;

public class EnemyFire : Fire
{
    // 敵の攻撃のダメージ量
    public int enemyAtk = 10;
    //public SettingObject data;

    //protected override void Awake()
    //{
    //    //_rigidbody2D = GetComponent<Rigidbody2D>();
    //    enemyAtk = data.enemyAtk;
    //}

    // 継承元のOnTriggerEnter2Dメソッドをオーバーライドして敵の攻撃に関する衝突処理を行う
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        // ダメージを与えられる物であれば
        if (!other.TryGetComponent(out IDamage2Player attack)) return;
        attack.Damage(enemyAtk);
    }
}
