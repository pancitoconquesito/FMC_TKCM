using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAudio : MonoBehaviour
{
    public static testAudio instancia;
    [SerializeField] private AudioSource m_audioSRC_background;
    [SerializeField] private AudioSource m_audioSRC_FX;
    [SerializeField] private AudioSource m_audioSRC_voces;
    //[SerializeField] private AudioSource m_audioSRC_master;
    [SerializeField] private setValueWithSlider[] L_setValueWithSlider;
    private float _MASTER;
    private void Awake()
    {
        instancia = this;

        //volumeSave_background = PlayerPrefs.GetFloat("volumen_background", 100f);
        //volumeSave_fx = PlayerPrefs.GetFloat("volumen_fx", 100f);
        //volumeSave_voces = PlayerPrefs.GetFloat("volumen_voces", 100f);

        
        //print("volumeSave_background : "+ volumeSave_background);
    }
    private float volumeSave_background;
    private float volumeSave_fx;
    private float volumeSave_voces;
    private void Start()
    {
        _MASTER = DATA.instance.save_load_system.m_dataGame.m_DATA_CONF_AUDIO.lv_MASTER;
        volumeSave_background = DATA.instance.save_load_system.m_dataGame.m_DATA_CONF_AUDIO.lv_BackgroundMusic;
        volumeSave_fx = DATA.instance.save_load_system.m_dataGame.m_DATA_CONF_AUDIO.lv_FX;
        volumeSave_voces = DATA.instance.save_load_system.m_dataGame.m_DATA_CONF_AUDIO.lv_Voces;
        foreach (var item in L_setValueWithSlider)
            item.startValues();
    }
    public float getVolumenSave_MASTER() { return _MASTER; }
    public float getVolumenSave_background() { return volumeSave_background; }
    public float getVolumenSave_fx() { return volumeSave_fx; }
    public float getVolumenSave_voces() { return volumeSave_voces; }


    [SerializeField] private UnityEngine.UI.Slider[] sliderTEST;
    public void BTN_updateSaveVolumen()
    {
        //FIX
        print("back : "+ sliderTEST[0].value);
        volumeSave_background = sliderTEST[0].value;
        volumeSave_fx = sliderTEST[1].value;
        volumeSave_voces = sliderTEST[2].value;
        updateSaveVolumen();
    }
    private void updateSaveVolumen()
    {
        //FIX
        DATA.instance.save_load_system.m_dataGame.m_DATA_CONF_AUDIO.lv_MASTER = _MASTER;
        DATA.instance.save_load_system.m_dataGame.m_DATA_CONF_AUDIO.lv_BackgroundMusic = volumeSave_background;
        DATA.instance.save_load_system.m_dataGame.m_DATA_CONF_AUDIO.lv_FX = volumeSave_fx;
        DATA.instance.save_load_system.m_dataGame.m_DATA_CONF_AUDIO.lv_Voces= volumeSave_voces;

        DATA.instance.save_load_system.save_();
        /*PlayerPrefs.SetFloat("volumen_background", volumeSave_background);
        PlayerPrefs.SetFloat("volumen_fx", volumeSave_fx);
        PlayerPrefs.SetFloat("volumen_voces", volumeSave_voces);*/
    }
    public void setVolumen_MASTER(float valor)
    {
        //valor /= 100f;
        //print("valor Master: "+valor);//0-1
        //m_audioSRC_master.volume = valor ;
        _MASTER = valor;
        for (int i = 0; i < 3; i++)
        {
            L_setValueWithSlider[i].updateWithMaster();
        }
        //updateSaveVolumen_With_MASTER();
    }
    /*
    private void updateSaveVolumen_With_MASTER()
    {
        setVolumenBackground(lastBackground);
        setVolumen_FX(lastFx);
        setVolumenVoces(lastVoces);
    }*/
    //private float lastBackground, lastFx, lastVoces;
    public void setVolumenBackground(float valor)
    {
        //valor /= 100f;
        //print("valor : "+valor);//0-1
        //lastBackground = valor;
        m_audioSRC_background.volume = valor * _MASTER;
    }
    
    public void setVolumen_FX(float valor)
    {
        //if (valor > 1) valor /= 100;
        //valor /= 100f;
        //lastFx = valor;
        m_audioSRC_FX.volume = valor * _MASTER;
    }
    public void setVolumenVoces(float valor)
    {
        //if (valor > 1) valor /= 100;
        //valor /= 100f;
        //lastVoces = valor;
        m_audioSRC_voces.volume = valor * _MASTER;
    }


    //STOP
    public void detenerBackground() { m_audioSRC_background.Stop(); }
    public void detenerFX() { m_audioSRC_FX.Stop(); }
    public void detenerVoces() { m_audioSRC_voces.Stop(); }
    //PLAY
    public void playBackground(AudioClip _audioClip) { m_audioSRC_background.Stop(); m_audioSRC_background.clip = _audioClip; m_audioSRC_background.Play(); }
    public void playFX(AudioClip _audioClip) { m_audioSRC_FX.Stop(); m_audioSRC_FX.clip = _audioClip; m_audioSRC_FX.Play();}
    public void playVoces(AudioClip _audioClip) { m_audioSRC_voces.Stop(); m_audioSRC_voces.clip = _audioClip; m_audioSRC_voces.Play(); }
}
