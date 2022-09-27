using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_interaccion_BIOMA : MonoBehaviour, IInteraccion
{
    [SerializeField] private string m_nameStage;
    private Gestor_UI_Bioma m_ui_bioma_GO;
    private void Start()
    {
        m_ui_bioma_GO = referencesMASTER.instancia.m_Gestor_UI_Bioma;
    }
    public void comenzarInteraccion()
    {
        m_ui_bioma_GO.comenzar(m_nameStage);
        //m_ui_bioma_GO.SetActive(true);
    }
    public void cancelarInteraccion()
    {
        m_ui_bioma_GO.desactivar();
        //m_ui_bioma_GO.SetActive(false);
    }
}
