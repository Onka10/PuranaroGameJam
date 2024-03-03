using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public float framesPerSecond = 10f; // アニメーションのフレームレート
    public Sprite[] fire; // アニメーションに使用する画像の配列
    public Sprite[] eat; // アニメーションに使用する画像の配列
    public Sprite[] damage; // アニメーションに使用する画像の配列
    public Sprite[] normal; // アニメーションに使用する画像の配列

    private Sprite[] currentFrames;
    private int currentFrameIndex;
    private float nextFrameTime;
    private bool isPlayingAnimation;

    private void Start()
    {
        currentFrames = normal; // 最初はfireのアニメーションを再生する
        currentFrameIndex = 0;
        nextFrameTime = Time.time;
        isPlayingAnimation = false;
    }

    private void Update()
    {
        if (isPlayingAnimation)
        {
            if (Time.time >= nextFrameTime)
            {
                // 次のフレームに切り替える
                currentFrameIndex = (currentFrameIndex + 1) % currentFrames.Length;
                spriteRenderer.sprite = currentFrames[currentFrameIndex];

                // 次のフレームの時間を計算する
                float frameDuration = 1f / framesPerSecond;
                nextFrameTime += frameDuration;

                // アニメーション終了時にnormalに戻す
                if (currentFrameIndex == currentFrames.Length - 1)
                {
                    currentFrames = normal;
                    spriteRenderer.sprite = currentFrames[0];
                    isPlayingAnimation = false;
                }
            }
        }
    }

    public void PlayFireAnimation()
    {
        currentFrames = fire;
        currentFrameIndex = 0;
        nextFrameTime = Time.time;
        isPlayingAnimation = true;
    }

    public void PlayEatAnimation()
    {
        currentFrames = eat;
        currentFrameIndex = 0;
        nextFrameTime = Time.time;
        isPlayingAnimation = true;
    }

    public void PlayDamageAnimation()
    {
        currentFrames = damage;
        currentFrameIndex = 0;
        nextFrameTime = Time.time;
        isPlayingAnimation = true;
    }
}
