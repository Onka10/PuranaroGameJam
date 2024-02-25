using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

public class PlayerCore : Singleton<PlayerCore>,IDamage2Player
{
    float manpuku=100;
    [SerializeField] PlayerView playerView;
    private float startTime;
    public int score;

    void Start()
    {
        GameManager.I.Phase
            .Where(p => p == GamePhase.InGame)
            .Subscribe(_ => {
                // ゲーム開始時の時間を記録
                startTime = Time.time;
                playerView.ShowCanvas();
            })
            .AddTo(this);
    }

    private void Update()
    {
        if (GameManager.I.Phase.Value != GamePhase.InGame) return;
        manpuku -= Time.deltaTime * 10;
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
        manpuku = Mathf.Clamp(manpuku, 0, 100);
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
        manpuku = 100;
        playerView.SetSlider(manpuku);
        playerView.SetScore(0);
    }

    /// <summary>
    /// ダメージを受ける
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        manpuku -= 10;
    }
}
