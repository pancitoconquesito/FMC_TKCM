using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCorazonesAntesDeCambiar : MonoBehaviour
{
    //[SerializeField] private int cantidad;
    public void cambiar(int valor)
    {
        referencesMASTER.instancia.m_Data_Singleton.setCantidadVidaPJ(valor);
    }
}
