using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownView : MonoBehaviour
{
    [SerializeField] TMP_Text textMeshPro;

    public void SetTime(string n)
    {
        // テキストを変更する例
        textMeshPro.text = n;
    }
}
