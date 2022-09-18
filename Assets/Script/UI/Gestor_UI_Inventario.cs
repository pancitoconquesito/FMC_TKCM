using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.UI;
using UnityEngine.EventSystems;
public class Gestor_UI_Inventario : MonoBehaviour
{
    [SerializeField] private GameObject m_obgALL;
    [SerializeField]private GameObject firstButton;
    private NewControls m_ControlINVENTARY;
    private void Start()
    {
        
    }
    private void OnEnable()
    {
        habilitarControles();
    }
    private void habilitarControles()
    {
        print("HOLO!");
        
        
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
            EventSystem.current.SetSelectedGameObject(firstButton);
        }
    }
}
