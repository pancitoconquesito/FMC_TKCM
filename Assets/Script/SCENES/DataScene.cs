using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class DataScene : MonoBehaviour
{
    
    [SerializeField] private GLOBAL_TYPES.TIPO_SCENE m_tipoScene;
    [SerializeField] private playBackgorundMusic.NAME_BACKGROUND m_nameBackground;

    private int id_musicBackground;
    private Image m_img_vida;
    //[SerializeField] private Image m_img_nekoEsfera;
    private GameObject m_GO_nekoEsfera;
    // Start is called before the first frame update
    /*public int ID_BackGorunMusic
    {
        get
        {
            return id_musicBackground;
        }
    }
    public void setIDBackground(int value)
    {
        id_musicBackground = value;
    }*/
    void Start()
    {
        if(m_tipoScene!= GLOBAL_TYPES.TIPO_SCENE.TEST_OST)
        {
            m_GO_nekoEsfera = referencesMASTER.instancia.m_GO_UI_nekoEsfera;
            m_img_vida = referencesMASTER.instancia.m_img_uiVida;
        }

        switch (m_tipoScene)
        {
            case GLOBAL_TYPES.TIPO_SCENE.etapa:
                {
                    setEtapa();
                    break;
                }
            case GLOBAL_TYPES.TIPO_SCENE.nivel:
                {
                    setNivel();
                    break;
                }
            case GLOBAL_TYPES.TIPO_SCENE.TESTEO_SIN_ARMA:
                {
                    setTesteo_sinArma();
                    break;
                }
            case GLOBAL_TYPES.TIPO_SCENE.TESTEO_CON_ARMA:
                {
                    setTesteo_conArma();
                    break;
                }
        }
    }

    internal bool canKeepGun()
    {
        return m_tipoScene == GLOBAL_TYPES.TIPO_SCENE.etapa || m_tipoScene == GLOBAL_TYPES.TIPO_SCENE.TESTEO_CON_ARMA;
    }

    private void setTesteo_conArma()
    {
        m_GO_nekoEsfera.SetActive(false);
        referencesMASTER.instancia.m_GO_UI_volverNivel.SetActive(false);
        //referencesMASTER.instancia.m_GO_UI_CargadorPoder.SetActive(false);
    }

    private void setTesteo_sinArma()
    {
        m_GO_nekoEsfera.SetActive(false);
        m_img_vida.enabled = false;
        referencesMASTER.instancia.m_GO_UI_volverNivel.SetActive(false);
        referencesMASTER.instancia.m_GO_UI_CargadorPoder.SetActive(false);
        //idioma ok
    }

    public GLOBAL_TYPES.TIPO_SCENE getTipoScene() => m_tipoScene;
    private void setEtapa()
    {
        //vida visible
        m_GO_nekoEsfera.SetActive(false);
        //dejar visible opcionde volver al nivel

        transform.GetComponent<setMusicBackground>().setBakcground(m_nameBackground);
        GetComponent<setMusicBackground>().startBackgroundMusic_NO_Repeat();
    }
    private void setNivel()
    {

        GameObject.FindGameObjectWithTag("Data_Singleton").GetComponent<Data_Singleton>().setNextLevel_singleton(SceneManager.GetActiveScene().name);
        m_img_vida.enabled = false;
        //neko esfera visible
        referencesMASTER.instancia.m_GO_UI_volverNivel.SetActive(false);
        referencesMASTER.instancia.m_GO_UI_CargadorPoder.SetActive(false);
        
        transform.GetComponent<setMusicBackground>().setBakcground(m_nameBackground);
        GetComponent<setMusicBackground>().startBackgroundMusic_NO_Repeat();
       // GetComponent<setMusicBackground>().startBackgroundMusic();sdsd
    }





}
