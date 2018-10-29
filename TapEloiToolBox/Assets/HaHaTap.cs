using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaHaTap : MonoBehaviour {

    public UI_TapValue m_ui;
    public float m_pourcent=1f;
    public float m_speedInPourcent=0.1f;

    public TapCombo m_tapCombo;

    public static int m_produced;
    public static int m_lost;
    public static int m_kill;
    public float m_heightPCt =0.1f;
    private void Awake()
    {
        m_produced++;
        m_tapCombo = (TapCombo)UnityEngine.Random.Range(0, 30);
        if (m_tapCombo == TapCombo.TOOO__ || m_tapCombo == TapCombo.T__OOO)
            m_tapCombo = TapCombo.T_OOO_;
        m_ui.SetWith(new TapValue(m_tapCombo));
    }

    void Update () {

        m_pourcent -= Time.deltaTime * m_speedInPourcent;
        RectTransform rt = GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0, m_pourcent - m_heightPCt);
        rt.anchorMax = new Vector2(1, m_pourcent + m_heightPCt);
        rt.offsetMin = new Vector2(0, 0);
        rt.offsetMax = new Vector2(0, 0);
        rt.anchoredPosition = new Vector2(0, 0);
       
        if (m_pourcent <= -0.1f) {
            m_lost++;
            KillItWithFire();
        }
    }

    private void KillItWithFire()
    {
        Destroy(this.gameObject);
    }

    public  bool TryToDestoy(TapCombo combo) {
        if (m_tapCombo == combo)
        {
            KillItWithFire();

            m_kill++;
            return true;
        }
        return false;
    }
}
