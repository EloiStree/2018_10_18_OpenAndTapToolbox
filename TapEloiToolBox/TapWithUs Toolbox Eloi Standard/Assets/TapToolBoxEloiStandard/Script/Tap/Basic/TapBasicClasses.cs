




using System;

[System.Serializable]
public class HandedTapValue : TapValue {

    public HandType m_handType;

    public HandedTapValue(HandType hand, int id):base(id)
    {
        m_handType = hand;
    }
    public HandedTapValue(HandType hand, TapCombo combo):base(combo)
    {
        m_handType = hand;
    }


    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;
        if (this.GetType() != obj.GetType()) return false;

        HandedTapValue p = (HandedTapValue)obj;
        return ((this.m_combo == p.m_combo) && (this.m_handType == p.m_handType) );
    }

    public override int GetHashCode()
    {
        return -1184375416 + m_handType.GetHashCode();
    }

    public override string ToString()
    {
        return m_handType + "-" + base.ToString();
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
        if (this.GetType() != obj.GetType()) return false;

        TapValue p = (TapValue)obj;
        return (this.m_combo == p.m_combo);
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return m_combo.ToString();
    }

    public bool IsFingerActive(int index)
    {
        index = UnityEngine.Mathf.Clamp(index, 0, 4);
        string combo = m_combo.ToString();
        return combo[index+3]!='_';
    }
}
public enum HandType { Left, Right }
public enum TapCombo : int
{
    T00O____ = 0,
    T01_O___ = 1,
    T02__O__ = 2,
    T03___O_ = 3,
    T04____O = 4,
    T05OO___ = 5,
    T06_OO__ = 6,
    T07__OO_ = 7,
    T08___OO = 8,
    T09O_O__ = 9,
    T10_O_O_ = 10,
    T11__O_O = 11,
    T12O__O_ = 12,
    T13_O__O = 12,
    T14O___O = 14,
    T15OOO__ = 15,//Taken: Shift
    T16_OOO_ = 16,
    T17__OOO = 17,//Taken: Switch
    T18OO_O_ = 18,
    T19O_OO_ = 19,
    T20OO__O = 20,
    T21_O_OO = 21,
    T22_OO_O = 22,
    T23O__OO = 23,
    T24O_O_O = 24,
    T25_OOOO = 25,
    T26O_OOO = 26,
    T27OO_OO = 27,
    T28OOO_O = 28,
    T29OOOO_ = 29,
    T30OOOOO = 30


}