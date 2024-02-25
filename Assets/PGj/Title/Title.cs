using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{

    [SerializeField] Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        // スペースキーが押されたら
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameManager.I.Phase.Value != GamePhase.Title) return;
            // タイトル終わり
            GameManager.I.NextPhase();
            canvas.enabled = false;
        }
    }
}
