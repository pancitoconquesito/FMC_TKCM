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
    public DATA_GAME()
    {
        m_DATA_TEST = new DATA_TEST();
        m_DATA_ITEMS = new DATA_ITEMS();
        m_DATA_PROGRESS = new DATA_PROGRESS();
        m_DATA_CONF_AUDIO = new DATA_CONF_AUDIO();//configuracion de audio
        m_DATA_CONFIG_GAME = new DATA_CONFIG_GAME();// guarda el idioma, 

        m_DATA_NEKO_ESFERA = new DATA_NEKO_ESFERA();
    }

    public void Save_DATA(DATA_GAME data)
    {
        SAVE_LOAD.SAVE_DATA_GAME(data);
    }
    public DATA_GAME Load_DATA()
    {
        return SAVE_LOAD.LOAD_DATA_GAME();
    }
}
