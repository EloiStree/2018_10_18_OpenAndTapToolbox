using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UI_HandsTapValue : MonoBehaviour {
    
    public UI_TapValue m_left;
    public UI_TapValue m_right;

    public void SetWith(HandTapValue value, bool withReset=true) {

        if (value.m_handType == HandType.Left)
        {
            m_left.SetWith(value);
            if (withReset)
                m_right.SetWith(null);
        }
        else if (value.m_handType == HandType.Right) {
            m_right.SetWith(value);

            if (withReset)
                m_left.SetWith(null);
        }
    }

    internal void SetWith(HandsTapValue value)
    {
        m_left.SetWith(value.GetHand(HandType.Left));
        m_right.SetWith(value.GetHand(HandType.Right));
    }

    internal void Clear()
    {
        m_left.Clear();
        m_right.Clear();
    }
}
