using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioListPanel : MonoBehaviour {

    public SoundLibrary m_library;
    public StringButton.OnSelected m_onAudioSelected;
    public Transform m_parent;
    public GameObject m_prefab;

    private void Start()
    {
        Refresh();
    }

    public void Refresh() {
        Refresh( m_library.GetFilesNameInFolder());
    }

    public void Refresh(string [] name) {
        int childs = m_parent.childCount;
        for (int i = childs - 1; i > 0; i--)
        {
            GameObject.Destroy(m_parent.GetChild(i).gameObject);
        }
        for (int i = 0; i < name.Length; i++)
        {
           GameObject obj = GameObject.Instantiate(m_prefab);
            obj.transform.parent = m_parent;
            obj.transform.localScale = Vector3.one;
            obj.SetActive(true);
            StringButton strButton = obj.GetComponent<StringButton>();
            if (strButton) {
                strButton.SetContent(name[i]);
                strButton.m_onTriggered.AddListener(AudioSelected);

            }
        }

    }

    private void AudioSelected(string audioName )
    {
        m_onAudioSelected.Invoke(audioName);
    }
}
