using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAVE_LOAD_SYSTEM : MonoBehaviour
{
    public DATA_GAME m_dataGame;
    private void Awake()
    {
        load_();
    }

    [ContextMenu("load")]
    public void load_()
    {
        DATA_GAME dataGame = new DATA_GAME();
        m_dataGame = dataGame.Load_DATA();

        if (m_dataGame == null
            || m_dataGame.m_DATA_ITEMS == null
            || m_dataGame.m_DATA_PROGRESS == null
            || m_dataGame.m_DATA_CONF_AUDIO == null
            || m_dataGame.m_DATA_CONFIG_GAME == null

            || m_dataGame.m_DATA_NEKO_ESFERA == null
            )
            erase_();
    }

    [ContextMenu("save")]
    public void save_()
    {
        m_dataGame.Save_DATA(m_dataGame);
    }

    [ContextMenu("erase")]
    public void erase_()
    {
        //salvar configuracion juego
        guardarContextoConfiguracion(m_dataGame.m_DATA_CONFIG_GAME, m_dataGame.m_DATA_CONF_AUDIO);

        m_dataGame = null;
        m_dataGame = new DATA_GAME();
        cargarContexto();
        m_dataGame.Save_DATA(m_dataGame);
    }

    private void cargarContexto()
    {
        m_dataGame.m_DATA_CONFIG_GAME = null;
        m_dataGame.m_DATA_CONFIG_GAME = new DATA_CONFIG_GAME();
        m_dataGame.m_DATA_CONFIG_GAME.IDIOMA=context_DATA_CONFIG_GAME.IDIOMA;

        m_dataGame.m_DATA_CONF_AUDIO = null;
        m_dataGame.m_DATA_CONF_AUDIO = new DATA_CONF_AUDIO();
        m_dataGame.m_DATA_CONF_AUDIO.lv_MASTER = context_DATA_CONF_AUDIO.lv_MASTER ;
        m_dataGame.m_DATA_CONF_AUDIO.lv_BackgroundMusic = context_DATA_CONF_AUDIO.lv_BackgroundMusic ;
        m_dataGame.m_DATA_CONF_AUDIO.lv_FX = context_DATA_CONF_AUDIO.lv_FX;
        m_dataGame.m_DATA_CONF_AUDIO.lv_Voces = context_DATA_CONF_AUDIO.lv_Voces;
    }
    DATA_CONFIG_GAME context_DATA_CONFIG_GAME;
    DATA_CONF_AUDIO context_DATA_CONF_AUDIO;
    private void guardarContextoConfiguracion(DATA_CONFIG_GAME _DATA_CONFIG_GAME, DATA_CONF_AUDIO _DATA_CONF_AUDIO)
    {
        context_DATA_CONFIG_GAME = null;
        context_DATA_CONFIG_GAME = new DATA_CONFIG_GAME();
        context_DATA_CONFIG_GAME.IDIOMA = _DATA_CONFIG_GAME.IDIOMA;

        context_DATA_CONF_AUDIO = null;
        context_DATA_CONF_AUDIO = new DATA_CONF_AUDIO();
        context_DATA_CONF_AUDIO.lv_MASTER = _DATA_CONF_AUDIO.lv_MASTER;
        context_DATA_CONF_AUDIO.lv_BackgroundMusic = _DATA_CONF_AUDIO.lv_BackgroundMusic;
        context_DATA_CONF_AUDIO.lv_FX = _DATA_CONF_AUDIO.lv_FX;
        context_DATA_CONF_AUDIO.lv_Voces = _DATA_CONF_AUDIO.lv_Voces;
    }

    [ContextMenu("show")]
    public void mostrarData()
    {
        print("valor de valorData_test : " + m_dataGame.m_DATA_TEST.valorData_test);
        print("valor de valorData_test_b : " + m_dataGame.m_DATA_TEST.valorData_test_b);
    }

    [ContextMenu("mod_1")]
    public void modificarVar_1()
    {
        m_dataGame.m_DATA_TEST.valorData_test = 1;
    }

    [ContextMenu("mod_2")]
    public void modificarVar_2()
    {
        m_dataGame.m_DATA_TEST.valorData_test = 2;
    }

    [ContextMenu("mod_3")]
    public void modificarVar_3()
    {
        m_dataGame.m_DATA_TEST.valorData_test = 3;
    }


 


    /***********************************************/
    public void saveItem(int idItem)
    {
        

        switch (idItem)
        {
            case 0://item TEST
                {
                    m_dataGame.m_DATA_ITEMS.itemTest = true;
                    break;
                }
        }

        save_();
    }


    public bool isGenericProgress(GLOBAL_TYPES.TIPO_PREFAB tipoPrefab, int idPrefab)
    {
        bool retorno = false;

        switch (tipoPrefab)
        {
            case GLOBAL_TYPES.TIPO_PREFAB.ITEM:
                {
                    retorno = isItemObtenido(idPrefab);
                    break;
                }
            case GLOBAL_TYPES.TIPO_PREFAB.NekoEsfera:
                {
                    retorno=isNekoEsfera(idPrefab);
                    if (!retorno) setNekoEsfera(idPrefab);
                    //retorno = true;//siempre true para que reaccione a animarse o destruirse
                    break;
                }
        }
        return retorno;
    }

    private void setNekoEsfera(int idPrefab)
    {
        m_dataGame.m_DATA_NEKO_ESFERA.L_D_etapas[idPrefab].completado = true;
        m_dataGame.m_DATA_NEKO_ESFERA.addNekoEsfera();
    }

    private bool isNekoEsfera(int idPrefab)
    {
        return m_dataGame.m_DATA_NEKO_ESFERA.L_D_etapas[idPrefab].completado;
    }

    public bool isItemObtenido(int idItem)
    {
        bool retorno = false;

        switch (idItem)
        {
            case 0://item TEST
                {
                    retorno = m_dataGame.m_DATA_ITEMS.itemTest;
                    break;
                }
        }
        return retorno;
    }
}
