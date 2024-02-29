using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

public class PlayerCore : Singleton<PlayerCore>,IDamage2Player
{
    public SettingObject data;

    float MaxManpuku = 100;
    float haraheri = 10f;
    float manpuku=-1;
    float invincibleTime = 2f; //無敵時間
    [SerializeField] PlayerView playerView;
    [SerializeField] PlayerEffectView view;
    private float startTime;
    public int score;
    Collider2D _collider2D;
    bool invincible = false;

    void Start()
    {
        haraheri = data.haraheri;
        MaxManpuku = data.maxHealth;
        invincibleTime = data.invincibleTime;

        GameManager.I.Phase
            .Where(p => p == GamePhase.InGame)
            .Subscribe(_ => {
                // ゲーム開始時の時間を記録
                startTime = Time.time;
                playerView.ShowCanvas();
            })
            .AddTo(this);


        GameManager.I.Phase
            .Where(p => p == GamePhase.Result)
            .Subscribe(_ => {
                transform.position = new Vector3(-1f,- 3f, 0);
            })
            .AddTo(this);

        _collider2D = this.gameObject.GetComponent<Collider2D>();   
    }

    private void Update()
    {
        if (GameManager.I.Phase.Value != GamePhase.InGame) return;
        manpuku -= Time.deltaTime * haraheri;
        playerView.SetSlider(manpuku);
        playerView.SetScore((int) (Time.time - startTime) );

        if(manpuku > 0) return;
        GameOver(); 

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //念のためロック
        if (GameManager.I.Phase.Value != GamePhase.InGame) return;

        // 肉をとったのであれば
        if (!other.TryGetComponent(out MeetPresenter meet)) return;

        manpuku += 10;
        manpuku = Mathf.Clamp(manpuku, 0, MaxManpuku);
        meet.Destroy();
    }


    void GameOver()
    {
        score = ((int)(Time.time - startTime));
        //playerView.HideCanvas();
        GameManager.I.NextPhase();
    }

    public void InitGame()
    {
        manpuku = MaxManpuku;
        playerView.SetSlider(manpuku);
        playerView.SetScore(0);
    }

    /// <summary>
    /// ダメージを受ける
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        if(invincible) return;

        manpuku -= damage;
        PlayerSE.I.Damage();
        view.StartBlinkWithAutoStop(invincibleTime);
        StartCoroutine(DisableColliderForSeconds(invincibleTime));
    }

    /// <summary>
    /// 無敵処理
    /// </summary>
    private IEnumerator DisableColliderForSeconds(float seconds)
    {
        // Colliderを無効にする
        invincible = true;

        // 指定された秒数待機
        yield return new WaitForSeconds(seconds);

        // Colliderを有効にする
        invincible = false;
    }
}
