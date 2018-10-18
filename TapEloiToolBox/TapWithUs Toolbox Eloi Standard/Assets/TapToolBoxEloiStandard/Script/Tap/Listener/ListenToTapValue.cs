using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ListenToTapValue : MonoBehaviour {


    public bool m_listenToEloiStandard=true;
    public OnHandedValueDetected m_onEloiStandardDetected;

    public bool m_listenToTapWithUsStandard=true;
    public OnValueDetected m_onTapWithUsDetected;



    public void ListenToEloiStandard(bool on)
    {
        m_listenToEloiStandard = on;
    }
    public void ListenToTapWithUsStandard(bool on)
    {
        m_listenToTapWithUsStandard = on;
    }

    void Update () {

        string input = Input.inputString;
        if (input.Length > 0) {
            foreach (char c in input.ToCharArray())
            {
                if (m_listenToEloiStandard) {

                    HandedTapValue eloiValue = TapUtility.GetTapBasedOnEloiStandard(c);
                    m_onEloiStandardDetected.Invoke(eloiValue);
                }
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
public class OnHandedValueDetected : UnityEvent<HandedTapValue> { }
[System.Serializable]
public class OnValueDetected : UnityEvent<TapValue> { }
