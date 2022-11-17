using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setMusicBackground : MonoBehaviour
{
    private playBackgorundMusic m_playBackgorundMusic;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Awake()
    {
        m_playBackgorundMusic = GameObject.FindGameObjectWithTag("Data_Singleton").transform.GetChild(0).transform.GetComponent<playBackgorundMusic>();

    }
    public void startBackgroundMusic()
    {
       // print("startBackgroundMusic");
        Invoke("startMusicNow",1.1f);
    }
    public void startBackgroundMusic_NO_Repeat()
    {
        //print("startBackgroundMusic");
        Invoke("startMusicNow_NO_REPEAT", 1.1f);
    }
    private void startMusicNow()
    {
        m_playBackgorundMusic.startBackground_and_Stop();
    }
    private void startMusicNow_NO_REPEAT()
    {
        m_playBackgorundMusic.startBackground_and_Return();
    }
    private void stopMusicNow()
    {
        m_playBackgorundMusic.startBackground_and_Stop();
    }
    public void stopbackground()
    {
        Invoke("stoptMusicNow", .1f);
        m_playBackgorundMusic.stopBackgroundMusic();
    }
    public void setBakcground(int value)
    {
        m_playBackgorundMusic.setIndexBakcground(value);
    }

    public void setBakcground(playBackgorundMusic.NAME_BACKGROUND nameMusic)
    {
        m_playBackgorundMusic.setIndexBakcground(m_playBackgorundMusic.parseNameBackground(nameMusic));
    }


}
