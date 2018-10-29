using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class JokerGame : MonoBehaviour {

    public UI_TapValue m_tapDisplay;
    public Transform m_parent;
    public GameObject m_prefab;

    public HaHaTap [] m_HaHaTap;

    public float minTime = 1f;
    public float maxTime = 2f;

    public Text m_score;

    private IEnumerator Start()
    {
        while (true) {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minTime, maxTime));
            Pop();
        }

    }

    private void Pop()
    {
        GameObject created =   GameObject.Instantiate(m_prefab);
        created.transform.parent = m_parent;
        created.SetActive(true);
    }


    public void Update()
    {
        m_score.text = HaHaTap.m_kill + " | " + HaHaTap.m_produced + " | " + HaHaTap.m_lost;
    }


    public void ReceivedInput(string input, HandsTapValue handsTypeValue)
    {

        m_HaHaTap = GameObject.FindObjectsOfType<HaHaTap>();
        m_HaHaTap = m_HaHaTap.OrderBy(k => k.m_pourcent).ToArray();
        for (int i = 0; i < m_HaHaTap.Length; i++)
        {
            bool found=false;
            if (!found)
                found = m_HaHaTap[i].TryToDestoy(handsTypeValue.m_leftCombo.m_combo);
            if(!found)
                found = m_HaHaTap[i].TryToDestoy(handsTypeValue.m_rightCombo.m_combo);
            if (found)
                break;
        }
    }

    public void ReceivedInput( HandsTapValue handsTypeValue)
    {
        ReceivedInput("", handsTypeValue);
       
    }
   
}
