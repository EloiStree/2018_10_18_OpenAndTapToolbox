using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SayingStuffs : MonoBehaviour {


    [Header("Params")]
    public Text m_textDisplayer;
    public Image m_backgroundColor;
    public AudioSource m_audioSource;
    public RawImage m_illustrativeImage;
    public AspectRatioFitter m_illustrativeRatio;

    [Header("Tap viewer")]
    public UI_TapValue m_tapHand;
    public UI_HandTapValue m_eloiHand;


    public void SetWith(string textToDisplay, TapValue handValue, Color color,  AudioClip audio = null, Texture2D image=null)
    {
        SetCommunValues(textToDisplay, color, audio, image);


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

    private void SetCommunValues(string textToDisplay, Color color, AudioClip audio, Texture2D image)
    {
        m_textDisplayer.text = textToDisplay;
        m_backgroundColor.color = color;
        m_audioSource.clip = audio;
        if (m_illustrativeImage && m_illustrativeRatio)
        {
            m_illustrativeImage.texture = image;
            m_illustrativeRatio.aspectRatio = image.width / (float)image.height;

        }

        if (m_audioSource.clip != null)
        { m_audioSource.Play(); }
    }

    public void SetWith(string textToDisplay, HandedTapValue handValue, Color color, AudioClip audio = null, Texture2D image = null)
    {


        SetCommunValues(textToDisplay, color, audio, image);

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
