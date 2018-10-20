using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TapUtility : MonoBehaviour {


    public static TapValue GetTapBasedOnTapWithUsStandard(char character)
    {
        HandedTapValue value = null;
        CharacterToTapWithUsStandard[] valuesFound = TapWithUsStandard.Where(k => k.m_character == character).ToArray();
        if (valuesFound.Length > 0)
            return valuesFound[0].m_tapvalue;
        else
            return value;
        
    }
    public static HandedTapValue GetTapBasedOnEloiStandard(char character)
    {
        HandedTapValue value = null;
        CharacterToEloiStandard[] valuesFound= EloiStandard.Where(k => k.m_character == character).ToArray();
        if(valuesFound.Length>0)
            return new HandedTapValue(valuesFound[0].m_handType, valuesFound[0].m_tapValue.m_combo );
        else
            return value;
    }

    internal static void GetTapValueFrom(bool [] handsBoolState, out TapValue lastTapLeft, out TapValue lastTapRight)
    {
        char [] leftHand = new char[5];
        char [] rightHand = new char[5];
        GetTapValueAsStringFrom(handsBoolState, out leftHand, out rightHand);
        lastTapLeft= GetTapValueFrom(leftHand) ;
        lastTapRight= GetTapValueFrom(rightHand);
    }

    private static TapValue GetTapValueFrom(char[] leftHand)
    {
        foreach (TapCombo item in Enum.GetValues(typeof(TapCombo)).Cast<TapCombo>())
        {
            string itemString = item.ToString().Substring(3);
           
            if(itemString== new string(leftHand))
            {
                Debug.Log(itemString + "<>" + new string(leftHand));
                return new TapValue(item);
            }
        }
        return null;
    }

    private static void GetTapValueAsStringFrom(bool[] handsBoolState, out char[] leftHand, out char[] rightHand)
    {
        leftHand = new char[5];
        rightHand = new char[5];
        for (int i = 0; i < 10; i++)
        {
            if(i<5)
              leftHand[i] = handsBoolState[i] ? 'O' : '_';
            else
              rightHand[i-5] = handsBoolState[i] ? 'O' : '_';
        }
    }

    public struct CharacterToTapWithUsStandard
    {
        public CharacterToTapWithUsStandard(char character, TapCombo combo, int count = 1) {
            m_character = character;
            m_tapvalue = new TapValue(combo);
            m_count = count;
        }
        public char m_character;
        public TapValue m_tapvalue;
        public int m_count;

    }
    public static CharacterToTapWithUsStandard[] TapWithUsStandard = new CharacterToTapWithUsStandard[] {

        new CharacterToTapWithUsStandard('a',TapCombo.T00O____, 1),
        new CharacterToTapWithUsStandard('b',TapCombo.T13_O__O, 1),
        new CharacterToTapWithUsStandard('c',TapCombo.T26O_OOO, 1),
        new CharacterToTapWithUsStandard('d',TapCombo.T09O_O__, 1),
        new CharacterToTapWithUsStandard('e',TapCombo.T01_O___, 1),
        new CharacterToTapWithUsStandard('f',TapCombo.T18OO_O_, 1),
        new CharacterToTapWithUsStandard('g',TapCombo.T19O_OO_, 1),
        new CharacterToTapWithUsStandard('h',TapCombo.T25_OOOO, 1),
        new CharacterToTapWithUsStandard('i',TapCombo.T02__O__, 1),
        new CharacterToTapWithUsStandard('j',TapCombo.T28OOO_O, 1),
        new CharacterToTapWithUsStandard('k',TapCombo.T12O__O_, 1),
        new CharacterToTapWithUsStandard('l',TapCombo.T07__OO_, 1),
        new CharacterToTapWithUsStandard('m',TapCombo.T10_O_O_, 1),
        new CharacterToTapWithUsStandard('n',TapCombo.T05OO___, 1),
        new CharacterToTapWithUsStandard('o',TapCombo.T03___O_, 1),
        new CharacterToTapWithUsStandard('p',TapCombo.T20OO__O, 1),
        new CharacterToTapWithUsStandard('q',TapCombo.T22_OO_O, 1),
        new CharacterToTapWithUsStandard('r',TapCombo.T29OOOO_, 1),
        new CharacterToTapWithUsStandard('s',TapCombo.T08___OO, 1),
        new CharacterToTapWithUsStandard('t',TapCombo.T06_OO__, 1),
        new CharacterToTapWithUsStandard('u',TapCombo.T04____O, 1),
        new CharacterToTapWithUsStandard('v',TapCombo.T27OO_OO, 1),
        new CharacterToTapWithUsStandard('w',TapCombo.T24O_O_O, 1),
        new CharacterToTapWithUsStandard('x',TapCombo.T21_O_OO, 1),
        new CharacterToTapWithUsStandard('y',TapCombo.T14O___O, 1),
        new CharacterToTapWithUsStandard('z',TapCombo.T11__O_O, 1),


        new CharacterToTapWithUsStandard('0',TapCombo.T25_OOOO, 1),
        new CharacterToTapWithUsStandard('1',TapCombo.T00O____, 1),
        new CharacterToTapWithUsStandard('2',TapCombo.T01_O___, 1),
        new CharacterToTapWithUsStandard('3',TapCombo.T02__O__, 1),
        new CharacterToTapWithUsStandard('4',TapCombo.T03___O_, 1),
        new CharacterToTapWithUsStandard('5',TapCombo.T04____O, 1),
        new CharacterToTapWithUsStandard('6',TapCombo.T14O___O, 1),
        new CharacterToTapWithUsStandard('7',TapCombo.T13_O__O, 1),
        new CharacterToTapWithUsStandard('8',TapCombo.T11__O_O, 1),
        new CharacterToTapWithUsStandard('9',TapCombo.T08___OO, 1),



        new CharacterToTapWithUsStandard('v',TapCombo.T00O____, 2),
        new CharacterToTapWithUsStandard('j',TapCombo.T02__O__, 2),
        new CharacterToTapWithUsStandard('q',TapCombo.T03___O_, 2),
        new CharacterToTapWithUsStandard('w',TapCombo.T04____O, 2),
        new CharacterToTapWithUsStandard('z',TapCombo.T14O___O, 2),


        new CharacterToTapWithUsStandard(' ',TapCombo.T23O__OO, 3),
        new CharacterToTapWithUsStandard('\r',TapCombo.T23O__OO, 3),
        new CharacterToTapWithUsStandard('\n',TapCombo.T30OOOOO, 3),
        //new CharacterToTapWithUsStandard('.',TapCombo.T09O_O__, 2),
        //new CharacterToTapWithUsStandard('\t',TapCombo.T29OOOO_, 3),


        
        new CharacterToTapWithUsStandard('.',TapCombo.T30OOOOO, 2),
        new CharacterToTapWithUsStandard(',',TapCombo.T10_O_O_, 2),
        new CharacterToTapWithUsStandard('?',TapCombo.T12O__O_, 2),
        new CharacterToTapWithUsStandard('!',TapCombo.T01_O___, 2),
        new CharacterToTapWithUsStandard(':',TapCombo.T26O_OOO, 2),
        new CharacterToTapWithUsStandard(';',TapCombo.T26O_OOO, 3),
        new CharacterToTapWithUsStandard('-',TapCombo.T25_OOOO, 2),
        new CharacterToTapWithUsStandard('"',TapCombo.T06_OO__, 2),
        new CharacterToTapWithUsStandard('\'',TapCombo.T29OOOO_,2),
        new CharacterToTapWithUsStandard('(',TapCombo.T20OO__O, 2),
        new CharacterToTapWithUsStandard(')',TapCombo.T20OO__O, 3),
        new CharacterToTapWithUsStandard('/',TapCombo.T07__OO_, 2),
        new CharacterToTapWithUsStandard('_',TapCombo.T04____O, 3),
        new CharacterToTapWithUsStandard('@',TapCombo.T00O____, 3),
        new CharacterToTapWithUsStandard('&',TapCombo.T09O_O__, 2),
        new CharacterToTapWithUsStandard('#',TapCombo.T06_OO__, 3),
        new CharacterToTapWithUsStandard('[',TapCombo.T13_O__O, 2),
        new CharacterToTapWithUsStandard(']',TapCombo.T13_O__O, 3),
        new CharacterToTapWithUsStandard('+',TapCombo.T07__OO_, 3),
        new CharacterToTapWithUsStandard('=',TapCombo.T01_O___, 3),
        new CharacterToTapWithUsStandard('<',TapCombo.T19O_OO_, 3),
        new CharacterToTapWithUsStandard('>',TapCombo.T19O_OO_, 2),
        new CharacterToTapWithUsStandard('$',TapCombo.T09O_O__, 3),
        new CharacterToTapWithUsStandard('%',TapCombo.T29OOOO_, 3),
        new CharacterToTapWithUsStandard('*',TapCombo.T12O__O_, 3)
    };


    public struct CharacterToEloiStandard {
        public CharacterToEloiStandard(char character, HandType hand, int id): this(character, hand, (TapCombo) id)
        {
        }
        public CharacterToEloiStandard(char character, HandType hand, TapCombo combo) {
            m_character = character;
            m_handType = hand;
            m_tapValue = new TapValue(combo);
        }
        public char m_character;
        public HandType m_handType;
        public TapValue m_tapValue;

    }
    public static CharacterToEloiStandard[] EloiStandard = new CharacterToEloiStandard[] {
        new CharacterToEloiStandard('0', HandType.Left, 0),
        new CharacterToEloiStandard('1', HandType.Left, 1),
        new CharacterToEloiStandard('2', HandType.Left, 2),
        new CharacterToEloiStandard('3', HandType.Left, 3),
        new CharacterToEloiStandard('4', HandType.Left, 4),
        new CharacterToEloiStandard('a', HandType.Left, 5),
        new CharacterToEloiStandard('b', HandType.Left, 6),
        new CharacterToEloiStandard('c', HandType.Left, 7),
        new CharacterToEloiStandard('d', HandType.Left, 8),
        new CharacterToEloiStandard('e', HandType.Left, 9),
        new CharacterToEloiStandard('f', HandType.Left, 10),
        new CharacterToEloiStandard('g', HandType.Left, 11),
        new CharacterToEloiStandard('h', HandType.Left, 12),
        new CharacterToEloiStandard('i', HandType.Left, 13),
        new CharacterToEloiStandard('j', HandType.Left, 14),
        new CharacterToEloiStandard('y', HandType.Left, 15),
        new CharacterToEloiStandard('k', HandType.Left, 16),
        new CharacterToEloiStandard('z', HandType.Left, 17),
        new CharacterToEloiStandard('l', HandType.Left, 18),
        new CharacterToEloiStandard('m', HandType.Left, 19),
        new CharacterToEloiStandard('n', HandType.Left, 20),
        new CharacterToEloiStandard('o', HandType.Left, 21),
        new CharacterToEloiStandard('p', HandType.Left, 22),
        new CharacterToEloiStandard('q', HandType.Left, 23),
        new CharacterToEloiStandard('r', HandType.Left, 24),
        new CharacterToEloiStandard('s', HandType.Left, 25),
        new CharacterToEloiStandard('t', HandType.Left, 26),
        new CharacterToEloiStandard('u', HandType.Left, 27),
        new CharacterToEloiStandard('v', HandType.Left, 28),
        new CharacterToEloiStandard('w', HandType.Left, 29),
        new CharacterToEloiStandard('x', HandType.Left, 30),

        new CharacterToEloiStandard('5', HandType.Right, 0),
        new CharacterToEloiStandard('6', HandType.Right, 1),
        new CharacterToEloiStandard('7', HandType.Right, 2),
        new CharacterToEloiStandard('8', HandType.Right, 3),
        new CharacterToEloiStandard('9', HandType.Right, 4),
        new CharacterToEloiStandard('A', HandType.Right, 5),
        new CharacterToEloiStandard('B', HandType.Right, 6),
        new CharacterToEloiStandard('C', HandType.Right, 7),
        new CharacterToEloiStandard('D', HandType.Right, 8),
        new CharacterToEloiStandard('E', HandType.Right, 9),
        new CharacterToEloiStandard('F', HandType.Right, 10),
        new CharacterToEloiStandard('G', HandType.Right, 11),
        new CharacterToEloiStandard('H', HandType.Right, 12),
        new CharacterToEloiStandard('I', HandType.Right, 13),
        new CharacterToEloiStandard('J', HandType.Right, 14),
        new CharacterToEloiStandard('Y', HandType.Right, 15),
        new CharacterToEloiStandard('K', HandType.Right, 16),
        new CharacterToEloiStandard('Z', HandType.Right, 17),
        new CharacterToEloiStandard('L', HandType.Right, 18),
        new CharacterToEloiStandard('M', HandType.Right, 19),
        new CharacterToEloiStandard('N', HandType.Right, 20),
        new CharacterToEloiStandard('O', HandType.Right, 21),
        new CharacterToEloiStandard('P', HandType.Right, 22),
        new CharacterToEloiStandard('Q', HandType.Right, 23),
        new CharacterToEloiStandard('R', HandType.Right, 24),
        new CharacterToEloiStandard('S', HandType.Right, 25),
        new CharacterToEloiStandard('T', HandType.Right, 26),
        new CharacterToEloiStandard('U', HandType.Right, 27),
        new CharacterToEloiStandard('V', HandType.Right, 28),
        new CharacterToEloiStandard('W', HandType.Right, 29),
        new CharacterToEloiStandard('X', HandType.Right, 30)
    };
}


