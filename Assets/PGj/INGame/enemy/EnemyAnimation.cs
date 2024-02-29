using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Sprite[] frames; // アニメーションに使用する画像の配列
    public float framesPerSecond = 10f; // アニメーションのフレームレート

    [SerializeField] private SpriteRenderer spriteRenderer;
    private int currentFrameIndex;

    private void Start()
    {
        currentFrameIndex = 0;
        StartCoroutine(Animate());
    }

    // アニメーションのループを制御するCoroutine
    private IEnumerator Animate()
    {
        while (true) // 無限ループ
        {
            // 現在のフレームをセット
            spriteRenderer.sprite = frames[currentFrameIndex];

            // 次のフレームへ移動
            currentFrameIndex = (currentFrameIndex + 1) % frames.Length;

            // 次のフレームまで待機
            yield return new WaitForSeconds(1f / framesPerSecond);
        }
    }

    public void Flip()
    {
        spriteRenderer.flipX = true;
    }
}