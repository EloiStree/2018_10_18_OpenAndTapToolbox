using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TapSimulator : MonoBehaviour {

    public float m_commitDelay=0.3f;

    [Header("Event (Touch)")]
    public OnValueDetected m_onValueDetected;
    public OnHandedValueDetected m_onHandedDetected;

    [Header("Debug (Touch)")]
    public bool m_isListening;
    public float m_countDown;

    [SerializeField]
    TapValue lastTapLeft, lastTapRight;

    public  abstract bool IsOn(FingerIndex fingerIndex);
    public bool [] m_hands;


    private void Awake()
    {
        m_hands = new bool[10];
    }
    private void Update()
    {
        bool anyFingerDown = IsAnyFingersPressing();
        if (anyFingerDown) {
            m_countDown = m_commitDelay;
            m_isListening = true;
            RefreshFingersState();
        }

        if (m_isListening && !anyFingerDown) {
            m_countDown -= Time.deltaTime;
            if (m_countDown < 0f) {
                NotifyTap();
                m_countDown = 0f;
                m_isListening = false;
            }
        }
    }

    private void NotifyTap()
    {
        // I AM HERE 
        TapUtility.GetTapValueFrom(m_hands, out  lastTapLeft, out  lastTapRight);
        Debug.Log(lastTapLeft + " - " + lastTapRight);

        if (lastTapLeft != null && lastTapLeft.m_combo != TapCombo.T99_____)
        {

            m_onValueDetected.Invoke(lastTapLeft);
            m_onHandedDetected.Invoke(new HandedTapValue(HandType.Left, lastTapLeft.m_combo));
        }
        if (lastTapRight!=null && lastTapRight.m_combo != TapCombo.T99_____)
        {
            m_onValueDetected.Invoke(lastTapRight);
            m_onHandedDetected.Invoke(new HandedTapValue(HandType.Right, lastTapRight.m_combo));
        }

        m_hands = new bool[10];
    }

    private bool[] GetFingersState()
    {
        bool[] fingers = new bool[10];
        for (int i = 0; i < 10; i++)
        {
            if(!fingers[i])
                fingers[i] =  IsOn((FingerIndex)i);
        }
        return fingers;
    }
    private void RefreshFingersState()
    {
        for (int i = 0; i < 10; i++)
        {
            if (!m_hands[i])
                m_hands[i] = IsOn((FingerIndex)i);
        }
    }

    private bool IsAnyFingersPressing()
    {
        for (int i = 0; i < 10; i++)
        {
            if(IsOn( (FingerIndex)i ))
                return true;
        }
        return false;
    }
}
