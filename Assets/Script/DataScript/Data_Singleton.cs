using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Singleton : MonoBehaviour
{
    public static Data_Singleton instancia;
    [SerializeField] private TIPO_arma.ArmaTipo armaSeleccionada;

    public void setArmaSeleccionada(TIPO_arma.ArmaTipo _arma)
    {
        print("cambio de arma a : "+_arma);
        armaSeleccionada = _arma;
    }
    public TIPO_arma.ArmaTipo getArmaSeleccionada()
    {
        //print("paso arma tipo : "+armaSeleccionada);
        return armaSeleccionada;
    }

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

}
