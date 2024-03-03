using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MeetPresenter : MonoBehaviour
{
    public float speed = 5f; // 移動速度
    float deadTime = 7f;
    public SettingObject data;
    private bool isMoving = false;
    double smokeTime;

    private void Start()
    {
        smokeTime = data.smokeDeadTime;
        speed = data.meatSpeed;
        Invoke("DestroyObject", deadTime+(float)smokeTime);

        // 3秒後に移動を開始する
        Observable.Timer(System.TimeSpan.FromSeconds(smokeTime))
            .Subscribe(_ => isMoving = true)
            .AddTo(this);
    }

    void Update()
    {
        if (isMoving)
        {
            // 毎フレーム右方向に移動する
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
