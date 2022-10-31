using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ui_corazon : MonoBehaviour
{
    [SerializeField] private RectTransform m_RectTransformCorazones;
    [SerializeField] private int cantidadCorazones;
    private float tamanio;
    void Start()
    {
        cantidadCorazones = GameObject.FindGameObjectWithTag("Data_Singleton").GetComponent<Data_Singleton>().getCantidadVidaPJ();
        tamanio = m_RectTransformCorazones.sizeDelta.x;
        //print($"VIDA : {cantidadCorazones}  ___ tamanio: {tamanio}");
        if (tamanio == 0) tamanio = 130;
        m_RectTransformCorazones.sizeDelta = new Vector2(tamanio * cantidadCorazones, tamanio);

    }
    public void updateVida_UI(int cantidadCorazonesActual)
    {
        cantidadCorazones = cantidadCorazonesActual;
        m_RectTransformCorazones.sizeDelta = new Vector2(tamanio * cantidadCorazones, tamanio);
    }
}
