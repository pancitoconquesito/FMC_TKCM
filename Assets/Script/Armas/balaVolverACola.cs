using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaVolverACola : MonoBehaviour
{
    private ObjectPooling m_ObjectPooling;
    [SerializeField] private float duracion;
    private float current_duracion;
    [SerializeField] private float velocidad;
    private balaMovement m_balaMovement;
    private so_ARMA m_so_ARMA;
    [SerializeField] private colisionBala m_colisionBala;
    [SerializeField] private bool explosivoTermino;
    //private ObjectPooling m_ObjectPooling;
    //private GameObject padre;
    //[SerializeField] private dataDanio m_dataDanio;
    private retornarObjectPooling m_retornarObjectPooling;
    [SerializeField] private bool isBALA_NS = false;

    void Start()
    {
        m_retornarObjectPooling = transform.GetComponentInParent<retornarObjectPooling>();
        if (!isBALA_NS)
        {
            m_ObjectPooling = referencesMASTER.instancia.ObjectPooling_BALA_PJ;
            m_so_ARMA = Resources.Load<so_ARMA>("ARMAS/" + TIPO_arma.getParse_TipoArma_STRING(Data_Singleton.instancia.getArmaSeleccionada()));
            duracion = m_so_ARMA._bala.duracion;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activo)
        {
            if (current_duracion > -1) current_duracion -= Time.deltaTime;
            if (current_duracion < 0) volverPool();
        }
    }
    private bool firstTime = false;
    private void OnEnable()
    {  
        if (!isBALA_NS)
        {
            firstTime = true;
            m_ObjectPooling = referencesMASTER.instancia.ObjectPooling_BALA_PJ;
            m_so_ARMA = Resources.Load<so_ARMA>("ARMAS/" + TIPO_arma.getParse_TipoArma_STRING(Data_Singleton.instancia.getArmaSeleccionada()));
            duracion = m_so_ARMA._bala.duracion;
            m_balaMovement = GetComponent<balaMovement>();
            m_balaMovement.setVelocidad(m_so_ARMA._bala.velocidadBala);
        }
        else
        {
            m_balaMovement = GetComponent<balaMovement>();
            m_balaMovement.setVelocidad(velocidad);
        }

        activar();
    }
    public void activar()
    {
        activo = true;
        current_duracion = duracion;
    }
    private bool activo=false;
    public void volverPool()
    {
        
        if (explosivoTermino)
        {
            m_colisionBala.verificarExplosion();
        }
        activo = false;

        m_retornarObjectPooling.retornar();
        //m_ObjectPooling.ReturnObjPool(gameObject);
    }
}
