using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugging : MonoBehaviour {

    public GameObject[] m_debuggingDisplay;
    public bool m_debuggingState;

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SwitchDebuggingMode();
        }	
	}
    public void Awake()
    {
        SetDebuggingTo(m_debuggingState);
    }

    private void SwitchDebuggingMode()
    {
        SetDebuggingTo(!m_debuggingState);
    }

    private void SetDebuggingTo(bool state)
    {
        m_debuggingState = state;
        for (int i = 0; i < m_debuggingDisplay.Length; i++)
        {
            m_debuggingDisplay[i].SetActive(state);

        }
    }

    public void OnValidate()
    {
        SetDebuggingTo(m_debuggingState);
    }
}
