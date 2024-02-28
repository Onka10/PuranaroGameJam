using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffectView : MonoBehaviour
{
    /// <summary>
    /// プレイヤーの画像
    /// </summary>
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Sequence _blinkSequence;
    private Sequence _shakeSequence;

    // 点滅アニメーションの初期化
    private void Start()
    {
        InitializeBlinkAnimation();
        //InitializeShakeAnimation();
    }

    // 点滅アニメーションの初期化メソッド
    private void InitializeBlinkAnimation()
    {
        _blinkSequence = DOTween.Sequence();
        _blinkSequence.Append(spriteRenderer.DOFade(0f, 0.1f)); // 画像を非表示にする
        _blinkSequence.Append(spriteRenderer.DOFade(1f, 0.1f)); // 画像を表示する
        _blinkSequence.SetLoops(-1); // 無限ループ

        // アニメーションを開始しない（手動で開始する）
        _blinkSequence.Pause();
    }
    // 震わせアニメーションの初期化メソッド
    private void InitializeShakeAnimation()
    {
        _shakeSequence = DOTween.Sequence();
        _shakeSequence.Append(transform.DOShakePosition(1f, .2f)); // 震わせる
        _shakeSequence.SetAutoKill(false); // 手動でKillするためにAutoKillを無効化
        _shakeSequence.Pause();
    }

    /// <summary>
    /// 向きを反転する
    /// </summary>
    public void SetFlip(float direction)
    {
        spriteRenderer.flipX = direction > 0;
    }


    // 点滅アニメーションを外部から開始し、一定時間後に停止するメソッド
    public void StartBlinkWithAutoStop(float autoStopDelay)
    {
        _blinkSequence.Restart(); // アニメーションを最初から再生
        Invoke("StopBlink", autoStopDelay);
    }
    // 点滅アニメーションを外部から停止するメソッド
    public void StopBlink()
    {
        // アニメーションが途中であればKillして元の状態に戻す
        DOTween.Kill(spriteRenderer);
        spriteRenderer.color = Color.white;  // 透明度を元に戻す
        _blinkSequence.Pause();
    }



    //震わせアニメーション
    // 震わせアニメーションを外部から開始し、一定時間後に停止するメソッド
    //public void StartShakeWithAutoStop(float autoStopDelay)
    //{
    //    // アニメーションが途中であればKillして元の位置に戻す
    //    DOTween.Kill(spriteRenderer);

    //    _shakeSequence.Restart(); // アニメーションを最初から再生
    //    Invoke("StopShake", autoStopDelay);
    //}

    // 震わせアニメーションを外部から停止するメソッド
    //public void StopShake()
    //{
    //    // アニメーションが途中であればKillして元の位置に戻す
    //    DOTween.Kill(spriteRenderer);
    //    spriteRenderer.transform.localPosition = Vector3.zero; // 位置を元に戻す
    //    _shakeSequence.Pause();
    //}
}