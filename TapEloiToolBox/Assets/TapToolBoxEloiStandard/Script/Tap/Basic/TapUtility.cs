using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TapUtility : MonoBehaviour {


    public static TapValue GetTapBasedOnTapWithUsStandard(char character)
    {
        CharacterToTapWithUsStandard[] valuesFound = TapWithUsStandard.Where(k => k.m_character == character).ToArray();
        if (valuesFound.Length > 0)
            return valuesFound[0].m_tapvalue;
        else
            return new TapValue( TapCombo.T_____);
        
    }
    public static HandTapValue GetTapBasedOnEloiStandard(char character)
    {
        CharacterToEloiStandard[] valuesFound= EloiStandard.Where(k => k.m_character == character).ToArray();
        if(valuesFound.Length>0)
            return new HandTapValue(valuesFound[0].m_handType, valuesFound[0].m_tapValue.m_combo );
        else
            return new HandTapValue(HandType.Left, TapCombo.T_____);
    }

    internal static void GetTapValueFrom(bool [] handsBoolState, out TapValue lastTapLeft, out TapValue lastTapRight)
    {
        char [] leftHand = new char[5];
        char [] rightHand = new char[5];
        GetTapValueAsStringFrom(handsBoolState, out leftHand, out rightHand);
        lastTapLeft= GetTapValueFrom(leftHand) ;
        lastTapRight= GetTapValueFrom(rightHand);
    }

    internal static HandsTapValue ConvertToHandsValue(TapValue value)
    {
        return new HandsTapValue(TapCombo.T_____, value.m_combo);
    }
    internal static HandsTapValue ConvertToHandsValue(HandTapValue value)
    {
        if (value.m_handType == HandType.Left)
            return new HandsTapValue(TapCombo.T_____, value.m_combo);
        else
            return new HandsTapValue(value.m_combo,TapCombo.T_____);
    }

    private static TapValue GetTapValueFrom(char[] leftHand)
    {
        foreach (TapCombo item in Enum.GetValues(typeof(TapCombo)).Cast<TapCombo>())
        {
            string itemString = item.ToString().Substring(1);
           
            if(itemString== new string(leftHand))
            {

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

        new CharacterToTapWithUsStandard('a',TapCombo.TO____, 1),
        new CharacterToTapWithUsStandard('b',TapCombo.T_O__O, 1),
        new CharacterToTapWithUsStandard('c',TapCombo.TO_OOO, 1),
        new CharacterToTapWithUsStandard('d',TapCombo.TO_O__, 1),
        new CharacterToTapWithUsStandard('e',TapCombo.T_O___, 1),
        new CharacterToTapWithUsStandard('f',TapCombo.TOO_O_, 1),
        new CharacterToTapWithUsStandard('g',TapCombo.TO_OO_, 1),
        new CharacterToTapWithUsStandard('h',TapCombo.T_OOOO, 1),
        new CharacterToTapWithUsStandard('i',TapCombo.T__O__, 1),
        new CharacterToTapWithUsStandard('j',TapCombo.TOOO_O, 1),
        new CharacterToTapWithUsStandard('k',TapCombo.TO__O_, 1),
        new CharacterToTapWithUsStandard('l',TapCombo.T__OO_, 1),
        new CharacterToTapWithUsStandard('m',TapCombo.T_O_O_, 1),
        new CharacterToTapWithUsStandard('n',TapCombo.TOO___, 1),
        new CharacterToTapWithUsStandard('o',TapCombo.T___O_, 1),
        new CharacterToTapWithUsStandard('p',TapCombo.TOO__O, 1),
        new CharacterToTapWithUsStandard('q',TapCombo.T_OO_O, 1),
        new CharacterToTapWithUsStandard('r',TapCombo.TOOOO_, 1),
        new CharacterToTapWithUsStandard('s',TapCombo.T___OO, 1),
        new CharacterToTapWithUsStandard('t',TapCombo.T_OO__, 1),
        new CharacterToTapWithUsStandard('u',TapCombo.T____O, 1),
        new CharacterToTapWithUsStandard('v',TapCombo.TOO_OO, 1),
        new CharacterToTapWithUsStandard('w',TapCombo.TO_O_O, 1),
        new CharacterToTapWithUsStandard('x',TapCombo.T_O_OO, 1),
        new CharacterToTapWithUsStandard('y',TapCombo.TO___O, 1),
        new CharacterToTapWithUsStandard('z',TapCombo.T__O_O, 1),


        new CharacterToTapWithUsStandard('0',TapCombo.T_OOOO, 1),
        new CharacterToTapWithUsStandard('1',TapCombo.TO____, 1),
        new CharacterToTapWithUsStandard('2',TapCombo.T_O___, 1),
        new CharacterToTapWithUsStandard('3',TapCombo.T__O__, 1),
        new CharacterToTapWithUsStandard('4',TapCombo.T___O_, 1),
        new CharacterToTapWithUsStandard('5',TapCombo.T____O, 1),
        new CharacterToTapWithUsStandard('6',TapCombo.TO___O, 1),
        new CharacterToTapWithUsStandard('7',TapCombo.T_O__O, 1),
        new CharacterToTapWithUsStandard('8',TapCombo.T__O_O, 1),
        new CharacterToTapWithUsStandard('9',TapCombo.T___OO, 1),



        new CharacterToTapWithUsStandard('v',TapCombo.TO____, 2),
        new CharacterToTapWithUsStandard('j',TapCombo.T__O__, 2),
        new CharacterToTapWithUsStandard('q',TapCombo.T___O_, 2),
        new CharacterToTapWithUsStandard('w',TapCombo.T____O, 2),
        new CharacterToTapWithUsStandard('z',TapCombo.TO___O, 2),


        new CharacterToTapWithUsStandard(' ',TapCombo.TO__OO, 3),
        new CharacterToTapWithUsStandard('\r',TapCombo.TO__OO, 3),
        new CharacterToTapWithUsStandard('\n',TapCombo.TOOOOO, 3),
        //new CharacterToTapWithUsStandard('.',TapCombo.T09O_O__, 2),
        //new CharacterToTapWithUsStandard('\t',TapCombo.T29OOOO_, 3),


        
        new CharacterToTapWithUsStandard('.',TapCombo.TOOOOO, 2),
        new CharacterToTapWithUsStandard(',',TapCombo.T_O_O_, 2),
        new CharacterToTapWithUsStandard('?',TapCombo.TO__O_, 2),
        new CharacterToTapWithUsStandard('!',TapCombo.T_O___, 2),
        new CharacterToTapWithUsStandard(':',TapCombo.TO_OOO, 2),
        new CharacterToTapWithUsStandard(';',TapCombo.TO_OOO, 3),
        new CharacterToTapWithUsStandard('-',TapCombo.T_OOOO, 2),
        new CharacterToTapWithUsStandard('"',TapCombo.T_OO__, 2),
        new CharacterToTapWithUsStandard('\'',TapCombo.TOOOO_,2),
        new CharacterToTapWithUsStandard('(',TapCombo.TOO__O, 2),
        new CharacterToTapWithUsStandard(')',TapCombo.TOO__O, 3),
        new CharacterToTapWithUsStandard('/',TapCombo.T__OO_, 2),
        new CharacterToTapWithUsStandard('_',TapCombo.T____O, 3),
        new CharacterToTapWithUsStandard('@',TapCombo.TO____, 3),
        new CharacterToTapWithUsStandard('&',TapCombo.TO_O__, 2),
        new CharacterToTapWithUsStandard('#',TapCombo.T_OO__, 3),
        new CharacterToTapWithUsStandard('[',TapCombo.T_O__O, 2),
        new CharacterToTapWithUsStandard(']',TapCombo.T_O__O, 3),
        new CharacterToTapWithUsStandard('+',TapCombo.T__OO_, 3),
        new CharacterToTapWithUsStandard('=',TapCombo.T_O___, 3),
        new CharacterToTapWithUsStandard('<',TapCombo.TO_OO_, 3),
        new CharacterToTapWithUsStandard('>',TapCombo.TO_OO_, 2),
        new CharacterToTapWithUsStandard('$',TapCombo.TO_O__, 3),
        new CharacterToTapWithUsStandard('%',TapCombo.TOOOO_, 3),
        new CharacterToTapWithUsStandard('*',TapCombo.TO__O_, 3)
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


