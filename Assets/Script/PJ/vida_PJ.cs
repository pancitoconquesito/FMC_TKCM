using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class vida_PJ : MonoBehaviour, IDamageable
{
    private int totalVida;
    private int vidaActual;
    [SerializeField] private movementPJ m_movementPJ;
    [SerializeField] private float tiempoInvulnerable;
    //[SerializeField] private ui_corazon m_ui_corazon;
    private float current_tiempoInvulnerable;
    private bool vivo;
    private bool m_invulnerable = false;
    //private DATA_SINGLETON m_DATA_SINGLETON;

    [Header("TEST")]
    [SerializeField] private TextMeshProUGUI textTestVida;
    void Start()
    {
        current_tiempoInvulnerable = 0;
        vivo = true;
        totalVida = 10;
        vidaActual = 10;
        textTestVida.text = "Vida : " + vidaActual;
        //m_DATA_SINGLETON = GameObject.FindGameObjectWithTag("DATA_SINGLETON").GetComponent<DATA_SINGLETON>();
        //vidaActual = m_DATA_SINGLETON.vidaPj;
        //totalVida = m_DATA_SINGLETON.vidaMAXIMA_pj;
    }

    void Update()
    {
        //if (current_tiempoInvulnerable > -1)
            current_tiempoInvulnerable -= Time.deltaTime;
    }



    public bool RecibirDanio_I(dataDanio m_dataDanio)
    {
        //print("VIDA PJ");
        if (!vivo || m_invulnerable || m_dataDanio.m_A_QuienDania == GLOBAL_TYPES.AFECTA_A_.daniA_ns || m_dataDanio.m_A_QuienDania == GLOBAL_TYPES.AFECTA_A_.nadie) return false;
        if(m_dataDanio.tipo_danio == GLOBAL_TYPES.TIPO_DANIO.instakill)
        {
            if (addVida(-99))
                m_movementPJ.recibirDanio(m_dataDanio, false);
            vivo = false;
            return true;
        }
        bool retorno = false;
        if (vivo && current_tiempoInvulnerable < 0)
        {
            //current_tiempoInvulnerable = tiempoInvulnerable;
            current_tiempoInvulnerable = 0.7f;
            if (addVida(-m_dataDanio.getDanio())) 
                m_movementPJ.recibirDanio(m_dataDanio, false);
            retorno = true;
        }
        return retorno;
    }
    public bool addVida(int valor)
    {
        if (vivo)
        {
            vidaActual += valor;

            textTestVida.text = "Vida : " + vidaActual;

            if (vidaActual > totalVida) vidaActual = totalVida;

            if (vidaActual <= 0)
            {
                vidaActual = 0;
                vivo = false;
                morir();
                return false;
            }
            return true;
        }
        /*
        if (vivo && m_movementPJ.test_getEstado() != GLOBAL_TYPE.ESTADOS.entrandoScene)
        {
            vidaActual += valor;
            if (vidaActual > totalVida) vidaActual = totalVida;
            
            m_DATA_SINGLETON.vidaPj = vidaActual;
            m_ui_corazon.updateVida_UI(vidaActual);
            if (vidaActual <= 0)
            {
                vidaActual = 0;
                vivo = false;
                m_DATA_SINGLETON.vidaPj = vidaActual;
                m_ui_corazon.updateVida_UI(vidaActual);
                morir();
                return false;
            }
            return true;
        }
        */
        return false;
    }
    public void turnInvulnerable(bool valor) => m_invulnerable = valor;
    private void morir()
    {
        print("me mori!!!");
        //m_DATA_SINGLETON.resetDataMorir();
        m_movementPJ.morir();
    }
}
