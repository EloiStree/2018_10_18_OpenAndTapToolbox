using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ListenToTapValue : MonoBehaviour, ITapListener
{

    public string m_context = "Tap Withs Us";
    public bool IsListening()
    {
        return m_listenToTapWithUsStandard;
    }

    public void SetListenerTo(bool on)
    {
        m_listenToTapWithUsStandard = on;
    }

    public void Switch()
    {
        SetListenerTo(!IsListening());
    }
    public string GetName()
    {
        return m_context;
    }

    [SerializeField]
    bool m_listenToTapWithUsStandard=true;
    public OnTapValueDetected m_onTapWithUsDetected;



    void Update () {

        string input = Input.inputString;
        if (input.Length > 0) {
            foreach (char c in input.ToCharArray())
            {
                if (m_listenToTapWithUsStandard)
                {
                    TapValue tapValue = TapUtility.GetTapBasedOnTapWithUsStandard(c);
                    m_onTapWithUsDetected.Invoke(tapValue);
                }
            }
        }
    }
}

[System.Serializable]
public class OnHandsValueDetected : UnityEvent<HandsTapValue> { }
[System.Serializable]
public class OnHandValueDetected : UnityEvent<HandTapValue> { }
[System.Serializable]
public class OnTapValueDetected : UnityEvent<TapValue> { }
