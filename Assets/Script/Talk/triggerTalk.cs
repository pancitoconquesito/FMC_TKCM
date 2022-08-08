using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class triggerTalk : MonoBehaviour
{
    [SerializeField] private SO_DIALOGO m_so_dialogo;
    [SerializeField] private Collider2D collider_alejarPj_Conv;
    private gestorConversacion m_gestorConversacion;
    private movementPJ m_movementPJ;
    public enum estadoTalk
    {
        stay, conversando, fuera
    }
    private estadoTalk m_estado;


    private NewControls m_Control;

    
    private void setControl()
    {
        m_Control = new NewControls();
        m_Control.DIALOGOS.Enable();

        m_Control.DIALOGOS.Comenzar.started += ctx => accionComenzar();

        m_Control.DIALOGOS.Next.started += ctx => accionContinuar();
    }
    private void accionComenzar()
    {
        if (m_estado == estadoTalk.stay && m_movementPJ.comenzarTalk(transform.position.x))
        {
            collider_alejarPj_Conv.enabled = true;
            m_estado = estadoTalk.conversando;
            m_gestorConversacion.comenzarConversacion(m_so_dialogo, this);
        }
    }
    private void OnDisable() { desactivarControles(); }
    private void desactivarControles()
    {
        if (m_Control != null)
        {
            m_Control.DIALOGOS.Disable();
            m_Control = null;
        }
    }
    void Start()
    {
        m_estado = estadoTalk.fuera;
        m_movementPJ = referencesMASTER.instancia.m_movementPJ;
        m_gestorConversacion = referencesMASTER.instancia.m_gestorConversacion;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("colisione con "+collision.name);
        setControl();
        m_estado = estadoTalk.stay;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        m_estado = estadoTalk.fuera;
        desactivarControles();
    }
    private void accionContinuar()
    {
        if(m_estado == estadoTalk.conversando)
            m_gestorConversacion.siguiente();
    }

    public void exit()
    {
        //print("ya sali!");
        collider_alejarPj_Conv.enabled = false;
        m_estado = estadoTalk.stay;
        m_movementPJ.returnNormalMovement();
    }
}
