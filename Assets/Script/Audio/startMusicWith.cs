using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startMusicWith : MonoBehaviour
{
    private playBackgorundMusic m_playBackgorundMusic;
    [SerializeField] private bool startWithMusic;
    [SerializeField] private int indexStart;
    private void Awake()
    {
        if (startWithMusic)
        {
            Invoke("iniciar",0.5f);
            
        }
    }
    private void Start()
    {
        
    }
    private void iniciar()
    {
        m_playBackgorundMusic = GameObject.FindGameObjectWithTag("BackgroundMusic").transform.GetComponent<playBackgorundMusic>();
        m_playBackgorundMusic.setIndexBakcground(indexStart);
        m_playBackgorundMusic.startBackground_and_Return();
    }
    public void stopMusic()
    {
        //print("Stop");
        m_playBackgorundMusic = GameObject.FindGameObjectWithTag("BackgroundMusic").transform.GetComponent<playBackgorundMusic>();


        m_playBackgorundMusic.stopBackgroundMusic();
    }

    public void startMusic()
    {
        m_playBackgorundMusic = GameObject.FindGameObjectWithTag("BackgroundMusic").transform.GetComponent<playBackgorundMusic>();


        m_playBackgorundMusic.startBackground_and_Stop();
    }

    public void setMusci(int value)
    {
        m_playBackgorundMusic = GameObject.FindGameObjectWithTag("BackgroundMusic").transform.GetComponent<playBackgorundMusic>();


        m_playBackgorundMusic.setIndexBakcground(value);
    }
}
