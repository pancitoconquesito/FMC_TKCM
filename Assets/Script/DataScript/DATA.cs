using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DATA : MonoBehaviour
{
    public static DATA instance;

    [SerializeField] private testIdiomaSAVE_LOAD idioma_data;
    [SerializeField] private Data_Singleton m_Data_Singleton;
    [SerializeField] private bool cargarArma = true;
    [SerializeField] private bool testSinArma;
    public SAVE_LOAD_SYSTEM save_load_system;
    //private int indiceSiguientePosicion;
    private void Awake()
    {
        

        instance = this;
        idioma_data.cargarIdioma(save_load_system.m_dataGame.m_DATA_CONFIG_GAME.IDIOMA);
        if (GameObject.FindGameObjectWithTag("DataScene").GetComponent<DataScene>().getTipoScene() != GLOBAL_TYPES.TIPO_SCENE.TEST_OST)
            GameObject.FindGameObjectWithTag("Data_Singleton").GetComponent<Data_Singleton>().setCantidadVidaPJ(save_load_system.m_dataGame.m_DATA_PROGRESS.cantidadDeCorazonesTotales);
        if (!cargarArma && !testSinArma)
            GameObject.FindGameObjectWithTag("Data_Singleton").GetComponent<Data_Singleton>().setArmaSeleccionada(TIPO_arma.ArmaTipo.none);

        if (GameObject.FindGameObjectWithTag("DataScene").GetComponent<DataScene>().getTipoScene() == GLOBAL_TYPES.TIPO_SCENE.nivel)
            GameObject.FindGameObjectWithTag("Data_Singleton").GetComponent<Data_Singleton>().setInitialPosition(0);
    }

    public float Nivel_Audio_FX{get{return save_load_system.m_dataGame.m_DATA_CONF_AUDIO.lv_FX;}}
    public float Nivel_Audio_Background { get { return save_load_system.m_dataGame.m_DATA_CONF_AUDIO.lv_BackgroundMusic; } }
    public float Nivel_Audio_voces { get { return save_load_system.m_dataGame.m_DATA_CONF_AUDIO.lv_Voces; } }
    public float Nivel_Audio_MASTER { get { return save_load_system.m_dataGame.m_DATA_CONF_AUDIO.lv_MASTER; } }




    internal int getCantidadNekoEsfera()
    {
        return save_load_system.m_dataGame.m_DATA_NEKO_ESFERA.cantidadDe_NekoEsfera;
    }

    void Start()
    {
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
    }
    /*public void setIndiceSiguientePosicion(int valor)
    {
        indiceSiguientePosicion = valor;
        print("ahora vale : "+indiceSiguientePosicion);
    }
    public int getIndiceSiguientePosicion()
    {
        return indiceSiguientePosicion;
    }*/
    public GLOBAL_TYPES.IDIOMA getIdioma_TYPE(){
        return idioma_data.getIdioma();
    }
    public int getIdioma_INT()
    {
        int retorno = 0;
        switch (getIdioma_TYPE())
        {
            case GLOBAL_TYPES.IDIOMA.ES:
                {
                    retorno = 0;break;
                }
            case GLOBAL_TYPES.IDIOMA.EN:
                {
                    retorno = 1; break;
                }
        }
        return retorno;
    }
    /*
    public int getVidaActual()
    {
        return m_Data_Singleton.getCantidadVidaPJ();
    }
    public void updateVidaPJ(int valor)
    {
        m_Data_Singleton.actualizarVida(valor);
    }*/

}
