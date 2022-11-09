using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class desactivarBotones : MonoBehaviour
{
    [SerializeField] private Button[] m_L_botones;
    [SerializeField] private float delayActivate;
    private void Start()
    {
        desactivar();
        Invoke("activarBotones",delayActivate);
    }
    public void activarBotones()
    {
        foreach (var item in m_L_botones)
        {
            item.interactable = true;
        }
    }

    public void desactivar()
    {
        foreach (var item in m_L_botones)
        {
            item.interactable = false;
        }
    }
}
