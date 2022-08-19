using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador_NS : MonoBehaviour
{
    [SerializeField, Range(0,20)] private float rangoVisionRastrear;
    [SerializeField, Range(0, 1)] private float factorVision;
    [SerializeField, Range(0, 1)] private float factorVelocidadRotacion_rastreo;
    [SerializeField, Range(0, 1)] private float factorVelocidadRotacion_Disparo;
    [SerializeField] private float cadenciaDisparo;
    [SerializeField] private ObjectPooling m_ObjectPooling;
    private float current_CadenciaDisparo;
    private float rangoVisionDisparar;
    public enum EstadoDisparador
    {
        activoSiDispara, activoNoDispara, desactivado
    }
    [SerializeField] private EstadoDisparador m_estadoDisparador;
    private Transform m_transformPJ;
    // Start is called before the first frame update
    void Start()
    {
        m_transformPJ = referencesMASTER.instancia.m_transformPJ;
        m_estadoDisparador = EstadoDisparador.desactivado;
        current_CadenciaDisparo = cadenciaDisparo * .7f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector2.Distance(transform.position, m_transformPJ.position) < rangoVisionRastrear)
        {
            m_estadoDisparador = EstadoDisparador.activoNoDispara;
            if(Vector2.Distance(transform.position, m_transformPJ.position) < rangoVisionDisparar)
                m_estadoDisparador = EstadoDisparador.activoSiDispara;
        }
        else m_estadoDisparador = EstadoDisparador.desactivado;
        Comportamientos();
    }
    private void Comportamientos()
    {
        switch (m_estadoDisparador)
        {
            case EstadoDisparador.activoNoDispara:
                {
                    transform.up = Vector3.Lerp(transform.up, m_transformPJ.position - transform.position, factorVelocidadRotacion_rastreo * Time.deltaTime);
                    current_CadenciaDisparo=cadenciaDisparo*.7f;
                    break;
                }
            case EstadoDisparador.activoSiDispara:
                {
                    transform.up = Vector3.Lerp(transform.up, m_transformPJ.position - transform.position, factorVelocidadRotacion_Disparo * Time.deltaTime);
                    if (current_CadenciaDisparo > -1) current_CadenciaDisparo -= Time.deltaTime;
                    if (current_CadenciaDisparo < 0) Disparar();
                    break;
                }
            
        }
    }

    private void Disparar()
    {
        current_CadenciaDisparo = cadenciaDisparo;
        Instantiate(m_ObjectPooling.objeto, transform.position, transform.rotation);
        //m_ObjectPooling.emitirObj(1,false);
    }


    private void OnDrawGizmos()
    {
        DibujarCirculo(rangoVisionRastrear, Color.green, true);
        rangoVisionDisparar = rangoVisionRastrear-rangoVisionDisparar * factorVision;
        DibujarCirculo(rangoVisionDisparar, Color.blue, false);
    }

    private void DibujarCirculo(float _rango, Color colorCirculo, bool targetLine)
    {
        if (m_transformPJ != null && targetLine)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, m_transformPJ.position);
        }
        Gizmos.color = colorCirculo;
        Gizmos.DrawWireSphere(transform.position, _rango);
    }

    private void OnDrawGizmosSelected()
    {
        m_transformPJ = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
    }
}
