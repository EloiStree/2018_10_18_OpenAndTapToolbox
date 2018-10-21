using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class StayingStuffs : MonoBehaviour {


    public UI_SayingStuffs m_displayInfo;
    public MappingCombo m_mapping;
    [System.Serializable]
    public class MappingCombo {
        public List<HandedComboTowhatToWay> m_comboToSaying;
        public List<ComboTowhatToWay> m_comboWithUsToSaying;
    }

    public Color m_defaultBackground = Color.white;
    

    public void SayHandedValue(HandedTapValue value)
    {

        HandedComboTowhatToWay combo = CheckForCorresponding(value);
        if (combo != null) {
        Debug.Log("...");

            m_displayInfo.SetWith(combo.m_message, value, combo.m_color,  combo.m_clipFileName);
        }
    }
    public void SayTapWithUs(TapValue value)
    {

        ComboTowhatToWay combo = CheckForCorresponding(value);

        if (combo != null)
            m_displayInfo.SetWith(combo.m_message, value, combo.m_color,  combo.m_clipFileName);
    }

    internal void Add(string name, string description, Color color, HandType handtype, TapValue value, string fileName)
    {
        if (value.m_combo != TapCombo.T99_____)
        {
            if (handtype == HandType.Right)
            {
                m_mapping.m_comboWithUsToSaying.Add(new ComboTowhatToWay()
                {
                    m_name = name,
                    m_message = description,
                    m_color = color,
                    m_clipFileName = fileName,
                    m_combo = value
                });
            }
            m_mapping.m_comboToSaying.Add(new HandedComboTowhatToWay()
            {
                m_name = name,
                m_message = description,
                m_color = color,
                m_clipFileName = fileName,
                m_combo = new HandedTapValue(handtype, value.m_combo),

            });

            Save();
        }
    }

    public void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Load();
    }

    public void OnDestroy()
    {
        Save();
    }
    public void OnApplicationPause(bool pause)
    {
        Save();

    }
    private void OnApplicationQuit()
    {
        Save();
    }
    public string GetRecordPath() {
        return Application.persistentDataPath + "/Mapping.json";
    }
    public void Save()
    {
      string json =  JsonUtility.ToJson(m_mapping);
        File.WriteAllText(GetRecordPath(), json);
        File.WriteAllText(Application.dataPath+"/TAG.txt", "Hey");
        Debug.Log(GetRecordPath() + " -- " + json);
    }
    internal void Load()
    {
        if (File.Exists(GetRecordPath())) {
            string json = File.ReadAllText(GetRecordPath());
            m_mapping = JsonUtility.FromJson<MappingCombo>(json);
        }
    }
    public void ResetData()
    {
        m_mapping.m_comboToSaying.Clear();
        m_mapping.m_comboWithUsToSaying.Clear();
    }

    private HandedComboTowhatToWay CheckForCorresponding(HandedTapValue value)
    {
        if (value == null)
            return null;
        HandedComboTowhatToWay[] combos = m_mapping.m_comboToSaying.Where(k => value.m_combo == k.m_combo.m_combo && value.m_handType == k.m_combo.m_handType).ToArray();

        Debug.Log("Try " + combos.Length + " " + value.ToString());
        if (combos.Length > 0)
            return combos[0];
        return null;
    }
    private ComboTowhatToWay CheckForCorresponding(TapValue value)
    {
        if (value == null)
            return null;
        ComboTowhatToWay[] combos = m_mapping.m_comboWithUsToSaying.Where(k => value.m_combo == k.m_combo.m_combo ).ToArray();

        Debug.Log("Try " + combos.Length + " " + value.ToString());
        if (combos.Length > 0)
            return combos[0];
        return null;
    }

    [System.Serializable]
    public class HandedComboTowhatToWay
    {
        public string m_name;
        public string m_message;
        public HandedTapValue m_combo;
        public Color m_color = Color.white;
        public string m_clipFileName;

    }
    [System.Serializable]
    public class ComboTowhatToWay
    {
        public string m_name;
        public string m_message;
        public TapValue m_combo;
        public Color m_color = Color.white;
        public string m_clipFileName;

    }
}


