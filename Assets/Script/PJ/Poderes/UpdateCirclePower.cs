using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateCirclePower : MonoBehaviour
{
    [SerializeField] private Timer m_Timer;
    [SerializeField] private float totalTime;
    [SerializeField] private float percentage;
    [SerializeField] private Animator m_aniamtor_UI_circlePJ;
    private float currentTime;
    private Image m_imagen;
    private bool activo = false;
    // Start is called before the first frame update
    void Start()
    {
        m_imagen = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!activo) return;
        currentTime = m_Timer.getCurrentTime();
        percentage = currentTime / totalTime;
        if (percentage < 0) percentage = 0;
        m_imagen.fillAmount = percentage;
    }
    /*deprecated
    public void setActivo(bool valor)=> m_imagen.enabled = valor;*/
    public void setActivo(bool valor) {

        if (valor)
        {
            m_aniamtor_UI_circlePJ.SetTrigger("start");
        }
        else
        {
            m_aniamtor_UI_circlePJ.SetTrigger("end");
        }
        //m_imagen.enabled = valor;
    } 
    public void setParameters(Timer _Timer)
    {
        m_Timer = _Timer;
        totalTime = m_Timer.getTime();
        activo = true;
        
    }
}
