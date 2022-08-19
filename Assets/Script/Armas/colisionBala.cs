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
        if (idamageable != null)
        {
            verificarExplosion();

            if (collision.CompareTag("Player"))
            {
                if (destruible_Player) m_balaVolverACola.volverPool();
            }
            if (collision.CompareTag("NS"))
            {
                //print("NS _"+ collision.name);
                if (destruible_NS) m_balaVolverACola.volverPool();
        
            }
            idamageable.RecibirDanio_I(m_dataDanio);
        }
        if (collision.CompareTag("Platform"))
        {
            verificarExplosion();

            if (destruible_Platform)
                m_balaVolverACola.volverPool();
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
