using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.UI;
using UnityEngine.EventSystems;
public class Gestor_UI_Inventario : MonoBehaviour
{
    [SerializeField] private GameObject m_obgALL;
    [SerializeField]private GameObject firstButton_Nivel;
    [SerializeField] private GameObject firstButton_Etapa;
    private NewControls m_ControlINVENTARY;
    private GLOBAL_TYPES.TIPO_SCENE m_tipoScene;
    private void Start()
    {
        m_tipoScene=referencesMASTER.instancia.m_DataScene.getTipoScene();
    }
    private void OnEnable()
    {
        //habilitarControles();
    }
    private void habilitarControles()
    {
        if (m_ControlINVENTARY !=null) return;
        m_ControlINVENTARY = new NewControls();
        m_ControlINVENTARY.INVENTARIO.Enable();
        //EventSystem.current.SetSelectedGameObject(firstButton);
    }
    private void desahabilitar()
    {
        if (m_ControlINVENTARY == null) return;
        m_ControlINVENTARY.PLAYER.Disable();
        m_ControlINVENTARY = null;
    }
    private void OnDestroy() => desahabilitar();
    private void OnDisable() => desahabilitar();
    // Update is called once per frame
    void Update()
    {
        
    }
    public void turnActive(bool valor)
    {
        m_obgALL.SetActive(valor);
        if (!valor)
        {
            EventSystem.current.SetSelectedGameObject(null);
            desahabilitar();
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
            switch (m_tipoScene)
            {
                case GLOBAL_TYPES.TIPO_SCENE.etapa:
                    {
                        EventSystem.current.SetSelectedGameObject(firstButton_Etapa);
                        break;
                    }
                case GLOBAL_TYPES.TIPO_SCENE.nivel:
                    {
                        EventSystem.current.SetSelectedGameObject(firstButton_Nivel);
                        break;
                    }
                case GLOBAL_TYPES.TIPO_SCENE.TESTEO_SIN_ARMA:
                    {
                        EventSystem.current.SetSelectedGameObject(firstButton_Nivel);
                        break;
                    }
                case GLOBAL_TYPES.TIPO_SCENE.TESTEO_CON_ARMA:
                    {
                        EventSystem.current.SetSelectedGameObject(firstButton_Nivel);
                        break;
                    }
            }
            habilitarControles();
        }
        
    }

    internal void closeInventary()
    {
        
        turnActive(false);
    }
}
