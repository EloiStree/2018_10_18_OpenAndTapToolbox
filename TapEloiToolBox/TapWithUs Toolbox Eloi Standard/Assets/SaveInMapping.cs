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
	// Use this for initialization
	public void SaveBindingToMapping ( ) {
        bool isValide = IsAllValide();
        m_valide.color = isValide ? Color.green : Color.green;

        

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
