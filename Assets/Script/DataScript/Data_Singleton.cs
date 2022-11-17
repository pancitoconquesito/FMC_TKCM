using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Singleton : MonoBehaviour
{
    public static Data_Singleton instancia;
    [SerializeField] private TIPO_arma.ArmaTipo armaSeleccionada;
    [SerializeField] private int cantidadVidaPJ;
    [SerializeField] private int initialPosition;
    [SerializeField] private string NextLevel_singleton;
    private bool setVidaInicializada = false;
    void Awake()
    {
        if (instancia == null)
        {
            //cantidadVidaPJ = 3;//@GONZO
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    public void setCantidadVidaPJ(int valor)
    {
        if (!setVidaInicializada) {
            //print("AAAAAAAAAAAAAAAAAAAAAa");
            setVidaInicializada = true;
            cantidadVidaPJ = valor;
        }
    }

    internal string getNextLevel_singleton()
    {
        return NextLevel_singleton;
    }
    public void setNextLevel_singleton(string valor)
    {
        NextLevel_singleton = valor;
    }

    /*
void Awake()
{


   if (instancia == null)
   {
       cantidadVidaPJ = 2;
       instancia = this;
       DontDestroyOnLoad(gameObject);
   }
   else
       Destroy(gameObject);
}*/
    private void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = -1;
        Application.targetFrameRate = 144;
    }
    public void setArmaSeleccionada(TIPO_arma.ArmaTipo _arma)
    {
        //print("cambio de arma a : "+_arma);
        armaSeleccionada = _arma;
    }
    public TIPO_arma.ArmaTipo getArmaSeleccionada()
    {
        //print("paso arma tipo : "+armaSeleccionada);
        return armaSeleccionada;
    }
    public int getCantidadVidaPJ() => cantidadVidaPJ;

    internal void saveVida(int vidaActual)//////////////////////////////////////////
    {
        cantidadVidaPJ = vidaActual;
    }

    internal void resetDataMorir()
    {
        cantidadVidaPJ = DATA.instance.save_load_system.m_dataGame.m_DATA_PROGRESS.cantidadDeCorazonesTotales;
    }
    public int getInitialPosition()=>initialPosition;
    public int setInitialPosition(int value) => initialPosition=value;
}
