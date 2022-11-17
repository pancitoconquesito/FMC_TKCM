using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_interaccion_BIOMA : MonoBehaviour, IInteraccion
{
    [SerializeField] private string m_nameStage;
    [SerializeField] private bool testLevel;
    [SerializeField, Range(1, 5)] private int m_numero_NIVEL;
    [SerializeField, Range(1, 3)] private int m_numero_BIOMA;
    [SerializeField, Range(1, 4)] private int m_numero_ETAPA;
    private playBackgorundMusic m_playBackgorundMusic;
    [SerializeField] private playBackgorundMusic.NAME_BACKGROUND m_nameBackground;
    private Gestor_UI_Bioma m_ui_bioma_GO;
    private int m_indexBackground;
    private void Start()
    {
        m_playBackgorundMusic = GameObject.FindGameObjectWithTag("Data_Singleton").transform.GetChild(0).transform.GetComponent<playBackgorundMusic>();

        m_ui_bioma_GO = referencesMASTER.instancia.m_Gestor_UI_Bioma;
        if(!testLevel)
            m_nameStage = $"N{m_numero_NIVEL}_B_{m_numero_BIOMA}_E{m_numero_ETAPA}";
        m_indexBackground = m_playBackgorundMusic.parseNameBackground(m_nameBackground);
    }
    public void comenzarInteraccion()
    {
        m_playBackgorundMusic.setIndexBakcground(m_indexBackground);
        m_ui_bioma_GO.comenzar(m_nameStage);
        //m_ui_bioma_GO.SetActive(true);
    }
    public void cancelarInteraccion()
    {
        m_ui_bioma_GO.desactivar();
        //m_ui_bioma_GO.SetActive(false);
    }
}
