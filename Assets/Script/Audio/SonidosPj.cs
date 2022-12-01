using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosPj : MonoBehaviour
{
    [SerializeField] private bool startSound;
    [SerializeField] private AudioClip m_start_audioClip;
    [SerializeField] private AudioClip m_saltar_AudioClip;
    [SerializeField] private AudioClip m_patada_AudioClip;
    [SerializeField] private AudioClip m_landed_AudioClip;
    [SerializeField] private AudioClip m_dash_AudioClip;
    [SerializeField] private AudioClip m_danio_AudioClip;
    [SerializeField] private AudioClip m_morir_AudioClip;
    [SerializeField] private AudioClip m_restartDash_AudioClip;

    [SerializeField] private AudioClip m_startInventario_AudioClip;
    [SerializeField] private AudioClip m_ExitInventario_AudioClip;






    private AudioSource m_AudioSource;
    void Start()
    {
        float nivelAudio_FX = DATA.instance.Nivel_Audio_FX;
        float nivelAudio_MASTER = DATA.instance.Nivel_Audio_MASTER;

        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.volume = nivelAudio_FX*nivelAudio_MASTER;
        m_AudioSource.PlayOneShot(m_start_audioClip);
    }

    public void playSalto()
    {
        m_AudioSource.PlayOneShot(m_saltar_AudioClip);
    }
    public void playPatada()
    {
        m_AudioSource.PlayOneShot(m_patada_AudioClip);
    }
    public void playLanded()
    {
        m_AudioSource.PlayOneShot(m_landed_AudioClip);
    }
    public void playDash()
    {
        m_AudioSource.PlayOneShot(m_dash_AudioClip);
    }
    public void playRecibirDanio()
    {
        m_AudioSource.PlayOneShot(m_danio_AudioClip);
    }
    public void playMorir()
    {
        m_AudioSource.PlayOneShot(m_morir_AudioClip);
    }
    public void playRestartDash()
    {
        m_AudioSource.PlayOneShot(m_restartDash_AudioClip);
    }
    public void playStartInventario()
    {
        m_AudioSource.PlayOneShot(m_startInventario_AudioClip);
    }
    public void playExitInventario()
    {
        m_AudioSource.PlayOneShot(m_ExitInventario_AudioClip);
    }

    public void playDisparo(AudioClip _audioClip)
    {
        if (_audioClip == null)
        {
            print("Audioclip nulo=>return");
            return;
        }
        m_AudioSource.PlayOneShot(_audioClip);
    }
}
