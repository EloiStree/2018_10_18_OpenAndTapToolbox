using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SayingStuffs : MonoBehaviour {


    [Header("Params")]
    public Text m_textDisplayer;
    public Image m_backgroundColor;

    [Header("Tap viewer")]
    public UI_TapValue m_tapHand;
    public UI_HandTapValue m_eloiHand;
    public SoundLibrary m_audioLibrary;


    public void SetWith(string textToDisplay, TapValue handValue, Color color,  string  audio = null)
    {
        SetCommunValues(textToDisplay, color, audio);


        DeactivateAll();
        if (m_tapHand)
        {
            SetComboDisplay(true);
            m_tapHand.SetWith(handValue);
        }

        
    }

    private void DeactivateAll()
    {
        m_eloiHand.gameObject.SetActive(false);
        m_tapHand.gameObject.SetActive(false);
    }

    private void SetCommunValues(string textToDisplay, Color color, string audioFileName = null)
    {
        m_textDisplayer.text = textToDisplay;
        m_backgroundColor.color = color;
        m_audioLibrary.PlayInFolder(audioFileName);
        
    }

    public void SetWith(string textToDisplay, HandedTapValue handValue, Color color, string audio = null)
    {


        SetCommunValues(textToDisplay, color, audio );

        DeactivateAll();
        if (m_eloiHand)
        {
            SetComboDisplay(false);
            m_eloiHand.Set(handValue);
        }

    }
    

    private void SetComboDisplay(bool oneHand)
    {
        m_tapHand.gameObject.SetActive(oneHand);
        m_eloiHand.gameObject.SetActive(!oneHand);
    }
}
