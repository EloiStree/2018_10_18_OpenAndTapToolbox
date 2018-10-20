using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapKeyboardSimulator : TapSimulator
{
    public KeyCode[] m_fingers= new KeyCode[] {
        KeyCode.A,
        KeyCode.Z,
        KeyCode.E,
        KeyCode.R,
        KeyCode.V,
        KeyCode.N,
        KeyCode.U,
        KeyCode.I,
        KeyCode.O,
        KeyCode.P
    };

    public void SetWithAzerty() {
        m_fingers = new KeyCode[] {
        KeyCode.A,
        KeyCode.Z,
        KeyCode.E,
        KeyCode.R,
        KeyCode.V,
        KeyCode.N,
        KeyCode.U,
        KeyCode.I,
        KeyCode.O,
        KeyCode.P
    };
    }
    public void SetWithQuerty()
    {
        m_fingers = new KeyCode[] {
        KeyCode.Q,
        KeyCode.W,
        KeyCode.E,
        KeyCode.R,
        KeyCode.V,
        KeyCode.N,
        KeyCode.U,
        KeyCode.I,
        KeyCode.O,
        KeyCode.P
    };
    }

    public override bool IsOn(FingerIndex fingerId)
    {
        return Input.GetKey(m_fingers[(int)fingerId]);
    }

    
}
