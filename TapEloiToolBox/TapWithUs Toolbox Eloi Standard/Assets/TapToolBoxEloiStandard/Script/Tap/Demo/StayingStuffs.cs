using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StayingStuffs : MonoBehaviour {


    public UI_SayingStuffs m_displayInfo;
    public HandedComboTowhatToWay[] m_comboToSaying;
    public ComboTowhatToWay[] m_comboWithUsToSaying;

    public Color m_defaultBackground = Color.white;

    public void Say(HandedTapValue value)
    {

        HandedComboTowhatToWay combo = CheckForCorresponding(value);
        if (combo != null) {
        Debug.Log("...");

            m_displayInfo.SetWith(combo.m_message, value, combo.m_color, combo.m_clip, combo.m_texture);
        }
    }
    public void SayTapWithUs(TapValue value)
    {

        ComboTowhatToWay combo = CheckForCorresponding(value);

        if (combo != null)
            m_displayInfo.SetWith(combo.m_message, value, combo.m_color, combo.m_clip, combo.m_texture);
    }

    private HandedComboTowhatToWay CheckForCorresponding(HandedTapValue value)
    {
        if (value == null)
            return null;
        HandedComboTowhatToWay[] combos = m_comboToSaying.Where(k => value.m_combo == k.m_combo.m_combo && value.m_handType == k.m_combo.m_handType).ToArray();

        Debug.Log("Try " + combos.Length + " " + value.ToString());
        if (combos.Length > 0)
            return combos[0];
        return null;
    }
    private ComboTowhatToWay CheckForCorresponding(TapValue value)
    {
        if (value == null)
            return null;
        ComboTowhatToWay[] combos = m_comboWithUsToSaying.Where(k => value.m_combo == k.m_combo.m_combo ).ToArray();

        Debug.Log("Try " + combos.Length + " " + value.ToString());
        if (combos.Length > 0)
            return combos[0];
        return null;
    }

    [System.Serializable]
    public class HandedComboTowhatToWay
    {
        public string m_message;
        public HandedTapValue m_combo;
        public Color m_color = Color.white;
        public AudioClip m_clip;
        public Texture2D m_texture;

    }
    [System.Serializable]
    public class ComboTowhatToWay
    {
        public string m_message;
        public TapValue m_combo;
        public Color m_color = Color.white;
        public AudioClip m_clip;
        public Texture2D m_texture;

    }
}


