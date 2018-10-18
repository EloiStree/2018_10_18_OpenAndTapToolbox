using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TapValue : MonoBehaviour
{
    public Toggle[] m_combo = new Toggle[5];

    internal void SetWith(TapValue value)
    {
        if (value == null)
            return;
        for (int i = 0; i < 5; i++)
        {
            m_combo[i].isOn = (value.IsFingerActive(i));
        }
    }
}