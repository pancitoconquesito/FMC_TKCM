using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class audioCaminar : MonoBehaviour
{
    [SerializeField] private AudioClip[] m_L_audioClip;
    private int cantidadEleemntos;
    private AudioSource m_AudioSource;
    void Start()
    {
        cantidadEleemntos = m_L_audioClip.Length;
        m_AudioSource = GetComponent<AudioSource>();
    }


    private void playRandomClip()
    {
        if (m_AudioSource.isPlaying) return;
        int nRandom = Random.Range(0, cantidadEleemntos);
        //print($"cantidadEleemntos : {cantidadEleemntos} -____-nRandom : {nRandom}");
        m_AudioSource.PlayOneShot(m_L_audioClip[nRandom]);
    }

}
