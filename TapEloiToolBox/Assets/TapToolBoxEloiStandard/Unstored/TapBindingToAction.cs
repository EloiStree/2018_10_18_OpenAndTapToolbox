using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class TapBindingToAction : MonoBehaviour {


    [Header("On Action Event")]
    public OnBindedEvent m_onAction;
    public OnBindedHandsEvent m_onAnyAction;

    [Header("On Specific Event")]
    public OnBindedTapEvent m_onTapWithUsEvent;
    public OnBindedHandEvent m_onHandValueEvents;
    public OnBindedHandsEvent m_onHandsValueEvents;

    public bool m_displayOnlyValide ;


    [Space(30), Header("Specific Binding")]
    public BindedTapValue[] m_tapWithUsActions;
    public BindedHandTapValue[] m_handValueActions;
    public BindedHandsTapValue[] m_handsValueActions;



    public void TriggerBindedAction(TapValue value)
    {
        List<BindedTapValue> values = m_tapWithUsActions.Where(k => TapValue.AreEquals( k.m_tapValue , value)).ToList();
        if (values.Count > 0)
        {
            m_onTapWithUsEvent.Invoke(values[0].m_actionToSend, values[0].m_tapValue);
            m_onAnyAction.Invoke(values[0].m_actionToSend, TapUtility.ConvertToHandsValue(HandType.Right, values[0].m_tapValue));
            m_onAction.Invoke(values[0].m_actionToSend);
        }
        else if (!m_displayOnlyValide) {
            m_onTapWithUsEvent.Invoke("", value);
            m_onAnyAction.Invoke("", TapUtility.ConvertToHandsValue(HandType.Right, value));
        }
    }

    public void TriggerBindedAction(HandTapValue value)
    {
        List<BindedHandTapValue> values = m_handValueActions.Where(k => HandTapValue.AreEquals(k.m_tapValue, value)).ToList();
        if (values.Count > 0)
        {
            m_onHandValueEvents.Invoke(values[0].m_actionToSend, values[0].m_tapValue);
            m_onAnyAction.Invoke(values[0].m_actionToSend, TapUtility.ConvertToHandsValue(values[0].m_tapValue));
            m_onAction.Invoke(values[0].m_actionToSend);
        }
        else if (!m_displayOnlyValide)
        {
            m_onHandValueEvents.Invoke("", value);
            m_onAnyAction.Invoke("", TapUtility.ConvertToHandsValue(value));
        }
    }

    public void TriggerBindedAction(HandsTapValue value) {

        List<BindedHandsTapValue> values =  m_handsValueActions.Where(k => HandsTapValue.AreEquals(k.m_tapValue, value)).ToList();
        if (values.Count > 0) {
            m_onHandsValueEvents.Invoke(values[0].m_actionToSend, values[0].m_tapValue);
            m_onAnyAction.Invoke(values[0].m_actionToSend, value);

            m_onAction.Invoke(values[0].m_actionToSend);
        }
        else if (!m_displayOnlyValide)
        {
            m_onHandsValueEvents.Invoke("", value);
            m_onAnyAction.Invoke("", value);
        }
    }



}
[System.Serializable]
public class OnBindedEvent : UnityEvent<string>
{

}

[System.Serializable]
public class OnBindedTapEvent : UnityEvent<string, TapValue>
{

}
[System.Serializable]
public class OnBindedHandEvent : UnityEvent<string, HandTapValue>
{

}
[System.Serializable]
public class OnBindedHandsEvent : UnityEvent<string, HandsTapValue>
{

}



[System.Serializable]
public class BindTriggeredAction {
    public string m_actionToSend;
}

[System.Serializable]
public class BindedTapValue : BindTriggeredAction
{
    public TapValue m_tapValue = new TapValue(TapCombo.T_____);
}
[System.Serializable]
public class BindedHandTapValue : BindTriggeredAction
{
    public HandTapValue m_tapValue = new HandTapValue(HandType.Right, TapCombo.T_____);

}
[System.Serializable]
public class BindedHandsTapValue : BindTriggeredAction
{
    public HandsTapValue m_tapValue = new HandsTapValue(TapCombo.T_____, TapCombo.T_____);

}
