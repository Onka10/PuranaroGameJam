using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeAnimation : MonoBehaviour
{
    public Sprite[] frames; // アニメーションに使用する画像の配列
    public float framesPerSecond = 120f; // アニメーションのフレームレート

    [SerializeField]private SpriteRenderer spriteRenderer;
    private int currentFrameIndex=0;

    public void StartAnime()
    {
        StartCoroutine(Animate());
    }

    // アニメーションのループを制御するCoroutine
    private IEnumerator Animate()
    {
        for (int i = 0; i < frames.Length; i++)
        {
            // 現在のフレームをセット
            spriteRenderer.sprite = frames[i];

            // 次のフレームまで待機
            yield return new WaitForSeconds(1f / framesPerSecond);
        }
    }

}