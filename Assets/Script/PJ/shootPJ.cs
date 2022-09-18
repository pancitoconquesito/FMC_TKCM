using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootPJ : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;

    //private float cadencia, retroceso, au_Nau, instantaneo;
    //cadencia, retroceso, <bala>, automatica/NoAutomatica, instantaneo(si dispara de inmediato),  
    private float current_Cadencia=-1;

    private so_ARMA m_so_ARMA;
    private TIPO_arma.ArmaTipo m_armaTipo;
    private movementPJ m_movementPJ;
    private bool automatica;
    // Start is called before the first frame update
    void Start()
    {
        m_armaTipo = Data_Singleton.instancia.getArmaSeleccionada();
        print("arma seleccionada : "+m_armaTipo);
        referencesMASTER.instancia.animator_ARMA.SetInteger("Arma_ID", TIPO_arma.getParse_TipoArma_INTEGER(m_armaTipo));
        referencesMASTER.instancia.animator_ARMA.SetTrigger("ChangeGun");

        m_so_ARMA = Resources.Load<so_ARMA>("ARMAS/"+ TIPO_arma.getParse_TipoArma_STRING(m_armaTipo));
        //cadencia = m_so_ARMA.cadencia;
        //retroceso 

        //setearValoresMovementPJ
        m_movementPJ = referencesMASTER.instancia.m_movementPJ;
        m_movementPJ.setParamMovement(m_so_ARMA.m_so_CONFIG_PJ, true);

        if (TIPO_arma.getParse_TipoArma_STRING(m_armaTipo) != "NULL")
        {
            m_ObjectPooling_BALA_PJ = referencesMASTER.instancia.ObjectPooling_BALA_PJ;
            m_ObjectPooling_BALA_PJ.objeto= Resources.Load<GameObject>(m_so_ARMA._bala.dirPrefab);
            m_ObjectPooling_BALA_PJ.startCola(m_so_ARMA.cantidadPool);
            //m_ObjectPooling_BALA_PJ.startCola();
            automatica=m_so_ARMA.au_noAu == TIPO_arma.Au.automatica;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (current_Cadencia > -1)
        {
            current_Cadencia -= Time.deltaTime;
        }

        if (shootHold && current_Cadencia < 0 && automatica)
        {
            spawnBullet();
        }
    }
    private ObjectPooling m_ObjectPooling_BALA_PJ;
    private bool shootHold = false;
    public void Shoot()
    {
        shootHold = true;
        
        if (current_Cadencia < 0 && !automatica)
        {
             spawnBullet();
        }
    }
    private void spawnBullet()
    {
        if (m_movementPJ.canShoot())
        {
            if (m_so_ARMA.instantaneo)
            {
                current_Cadencia = m_so_ARMA.cadencia;
                print("Shoot");
                m_Animator.SetTrigger("Shoot");
                m_movementPJ.retrocesoDisparo(m_so_ARMA.retroceso);

                //GameObject obj= 
                m_ObjectPooling_BALA_PJ.emitirObj(m_so_ARMA._bala.duracion, false);
            }
            else
                m_Animator.SetTrigger("Shoot");


            
        }else shootHold = false;
    }
    public void spawnBullet_NoInstantaneo()
    {
        if (m_movementPJ.canShoot())
        {
            current_Cadencia = m_so_ARMA.cadencia;
            print("Shoot");
            //m_Animator.SetTrigger("Shoot");
            m_movementPJ.retrocesoDisparo(m_so_ARMA.retroceso);

            //GameObject obj= 
            m_ObjectPooling_BALA_PJ.emitirObj(m_so_ARMA._bala.duracion, false);
        }
        else shootHold = false;
    }
    public void shootRelease()
    {
        shootHold = false;
    }
}
