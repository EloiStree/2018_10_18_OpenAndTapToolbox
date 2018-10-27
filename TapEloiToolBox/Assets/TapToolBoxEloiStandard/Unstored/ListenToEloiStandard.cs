using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenToEloiStandard : MonoBehaviour, ITapListener
{

    public string m_context="Eloi Standard";
    public bool IsListening()
    {
        return m_listenToEloiStandard;
    }

    public void SetListenerTo(bool on)
    {
        m_listenToEloiStandard = on;
    }

    public void Switch()
    {
        SetListenerTo(!IsListening());
    }


    public bool m_listenToEloiStandard = true;
    public OnHandValueDetected m_onHandComboDetected;

  

    void Update()
    {

        string input = Input.inputString;
        if (input.Length > 0)
        {
            foreach (char c in input.ToCharArray())
            {
                if (m_listenToEloiStandard)
                {

                    HandTapValue eloiValue = TapUtility.GetTapBasedOnEloiStandard(c);
                    m_onHandComboDetected.Invoke(eloiValue);
                }
            }
        }
    }

    public string GetName()
    {
        return m_context;
    }
}

public interface ITapListener {

    void SetListenerTo(bool setOn);
    bool IsListening();
    void Switch();
    string GetName();
}
