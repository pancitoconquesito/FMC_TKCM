using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Gestor_UI_Bioma : MonoBehaviour
{
    [SerializeField] private GameObject m_uiBioma_GO;
    [SerializeField] private GameObject m_firstGO;
    [SerializeField] private CambiarScene m_CambiarScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private bool activado = false;
    internal void comenzar(string m_nameStage)
    {
        activado = true;
        m_CambiarScene.setNameScene(m_nameStage);
        Invoke("ShowWindow",0.5f);
        
    }
    private void ShowWindow()
    {
        if (!activado) return;
        m_uiBioma_GO.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(m_firstGO);
    }
    internal void desactivar()
    {
        activado = false;
        m_uiBioma_GO.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }
}
