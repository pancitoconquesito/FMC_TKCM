using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OST_SCENE__Controller : MonoBehaviour
{
    private AudioSource m_AudioSource;
    [SerializeField] private AudioClip[] m_L_musicClip;
    [SerializeField] private TextMeshProUGUI m_text_NameSong;
    [SerializeField] private TextMeshProUGUI m_text_playPause;
    [SerializeField] private Rotar m_Rotar;
    private int currentIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 0;
        m_AudioSource = GetComponent<AudioSource>();
        updateParameters();
        m_text_playPause.text = "Play";
    }

    private string m_nameSong;
    private float currentSongTime=-1;
    void Update()
    {
        /*if(currentSongTime==0 && !m_AudioSource.isPlaying)
        {

        }*/
    }
    public void BTN_NXT_IndexClip()
    {
        currentIndex++;
        if(currentIndex>= m_L_musicClip.Length)
        currentIndex = 0;
        if (m_AudioSource.isPlaying)
        {
            PLAY();
        }
    }

    private void updateParameters()
    {
        currentSongTime = m_AudioSource.time;
        m_nameSong = m_L_musicClip[currentIndex].name;
        m_text_NameSong.text = m_nameSong;
    }

    public void BTN_ANT_IndexClip()
    {
        currentIndex--;
        if(currentIndex<0)
            currentIndex = m_L_musicClip.Length-1;
        if (m_AudioSource.isPlaying)
        {
            PLAY();
        }
    }

    private void PLAY()
    {
        m_AudioSource.clip = m_L_musicClip[currentIndex];
        m_AudioSource.Play();
        updateParameters();
        m_Rotar.Activo = true;
    }

    public void BTN_PLAY_PAUSE()
    {
        if (m_AudioSource.isPlaying)
        {
            BTN_PAUSE();
            m_text_playPause.text = "Play";
        }
        else
        {
            PLAY();
            m_text_playPause.text = "Pausa";
        }
    }
    private void BTN_PAUSE()
    {
        m_AudioSource.Pause();
        m_Rotar.Activo = false;
    }
    public void BTN_STOP()
    {
        m_AudioSource.Stop();
        m_Rotar.Activo = false;
    }
}
