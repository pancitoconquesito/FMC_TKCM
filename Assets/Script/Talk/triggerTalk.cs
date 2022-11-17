using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class triggerTalk : MonoBehaviour
{
    [SerializeField] private SO_DIALOGO m_so_dialogo;
    [SerializeField] private Collider2D collider_alejarPj_Conv;
    [SerializeField] private Animator m_animator_globoBTN;
    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    private gestorConversacion m_gestorConversacion;
    private movementPJ m_movementPJ;
    private Transform m_transform_PJ;
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
        print("m_estado == estadoTalk.stay :"+ m_estado);
        if (m_estado == estadoTalk.stay && m_movementPJ.comenzarTalk(transform.position.x))
        {
            collider_alejarPj_Conv.enabled = true;
            m_estado = estadoTalk.conversando;
            m_gestorConversacion.comenzarConversacion(m_so_dialogo, this);
            m_animator_globoBTN.ResetTrigger("end");
            m_animator_globoBTN.SetTrigger("end");
            m_SpriteRenderer .flipX= m_transform_PJ.position.x > transform.position.x;
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
        m_transform_PJ = referencesMASTER.instancia.m_transformPJ;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            setControl();
            m_estado = estadoTalk.stay;
            m_animator_globoBTN.ResetTrigger("start");
            m_animator_globoBTN.SetTrigger("start");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        //print("saliendo por trigger exit");
        if (m_estado == estadoTalk.stay)
        {
            m_animator_globoBTN.ResetTrigger("end");
            m_animator_globoBTN.SetTrigger("end");
        }
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
        m_animator_globoBTN.ResetTrigger("start");
        m_animator_globoBTN.SetTrigger("start");
    }
}
