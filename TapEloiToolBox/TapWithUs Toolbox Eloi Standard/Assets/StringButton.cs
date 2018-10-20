using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StringButton : MonoBehaviour , IPointerDownHandler{


    public string m_stringStored;
    public OnSelected m_onTriggered;
    public Text m_label;
    public void OnPointerDown(PointerEventData eventData)
    {
        m_onTriggered.Invoke(m_stringStored);
    }
    [System.Serializable]
    public class OnSelected : UnityEvent<string>
    {
       
    }


    public void SetContent(string content) {
        m_stringStored = content;
        m_label.text = content;
    }
}
