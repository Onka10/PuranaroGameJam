using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    float deadTime = 1f;
    public GameObject meat;  // 肉
    [SerializeField] SmokeAnimation smokeAnimation;

    private void Start()
    {
        smokeAnimation.StartAnime();
        Invoke("DestroyObject", deadTime);
    }

    private void DestroyObject()
    {
        Instantiate(meat, transform.position, Quaternion.identity);
        // オブジェクトを破棄する
        Destroy(this.gameObject);
    }
}
