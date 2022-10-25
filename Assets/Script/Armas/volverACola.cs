using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volverACola : MonoBehaviour
{
    private ObjectPooling m_ObjectPooling;
    [SerializeField] private float duracion;
    private float current_duracion;
    private retornarObjectPooling m_retornarObjectPooling;
    void Start()
    {
        m_retornarObjectPooling = transform.GetComponentInParent<retornarObjectPooling>();
    }
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
        m_ObjectPooling = referencesMASTER.instancia.ObjectPooling_BALA_PJ;
        activar();
    }
    public void activar()
    {
        activo = true;
        current_duracion = duracion;
    }
    private bool activo = false;
    public void volverPool()
    {
        activo = false;
        m_retornarObjectPooling.retornar();
    }
}
