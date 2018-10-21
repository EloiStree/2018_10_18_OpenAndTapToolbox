using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveInMapping : MonoBehaviour {
    public ColorChooser m_colorChooser;
    public InputField m_name;
    public InputField m_textDisplay;
    public Toggle[] m_fingers= new Toggle[10];
    public InputField m_soundName;

    public Image m_valide;

    public StayingStuffs m_sayingStuffs;
	// Use this for initialization
	public void SaveBindingToMapping ( ) {
        bool isValide = IsAllValide();
        m_valide.color = isValide ? Color.green : Color.green;
        if (isValide) {
            TapValue left, right;
            TapUtility.GetTapValueFrom(GetBools(), out left, out right);
            if (left.m_combo != TapCombo.T99_____)
            {
                m_sayingStuffs.Add(m_name.text, m_textDisplay.text, m_colorChooser.GetColorSelected(),HandType.Left, left, m_soundName.text);

            }
            if (right.m_combo != TapCombo.T99_____)
            {
                m_sayingStuffs.Add(m_name.text, m_textDisplay.text, m_colorChooser.GetColorSelected(), HandType.Right, right, m_soundName.text);

            }
            

            m_sayingStuffs.Save();
        }
    }
    public bool[] GetBools() {
        bool [] fingersState = new bool[10];
        for (int i = 0; i < 10; i++)
        {
            fingersState[i] = m_fingers[i].isOn;

        }
        return fingersState;


    }

    private bool IsAllValide()
    {
        if (string.IsNullOrEmpty(m_name.text))
            return false;
        if (string.IsNullOrEmpty(m_textDisplay.text))
            return false;
        if (string.IsNullOrEmpty(m_soundName.text))
            return false;

        return true;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
