using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapUtilitary  {

    public static TapUtilitary Instance = new TapUtilitary();

    private static TapUtilitaryConfig m_config;


    public static TapUtilitaryConfig Configuration { get {
            if (m_config == null)
            {
                m_config = GameObject.FindObjectOfType<TapUtilitaryConfig>();
            }
            if (m_config == null)
            {
               GameObject  toCreate = Resources.Load<GameObject>("TapUtilitary");
               GameObject created = GameObject.Instantiate(toCreate);
                created.name = "#TapUtility";
                m_config = created.GetComponent<TapUtilitaryConfig>();  
            }

            return m_config;
        }
    }


    public static HandType m_userHandType = HandType.Right;
    public static OnTapValueDetected m_onTapDetected= new OnTapValueDetected();
    public static OnHandsValueDetected m_onAllTapDetected = new OnHandsValueDetected();
    public static ITapListener[] m_listeners = new ITapListener[0];


    public static void NotifyTapDetected( TapValue value)
    {
        CheckForSingleton();

        if (m_userHandType == HandType.Left)
            value.Inverse();

        HandsTapValue hands = TapUtility.ConvertToHandsValue(m_userHandType , value);

        NotifyHandsTapValueDetected(TapInputType.TapWithUs, hands);

        if (IsListeningTo(TapInputType.TapWithUs))
            m_onTapDetected.Invoke(value);
    }

   
    public static void NotifyHandsTapValueDetected(TapInputType source, HandsTapValue value)
    {
        CheckForSingleton();
        if (IsListeningTo(source))
             m_onAllTapDetected.Invoke(value);
    }


    public static void ListenTo(TapInputType inputType, bool listenOn) {

        CheckForSingleton();
        if (!m_listenerIsActive.ContainsKey(inputType))
            m_listenerIsActive.Add(inputType, listenOn);
        else m_listenerIsActive[inputType] = listenOn;
    }
    public static  bool IsListeningTo(TapInputType inputType) {

        CheckForSingleton();
        if (!m_listenerIsActive.ContainsKey(inputType))
            m_listenerIsActive.Add(inputType, false);

        return m_listenerIsActive[inputType] ;
    }
    private static Dictionary<TapInputType, bool> m_listenerIsActive = new Dictionary<TapInputType, bool>();





    public static void CheckForSingleton()
    {
        TapUtilitaryConfig config = Configuration;
    }

    internal static void SwitchListener(TapInputType tapInput)
    {
        ListenTo(tapInput, !IsListeningTo(tapInput));
    }

    internal static void SetTapHandType(HandType handType)
    {
        m_userHandType = handType;
    }
    public static void SwitchTapHand()
    {
        if (m_userHandType == HandType.Left)
            m_userHandType = HandType.Right;
        else m_userHandType = HandType.Left;

    }

    public static void SetKeyboardsToQuerty()
    {
        TapKeyboardSimulator[] keyboards = GameObject.FindObjectsOfType<TapKeyboardSimulator>();
        for (int i = 0; i < keyboards.Length; i++)
        {
            keyboards[i].SetWithQuerty();
        }
    }

    public static void SetKeyboardsToAzerty()
    {
        TapKeyboardSimulator[] keyboards = GameObject.FindObjectsOfType<TapKeyboardSimulator>();
        for (int i = 0; i < keyboards.Length; i++)
        {
            keyboards[i].SetWithAzerty();
        }
    }

    public static void StopListeningToInputs()
    {
        foreach (TapInputType input in Enum.GetValues(typeof(TapInputType)))
        {
            ListenTo(input,false);
        }
    }




    #region SET LISTERNER

    internal static void SetListeners(ITapListener[] tapListener)
    {

        foreach (ITapListener list in m_listeners)
        {
            list.RemoveListener(NotifyTapDetected);
            list.RemoveListener(NotifyHandsTapDetected);
        }

        m_listeners = tapListener;
        foreach (ITapListener list in m_listeners)
        {
            list.AddListener(NotifyTapDetected);
            list.AddListener(NotifyHandsTapDetected);
        }

    }

    private static void NotifyHandsTapDetected(ITapListener listener, TapValue value)
    {
        NotifyTapDetected(value);
    }

    private static void NotifyTapDetected(ITapListener listener, HandsTapValue value)
    {
        NotifyHandsTapValueDetected(listener.GetListenerType(), value);
    }
    #endregion
}
