




using System;



[System.Serializable]
public class HandsTapValue {

    public TapValue m_leftCombo;
    public TapValue m_rightCombo;

    public HandsTapValue(TapCombo left, TapCombo right) {
        m_leftCombo = new TapValue(left);
        m_rightCombo = new TapValue(right);
    }

    public HandTapValue GetHand(HandType handType) {
        if(handType==HandType.Left)
            return new HandTapValue(handType, m_leftCombo.m_combo);
        else
            return new HandTapValue(handType, m_rightCombo.m_combo);
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        HandsTapValue p = (HandsTapValue)obj;
        return AreEquals(p, this);
    }

    public override int GetHashCode()
    {
        return -1184375416 + m_leftCombo.GetHashCode() + m_rightCombo.GetHashCode()  ;
    }

    public override string ToString()
    {
        return m_leftCombo.GetDescription() + " "+ m_rightCombo.GetDescription();
    }
    public static bool AreEquals(HandsTapValue a, HandsTapValue b)
    {
        if (a == null || b == null)
            return false;
        return ((a.m_leftCombo.m_combo == b.m_leftCombo.m_combo) && (a.m_rightCombo.m_combo == b.m_rightCombo.m_combo));
    }

}

[System.Serializable]
public class HandTapValue : TapValue {

    public HandType m_handType;

    public HandTapValue(HandType hand, int id):base(id)
    {
        m_handType = hand;
    }
    public HandTapValue(HandType hand, TapCombo combo):base(combo)
    {
        m_handType = hand;
    }


    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        HandTapValue p = (HandTapValue)obj;
        return AreEquals(p, this);
    }
    public static bool AreEquals(HandTapValue a, HandTapValue b)
    {
        if (a == null || b == null)
            return false;
        return (a.m_combo == b.m_combo) && (a.m_handType == b.m_handType);
    }
    public override int GetHashCode()
    {
        return -1184375416 + m_handType.GetHashCode();
    }

    public override string ToString()
    {
        return m_handType + "-" + GetDescription();
    }
}

[System.Serializable]
public class TapValue
{
    public TapValue(int id)
    {
        m_combo = (TapCombo)id;
    }
    public TapValue(TapCombo combo)
    {
        m_combo = combo;
    }
    public TapCombo m_combo;

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        TapValue p = (TapValue) obj;
        return AreEquals(p, this);
    }

    public static bool AreEquals(TapValue a, TapValue b) {
        if (a == null || b == null)
            return false;
        return a.m_combo == b.m_combo;
    }
 
    public override string ToString()
    {
        return m_combo.ToString();
    }

    public string GetDescription() {
        return m_combo.ToString().Substring(1);
    }

    public bool IsFingerActive(int index)
    {
        index = UnityEngine.Mathf.Clamp(index, 0, 4);
        string combo = GetDescription();
        return combo[index]!='_';
    }
}
public enum HandType { Left, Right }
public enum FingerIndex : int {
    LeftPinky=0,
    LeftRing = 1,
    LeftMiddle = 2,
    LeftIndex = 3,
    leftThumb = 4,
    RightThumb = 5,
    RightIndex = 6,
    RightMiddle = 7,
    RightRing = 8,
    RighPinky = 9
}
public enum TapCombo : int
{
    T_____ = -1,
    TO____ = 0,
    T_O___ = 1,
    T__O__ = 2,
    T___O_ = 3,
    T____O = 4,
    TOO___ = 5,
    T_OO__ = 6,
    T__OO_ = 7,
    T___OO = 8,
    TO_O__ = 9,
    T_O_O_ = 10,
    T__O_O = 11,
    TO__O_ = 12,
    T_O__O = 12,
    TO___O = 14,
    TOOO__ = 15,//Taken: Shift
    T_OOO_ = 16,
    T__OOO = 17,//Taken: Switch
    TOO_O_ = 18,
    TO_OO_ = 19,
    TOO__O = 20,
    T_O_OO = 21,
    T_OO_O = 22,
    TO__OO = 23,
    TO_O_O = 24,
    T_OOOO = 25,
    TO_OOO = 26,
    TOO_OO = 27,
    TOOO_O = 28,
    TOOOO_ = 29,
    TOOOOO = 30


}