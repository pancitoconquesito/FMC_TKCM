using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DATA_GAME 
{
    public DATA_TEST m_DATA_TEST;
    public DATA_ITEMS m_DATA_ITEMS;
    public DATA_PROGRESS m_DATA_PROGRESS;
    public DATA_CONF_AUDIO m_DATA_CONF_AUDIO;
    public DATA_CONFIG_GAME m_DATA_CONFIG_GAME;

    public DATA_NEKO_ESFERA m_DATA_NEKO_ESFERA;

    //public ISaveLoadSystem m_ISaveLoadSystem;
    public DATA_GAME()//ISaveLoadSystem _ISaveLoadSystem)
    {
        //SAVE_LOAD_ADAPTER aaa = new SAVE_LOAD_ADAPTER();
        //m_ISaveLoadSystem = aaa;
        //m_ISaveLoadSystem = new SAVE_LOAD_ADAPTER();
        //Debug.Log("ok");

        m_DATA_TEST = new DATA_TEST();
        m_DATA_ITEMS = new DATA_ITEMS();
        m_DATA_PROGRESS = new DATA_PROGRESS();
        m_DATA_CONF_AUDIO = new DATA_CONF_AUDIO();//configuracion de audio
        m_DATA_CONFIG_GAME = new DATA_CONFIG_GAME();// guarda el idioma, 

        m_DATA_NEKO_ESFERA = new DATA_NEKO_ESFERA();
    }

    public void Save_DATA(DATA_GAME data)
    {
        //S0AVE_LOAD_ADAPTER aaa = new SAVE_LOAD_ADAPTER();

        //m_ISaveLoadSystem.SAVE_DATA_GAME(data);
        // SAVE_LOAD_ADAPTER aaa = new SAVE_LOAD_ADAPTER();
        /*SAVE_LOAD_ADAPTER aaa = new SAVE_LOAD_ADAPTER();
        m_ISaveLoadSystem = aaa;

        m_ISaveLoadSystem.SAVE_DATA_GAME(data);

        E_MetodosGuardados.Save_DATA(data, new SAVE_LOAD_ADAPTER());*/

        SAVE_LOAD_ADAPTER.SAVE_DATA_GAME(data);
    }
    public DATA_GAME Load_DATA()
    {
        //SAVE_LOAD_ADAPTER aaa = new SAVE_LOAD_ADAPTER();
        return SAVE_LOAD_ADAPTER.LOAD_DATA_GAME();
        //m_ISaveLoadSystem = aaa;
        //return m_ISaveLoadSystem.LOAD_DATA_GAME();
        //return E_MetodosGuardados.Load_DATA(new SAVE_LOAD_ADAPTER());
    }
}
