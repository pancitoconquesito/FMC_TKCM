using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DATA : MonoBehaviour
{
    public static DATA instance;

    [SerializeField] private testIdiomaSAVE_LOAD idioma_data;
    [SerializeField] private Data_Singleton m_Data_Singleton;
    public SAVE_LOAD_SYSTEM save_load_system;
    //private int indiceSiguientePosicion;
    private void Awake()
    {
        instance = this;
        idioma_data.cargarIdioma(save_load_system.m_dataGame.m_DATA_CONFIG_GAME.IDIOMA);
    }
    void Start()
    {
        
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
    public int getVidaActual()
    {
        return m_Data_Singleton.cantidadVidaPJ;
    }
    public void updateVidaPJ(int valor)
    {
        m_Data_Singleton.actualizarVida(valor);
    }

}
