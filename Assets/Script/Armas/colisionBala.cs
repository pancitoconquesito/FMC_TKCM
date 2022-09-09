using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionBala : MonoBehaviour
{
    [SerializeField] private balaMovement m_balaMovement;
    [SerializeField] private balaVolverACola m_balaVolverACola;
    [SerializeField] private dataDanio m_dataDanio;
    [SerializeField] private bool destruible_Player = true; 
    [SerializeField] private bool destruible_NS = true;
    [SerializeField] private bool destruible_Platform = true;
    [SerializeField] private bool rebotable;
    [SerializeField]private bool explosivoColision;
    [SerializeField] private GameObject prefabExplosion;
    private float cadenciaRespuesta = 0.08f;
    private float current_cadenciaRespuesta = 0;
    private bool explosionActiva=false;
    //private ObjectPooling m_ObjectPooling;
    [SerializeField] private retornarObjectPooling m_retornarObjectPooling;
    void Start()
    {
    }

    private void OnEnable()
    {
        explosionActiva = false;
    }
    void Update()
    {
        if (current_cadenciaRespuesta > -1) current_cadenciaRespuesta -= Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        IDamageable idamageable = collision.GetComponent<IDamageable>();
        //print("nombre "+collision.name);
        if (idamageable != null)
        {
            verificarExplosion();

            if (collision.transform.parent!=null && collision.transform.parent.CompareTag("Player"))
            {
                if (destruible_Player) m_retornarObjectPooling.retornar();//m_balaVolverACola.volverPool();
            }
            if (collision.transform.CompareTag("NS"))
            {
                if (destruible_NS) m_retornarObjectPooling.retornar();//m_balaVolverACola.volverPool();
            }
            idamageable.RecibirDanio_I(m_dataDanio);
        }
        if (collision.CompareTag("Platform"))
        {
            verificarExplosion();

            if (destruible_Platform) {
                m_retornarObjectPooling.retornar();//m_balaVolverACola.volverPool();
            }
            if (rebotable && current_cadenciaRespuesta<0)
            {
                current_cadenciaRespuesta = cadenciaRespuesta;
                m_balaMovement.setVelocidad(-m_balaMovement.getVelocidad());
            }
        }
    }

    public void verificarExplosion()
    {
        if (explosivoColision && !explosionActiva)
        {
            explosionActiva = true;
            Instantiate(prefabExplosion, transform.position, Quaternion.identity);
            print("explosion _");
        }
    }


}
