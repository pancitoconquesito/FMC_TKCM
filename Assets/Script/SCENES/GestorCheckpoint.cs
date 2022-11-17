using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorCheckpoint : MonoBehaviour
{
    [SerializeField] private Checkpoint[] m_L_checkpoints;
    [SerializeField] private AudioClip m_clip;
    private AudioSource m_audiosource;
    private Transform m_trans_PJ;
    private Data_Singleton m_Data_Singleton;

    private int cantidadHijos;
    private void Awake()
    {
        m_audiosource = GetComponent<AudioSource>();
        if(m_audiosource!=null)
            m_audiosource.clip = m_clip;
        cantidadHijos = transform.childCount;
        m_L_checkpoints = new Checkpoint[cantidadHijos];
        for (int i = 0; i < cantidadHijos; i++) { 
        
            m_L_checkpoints[i]=transform.GetChild(i).GetComponent<Checkpoint>();
            m_L_checkpoints[i].setGestorCheckpoint(this);
        }

    }
    private void Start()
    {
        m_Data_Singleton = referencesMASTER.instancia.m_Data_Singleton;
        m_trans_PJ = referencesMASTER.instancia.m_transformPJ;
        int indicePosicionActual = m_Data_Singleton.getInitialPosition();
        Vector3 posicionInicial = m_L_checkpoints[indicePosicionActual].miPosicion;
        m_trans_PJ.position = posicionInicial;
    }
    void Update()
    {
        
    }

    internal void setCheckpoint(int numero)
    {
        if (m_Data_Singleton.getInitialPosition() >= numero) return;
        print("HOLO");
        for (int i = 0; i < cantidadHijos; i++)
        {
            m_L_checkpoints[i].activo = m_L_checkpoints[i].numero > numero;
        }
        m_Data_Singleton.setInitialPosition(numero);
    }

    public void reproducirAudio()
    {
        if(m_audiosource!=null)
            m_audiosource.Play();
    }
}
