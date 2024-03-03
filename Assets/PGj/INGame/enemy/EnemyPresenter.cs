using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EnemyPresenter : MonoBehaviour, IDamage2Enemy
{
    public float speed = 5f; // 移動速度
    public GameObject smoke;  // 煙
    bool goRight=true;
    public SettingObject data;
    [SerializeField] EnemyAnimation animation;

    private void Start()
    {
        speed = data.enemySpeed;

        GameManager.I.Phase
            .Where(p => p!=GamePhase.InGame)
            .Subscribe(phase => Destroy(this.gameObject))
            .AddTo(this);
    }


    /// <summary>
    /// ダメージを受ける
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        // アイテムをドロップ
        Instantiate(smoke, transform.position, Quaternion.identity);
        // 敵を破壊
        Destroy(gameObject);
    }

    public void GoLeft()
    {
        goRight = false;
        animation.Flip();
    }

    void Update()
    {
        if (goRight)
        {
            // 毎フレーム右方向に移動する
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

    }
}
