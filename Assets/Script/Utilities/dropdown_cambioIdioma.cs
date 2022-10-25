using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class dropdown_cambioIdioma : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown m_Dropdown;
    [SerializeField] private GameObject m_GO_content;
    private Toggle m_Toggle_ESP, m_Toggle_EN;
    private GestorCambioIdioma m_GestorCambioIdioma;
    private int valorIdiomaSelect = 0;
    private GLOBAL_TYPES.IDIOMA m_idioma;
    void Start()
    {
        m_GestorCambioIdioma = referencesMASTER.instancia.m_GestorCambioIdioma;
    }
    public void OnDropDownChanged()
    {
        print("Se cambio");
        valorIdiomaSelect = m_Dropdown.value;
        if(m_GestorCambioIdioma==null) m_GestorCambioIdioma = referencesMASTER.instancia.m_GestorCambioIdioma;
        m_GestorCambioIdioma.InvokeCambioIdioma(valorIdiomaSelect);
    }
    
    private void OnEnable()
    {
        valorIdiomaSelect = DATA.instance.getIdioma_INT();
        m_Dropdown.value = valorIdiomaSelect;
    }
}
