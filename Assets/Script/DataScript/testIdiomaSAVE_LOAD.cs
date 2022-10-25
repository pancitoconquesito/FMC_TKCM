using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testIdiomaSAVE_LOAD : MonoBehaviour
{
    // español 0
    // ingles 1
    private GLOBAL_TYPES.IDIOMA m_idioma;
    private void Awake()
    {
        //cargarIdioma();
    }
    private void Start()
    {
        
    }
    public void cargarIdioma(int valorIdioma)
    {
        //int valorIdioma = PlayerPrefs.GetInt("idioma",0);
        //int valorIdioma=DATA.instance.
        switch (valorIdioma)
        {
            case 0: { m_idioma = GLOBAL_TYPES.IDIOMA.ES; break; }
            case 1: { m_idioma = GLOBAL_TYPES.IDIOMA.EN; break; }
        }
        print("IDIOMA : "+m_idioma);
    }
    public GLOBAL_TYPES.IDIOMA getIdioma()
    {
        int valor = DATA.instance.save_load_system.m_dataGame.m_DATA_CONFIG_GAME.IDIOMA;
        GLOBAL_TYPES.IDIOMA retorno=GLOBAL_TYPES.IDIOMA.ES;
        switch (valor)
        {
            case 0:
                {
                    retorno = GLOBAL_TYPES.IDIOMA.ES; break;
                }
            case 1:
                {
                    retorno = GLOBAL_TYPES.IDIOMA.EN; break;
                }
        }
        return retorno;
        //return m_idioma;
    }
    public void setIdioma(int valorIdioma)
    {
        //print("valorIdioma : "+ valorIdioma);
        switch (valorIdioma)
        {
            case 0: { 
                    m_idioma = GLOBAL_TYPES.IDIOMA.ES;
                    DATA.instance.save_load_system.m_dataGame.m_DATA_CONFIG_GAME.IDIOMA = 0;
                    break; }
            case 1: { 
                    m_idioma = GLOBAL_TYPES.IDIOMA.EN;
                    DATA.instance.save_load_system.m_dataGame.m_DATA_CONFIG_GAME.IDIOMA = 1;
                    break; }
        }
        
    }
    public void saveIdioma()
    {
        DATA.instance.save_load_system.save_();
        //PlayerPrefs.SetInt("idioma", GLOBAL_TYPES.parseIdioma(m_idioma));
    }
}
