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
    [SerializeField] private ParticleSystem[] m_ParticleSystem;
    private int currentIndex;
    private GLOBAL_TYPES.IDIOMA idioma;
    // Start is called before the first frame update
    void Start()
    {
        idioma = DATA.instance.getIdioma_TYPE();
        currentIndex = 0;
        m_AudioSource = GetComponent<AudioSource>();
        updateParameters();

        setText_PLay_Pause(true);

        enableDisableParticles(false);
    }

    private void setText_PLay_Pause(bool play)
    {
        if (play)
        {
            if (idioma == GLOBAL_TYPES.IDIOMA.ES)
            {
                m_text_playPause.text = "Reproducir";
            }
            else
            {
                m_text_playPause.text = "Play";
            }
        }
        else
        {
            if (idioma == GLOBAL_TYPES.IDIOMA.ES)
            {
                m_text_playPause.text = "Pausar";
            }
            else
            {
                m_text_playPause.text = "Pause";
            }
        }

    }

    private void enableDisableParticles(bool value)
    {
        foreach (var item in m_ParticleSystem)
        {
            var emission = item.emission;
            if(value)
                emission.rateOverTime = 5;
            else
                emission.rateOverTime = 0;
        }
    }

    private string m_nameSong;
    private float currentSongTime=-1;

    public void BTN_NXT_IndexClip()
    {
        currentIndex++;
        if(currentIndex>= m_L_musicClip.Length)
        currentIndex = 0;
        if (m_AudioSource.isPlaying)
        {
            PLAY();
        }
        updateParameters();
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
        updateParameters();
    }

    private void PLAY()
    {
        m_AudioSource.clip = m_L_musicClip[currentIndex];
        m_AudioSource.Play();
        updateParameters();
        m_Rotar.Activo = true;

        enableDisableParticles(true);
    }

    public void BTN_PLAY_PAUSE()
    {
        if (m_AudioSource.isPlaying)
        {
            BTN_PAUSE();
            setText_PLay_Pause(true);


            enableDisableParticles(false);
        }
        else
        {
            PLAY();
            setText_PLay_Pause(false);

        }
    }
    private void BTN_PAUSE()
    {
        m_AudioSource.Pause();
        m_Rotar.Activo = false;
        enableDisableParticles(false);
    }
    public void BTN_STOP()
    {
        m_AudioSource.Stop();
        m_Rotar.Activo = false;
        enableDisableParticles(false);
    }
}
