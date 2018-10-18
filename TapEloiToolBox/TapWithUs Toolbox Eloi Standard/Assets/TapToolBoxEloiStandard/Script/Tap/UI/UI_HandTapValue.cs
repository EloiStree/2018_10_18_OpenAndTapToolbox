using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HandTapValue : MonoBehaviour {


    public UI_TapValue m_left;
    public UI_TapValue m_right;

    public void Set(HandedTapValue value, bool withReset=true) {

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
}
