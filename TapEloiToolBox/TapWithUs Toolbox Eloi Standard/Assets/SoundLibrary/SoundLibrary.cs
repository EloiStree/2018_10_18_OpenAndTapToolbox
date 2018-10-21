using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SoundLibrary : MonoBehaviour {

    public AudioClip m_clip;
    public AudioSource m_audioSource;
    public InputField m_fileName;

    public static string m_directoryPathWindow="";
    public static string DirectoryPath { get {
            if (m_directoryPathWindow==null || m_directoryPathWindow.Length <= 0)
                m_directoryPathWindow = Application.persistentDataPath;
            return m_directoryPathWindow ; }
    }
  

    public void StartRecord()
    {
        m_clip = Microphone.Start(null, false, 60, 44100);
    }

    public void StopRecord() {
        StopRecord(RemoveExtention(m_fileName.text));
    }

    private string RemoveExtention(string text)
    {
        text = text.Replace(".wav","");
        text = text.Replace(".mp3","");
        return text;
    }

    public void StopRecord (string fileName) {
        Microphone.End(null);
        if(m_clip!=null)
            SavWav.Save(fileName!=""?fileName: GetTimestamp(DateTime.Now)+".wav", m_clip);

    }

    public void PlayLastRecord() {
        m_audioSource.clip = m_clip;
        m_audioSource.Play();
    }
    

    public string[] GetFilesNameInFolder() {

       //string [] pathFiles = Directory.GetFiles(DirectoryPath);
       // if (pathFiles.Length > 0)
       // {
       //     for (int i = 0; i < pathFiles.Length; i++)
       //     {
       //         Debug.Log(">:" + pathFiles[i]);
       //         pathFiles[i] = Path.GetFileName(pathFiles[i]);
       //     }
       // }
       // else return new string[0];

        return   Directory
                .GetFiles(DirectoryPath, "*", SearchOption.AllDirectories)
                .Select(f => Path.GetFileName(f)).ToArray();
     
    }

    public void PlayInFolder(string fileName) {

        StartCoroutine(LaunchAudio(fileName));
      
    }

    private IEnumerator LaunchAudio(string fileName)
    {
        Debug.Log("Hey:Audio: "+ fileName);
        if (!string.IsNullOrEmpty(fileName)) {
            
            Debug.Log(DirectoryPath + "/" + fileName);
            string path =  DirectoryPath + "/" + fileName;
            if (File.Exists(path)) {

                Debug.Log("Hey:dddd: " + fileName);
                WWW www;

                www = new WWW("file:///" +path);
                yield return www;

                AudioClip audio = www.GetAudioClip();
                if (audio != null)
                {
                    m_audioSource.clip = audio;
                    m_audioSource.Play();
                }

            }


        }
    }
    

    public static String GetTimestamp(DateTime value)
    {
        return value.ToString("yyyyMMddHHmmssffff");
    }


}
