using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetPresenter : MonoBehaviour
{
    public float speed = 5f; // 移動速度
    float deadTime = 7f;
    public SettingObject data;

    private void Start()
    {
        speed = data.meatSpeed;
        Invoke("DestroyObject", deadTime);
    }

    void Update()
    {
        // 毎フレーム右方向に移動する
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
