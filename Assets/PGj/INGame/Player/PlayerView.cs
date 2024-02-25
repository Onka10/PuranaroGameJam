using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerView : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Canvas canvas;
    [SerializeField] TMP_Text fly;

    public void ShowCanvas()
    {
        canvas.enabled = true;
    }

    public void HideCanvas()
    {
        canvas.enabled = false;
    }

    public void SetSlider(float n)
    {
        slider.value = n;
    }

    public void SetScore(int n)
    {
        fly.text = n.ToString();
    }
}
