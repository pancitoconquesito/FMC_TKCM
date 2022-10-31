using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class balaMovement : MonoBehaviour, IDamageable
{
    [SerializeField] private float velocidad;
    [SerializeField] private bool bulletENEMY;


    /*[Header("particulas inicio test")]
    [SerializeField] private bool m_habilitarTEST;
    [SerializeField] private ObjectPooling m_OP_patInicio;*/


    [SerializeField] private dataDanio m_dataDanio;
    private Rigidbody2D m_Rigidbody2D;
    private GLOBAL_TYPES.AFECTA_A_ m_afectaAQuien;

    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        if(m_dataDanio!=null)
            m_afectaAQuien = m_dataDanio.m_A_QuienDania;
    }
    private float lado=1;
    public void setLado()
    {
        changeMirada miradaPJ = referencesMASTER.instancia.miradaPJ;
        if (miradaPJ.getMirada() == GLOBAL_TYPES.ladoMirada.izquierda)
            lado = -1;
        else lado = 1;
    }
    public float getVelocidad()
    {
        return velocidad;
    }
    public void setVelocidad(float valor)
    {
        velocidad = valor;
    }
    //private bool firstTime = false;
    private void OnEnable()
    {
        if (m_dataDanio != null)
            m_dataDanio.m_A_QuienDania= m_afectaAQuien;

        /*if (firstTime)
        {
            m_OP_patInicio.emitirObj(0.3f, false);
        }*/
        //firstTime = true;
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        if(!bulletENEMY)
            setLado();
    }
    [Header("Mostrar vector")]
    public Vector2 direccion;
    private void FixedUpdate()
    {
        //m_Rigidbody2D.velocity=Vector2.right * velocidad * lado;
        if (lado == 0)
        {
            print("eS 0!");
            //Debug.Break();
        }
        if(bulletENEMY)
            m_Rigidbody2D.velocity = direccion * velocidad * lado;
        else
            m_Rigidbody2D.velocity = transform.right * velocidad * lado;

    }
    public void setDireccion(Vector2 newDirection, float potVelocidad, GLOBAL_TYPES.AFECTA_A_ _afectaA)
    {
        direccion = newDirection;
        velocidad *= potVelocidad;

        if (m_dataDanio != null)
            m_dataDanio.setAfectaA(_afectaA);
    }
    public bool RecibirDanio_I(dataDanio m_dataDanio)
    {
        if(m_dataDanio.tipo_danio == GLOBAL_TYPES.TIPO_DANIO.kick)
        {
            print("ay!!!!");
            //Debug.Break();
            //cambair direccion
        }
        return true;
    }
}
