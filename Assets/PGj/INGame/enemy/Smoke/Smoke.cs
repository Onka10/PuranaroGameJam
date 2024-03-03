using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    float deadTime = 1f;
    [SerializeField] SmokeAnimation smokeAnimation;
    public SettingObject data;

    private void Start()
    {
        deadTime = data.smokeDeadTime;
        smokeAnimation.StartAnime();
        Invoke("DestroyObject", deadTime);
    }

    private void DestroyObject()
    {
        // オブジェクトを破棄する
        Destroy(this.gameObject);
    }
}
