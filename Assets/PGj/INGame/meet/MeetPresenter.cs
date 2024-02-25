using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetPresenter : MonoBehaviour
{
    public float speed = 5f; // 移動速度

    private void Start()
    {
        Invoke("DestroyObject", 5);
    }

    void Update()
    {
        // 毎フレーム右方向に移動する
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void DestroyObject()
    {
        // オブジェクトを破棄する
        Destroy(gameObject);
        //DestroyImmediate(gameObject, true);
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
