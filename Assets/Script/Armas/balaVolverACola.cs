using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaVolverACola : MonoBehaviour
{
    private ObjectPooling m_ObjectPooling;
    private float duracion;
    private float current_duracion;
    private balaMovement m_balaMovement;
    private so_ARMA m_so_ARMA;
    [SerializeField] private colisionBala m_colisionBala;
    [SerializeField] private bool explosivoTermino;
    //[SerializeField] private dataDanio m_dataDanio;
    void Start()
    {
        m_ObjectPooling = referencesMASTER.instancia.ObjectPooling_BALA_PJ;

        m_so_ARMA = Resources.Load<so_ARMA>("ARMAS/" + TIPO_arma.getParse_TipoArma_STRING(Data_Singleton.instancia.getArmaSeleccionada()));
        duracion = m_so_ARMA._bala.duracion;
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
        firstTime = true;
        m_ObjectPooling = referencesMASTER.instancia.ObjectPooling_BALA_PJ;
        m_so_ARMA = Resources.Load<so_ARMA>("ARMAS/" + TIPO_arma.getParse_TipoArma_STRING(Data_Singleton.instancia.getArmaSeleccionada()));
        duracion = m_so_ARMA._bala.duracion;
        m_balaMovement = GetComponent<balaMovement>();
        m_balaMovement.setVelocidad(m_so_ARMA._bala.velocidadBala);


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
        m_ObjectPooling.ReturnObjPool(gameObject);
    }
}
