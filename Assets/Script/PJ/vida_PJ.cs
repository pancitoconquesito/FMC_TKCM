using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class vida_PJ : MonoBehaviour, IDamageable
{
    private int totalVida;
    private int vidaActual;
    [SerializeField] private movementPJ m_movementPJ;
    [SerializeField] private float tiempoInvulnerable;
    [SerializeField] private ObjectPooling m_OP_dolor;
    //[SerializeField] private ui_corazon m_ui_corazon;
    private float current_tiempoInvulnerable;
    private bool vivo;
    private bool m_invulnerable = false;
    private Data_Singleton m_DATA_SINGLETON;
    private ui_corazon m_ui_corazon;
    [Header("TEST")]
    [SerializeField] private TextMeshProUGUI textTestVida;
    [SerializeField] private TransicionMuerte m_transicionMuerte;

    [SerializeField] private FlashSprite[] m_L_FlashSprite;
    [SerializeField] private Collider2D m_collider;
    //[SerializeField] private FlashSprite m_FlashSprite_arm;

    void Start()
    {
        m_DATA_SINGLETON = GameObject.FindGameObjectWithTag("Data_Singleton").GetComponent<Data_Singleton>();
        current_tiempoInvulnerable = 0;
        vivo = true;
        totalVida = 10;
        //vidaActual = 10;
        vidaActual = GameObject.FindGameObjectWithTag("Data_Singleton").GetComponent<Data_Singleton>().getCantidadVidaPJ();

        if (textTestVida!=null)
            textTestVida.text = "Vida : " + vidaActual;
        m_ui_corazon = referencesMASTER.instancia.m_ui_corazon;
        m_ui_corazon.updateVida_UI(vidaActual);
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
        //print($"Estado persona : {m_movementPJ.getEstado()}");
        if (!vivo || m_invulnerable || m_dataDanio.m_A_QuienDania == GLOBAL_TYPES.AFECTA_A_.daniA_ns || m_dataDanio.m_A_QuienDania == GLOBAL_TYPES.AFECTA_A_.nadie) return false;


        quitarInventario();
        if(m_dataDanio.tipo_danio == GLOBAL_TYPES.TIPO_DANIO.instakill)
        {
            if (addVida(-99))
            //addVida(-99);
                m_movementPJ.recibirDanio(m_dataDanio, false);

            vivo = false;

            

            m_OP_dolor.emitirObj(0.4f, false);
            foreach (var item in m_L_FlashSprite)
            {
                item.Flashear();
            }


            return true;
        }
        bool retorno = false;
        if (vivo && current_tiempoInvulnerable < 0)
        {
            //current_tiempoInvulnerable = tiempoInvulnerable;
            m_OP_dolor.emitirObj(0.4f, false);
            cameraShake.instancia.shake(50f, 0.4f);

            


            current_tiempoInvulnerable = 0.7f;
            if (addVida(-m_dataDanio.getDanio())) 
                m_movementPJ.recibirDanio(m_dataDanio, false);
            retorno = true;

            foreach (var item in m_L_FlashSprite)
            {
                item.Flashear();
            }
        }
        return retorno;
    }

    private void quitarInventario()
    {
        //if(referencesMASTER.instancia.m_GO_UI_died.)
    }

    public bool addVida(int valor)
    {
        if (vivo)
        {
            vidaActual += valor;

            if(textTestVida!=null)
                textTestVida.text = "Vida : " + vidaActual;
            m_ui_corazon.updateVida_UI(vidaActual);
            m_DATA_SINGLETON.saveVida(vidaActual);//@GONZO

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
        return false;
    }
    public void turnInvulnerable(bool valor) => m_invulnerable = valor;
    private void morir()
    {
        m_collider.enabled = false;
        print("me mori!!!");
        m_movementPJ.morir();
        m_DATA_SINGLETON.resetDataMorir();
        //da
    }
    public bool isVivo() => vivo;
}
