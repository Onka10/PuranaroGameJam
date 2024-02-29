using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    float deadTime = 1f;
    //public SettingObject data;
    [SerializeField] SmokeAnimation smokeAnimation;

    private void Start()
    {
        smokeAnimation.StartAnime();
        Invoke("DestroyObject", deadTime);
    }

    private void DestroyObject()
    {
        // オブジェクトを破棄する
        Destroy(this.gameObject);
    }
}
