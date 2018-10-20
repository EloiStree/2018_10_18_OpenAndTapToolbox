using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToAudioLibrary : MonoBehaviour {

    public string m_audioName;
    public SoundLibrary m_soundLibrary;
	
	public void Play () {
        m_soundLibrary.PlayInFolder(m_audioName);

    }

    public void SetAudioName(string name) {
        m_audioName = name;
    }
}
