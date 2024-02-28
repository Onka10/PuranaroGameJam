using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    float deadTime = 0.3f;
    public SettingObject data;

    private void Start()
    {
        Invoke("DestroyObject", deadTime);
    }

    private void DestroyObject()
    {
        // オブジェクトを破棄する
        Destroy(this.gameObject);
    }
}
