using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugTapToText : MonoBehaviour {


    public Text m_debug;


	public void Display (HandedTapValue value) {
        if(m_debug && value!=null)
            m_debug.text =  value.ToString()+ "\n" + m_debug.text;

    }

    public void Display(TapValue value)
    {
        if (m_debug && value != null)
            m_debug.text = value.ToString() + "\n" + m_debug.text;

    }
}
