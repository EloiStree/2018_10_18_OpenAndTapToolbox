using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAllButThis : MonoBehaviour {

    public GameObject[] m_deactivateAll;

    public void DeactivateAll() {
        for (int i = 0; i < m_deactivateAll.Length; i++)
        {
            m_deactivateAll[i].SetActive(false);
        }
    }
}
