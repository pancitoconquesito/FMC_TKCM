using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playBackgorundMusic : MonoBehaviour
{
    public enum NAME_BACKGROUND
    {
        fabrica, bosqueBlanco, padro,
        romina,
        lava, g12, song1,
        nivel
    }


    [SerializeField] private AudioClip[] m_CLIP_musicBackground;
    //[SerializeField] private bool startWithMusic;
    //[SerializeField] private int indexStart;
    private int id_musicBackground;
    private AudioSource m_AudioSource;
    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();

    }

    void Start()
    {
        getVolumen();

    }

    private void getVolumen()
    {
        float nivelAudio_BAckfground = DATA.instance.Nivel_Audio_Background;
        float nivelAudio_MASTER = DATA.instance.Nivel_Audio_MASTER;

        //id_musicBackground = GameObject.FindGameObjectWithTag("DataScene").GetComponent<DataScene>().ID_BackGorunMusic;
        m_AudioSource.volume = nivelAudio_BAckfground * nivelAudio_MASTER;
    }

    [ContextMenu("Ejecutar funcion A")]
    public void startBackground_and_Stop()
    {
        print("startMUsic");
        getVolumen();

        if (m_AudioSource.isPlaying) m_AudioSource.Stop();
        m_AudioSource.clip = m_CLIP_musicBackground[id_musicBackground];
        m_AudioSource.Play();
    }
    public void startBackground_and_Return()
    {
        if (m_AudioSource==null || m_AudioSource.isPlaying) return;
        getVolumen();
        m_AudioSource.clip = m_CLIP_musicBackground[id_musicBackground];
        m_AudioSource.Play();
    }
    public void stopBackgroundMusic()
    {
        //interpolacion
        if (m_AudioSource == null) GetComponent<AudioSource>();

        if (m_AudioSource == null) return;
        m_AudioSource.Stop();
    }
    public void setIndexBakcground(int value)
    {
        //print("Set : "+value);
        id_musicBackground = value;
    }

    public int parseNameBackground(NAME_BACKGROUND value)
    {
        int entero = 0;
        switch (value)
        {
            case playBackgorundMusic.NAME_BACKGROUND.bosqueBlanco:{entero = 0;     break;}
            case playBackgorundMusic.NAME_BACKGROUND.padro:{entero = 1;         break;}
            case playBackgorundMusic.NAME_BACKGROUND.fabrica:{entero = 2;       break;}
            case playBackgorundMusic.NAME_BACKGROUND.romina:{entero = 3;        break;}

            case playBackgorundMusic.NAME_BACKGROUND.lava: { entero = 4; break; }
            case playBackgorundMusic.NAME_BACKGROUND.g12: { entero = 5; break; }
            case playBackgorundMusic.NAME_BACKGROUND.song1: { entero = 6; break; }
            case playBackgorundMusic.NAME_BACKGROUND.nivel: { entero = 7; break; }

        }
        return entero;
    }
}
