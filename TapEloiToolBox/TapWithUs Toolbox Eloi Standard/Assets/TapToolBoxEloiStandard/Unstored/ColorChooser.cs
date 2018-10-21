using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChooser : MonoBehaviour {

    public Slider m_slider;
    public Image m_debug;


    public void Update()
    {
        m_debug.color = GetColorSelected();
    }

    public Color GetColorOfRainbow(float pct) {
        if (pct < 0.2f)
            return Color.Lerp(Color.red, Color.yellow, pct * 5);
        if (pct < 0.4f)
            return Color.Lerp(Color.yellow, Color.green, (pct - 0.2f) * 5);
        if (pct < 0.6f)
            return Color.Lerp(Color.green, Color.cyan, (pct - 0.4f) * 5);
        if (pct < 0.8f)
            return Color.Lerp(Color.cyan, Color.blue, (pct - 0.6f) * 5);
        if (pct < 1f)
            return Color.Lerp(Color.blue, Color.magenta, (pct - 0.8f) * 5);
        return  Color.black;
    }

    public Color GetColorSelected() {
        return GetColorOfRainbow(m_slider.value);
    }
}
