using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMirada : MonoBehaviour
{
    //[SerializeField] private SpriteRenderer m_spriteRenderer;
    //[SerializeField] private Transform m_transdformPJ;



    [SerializeField] private bool miradaNormalDerecha;
    [SerializeField] private float offsetInput;
    [SerializeField] private GameObject[] objVolteables;


    //enum Type_ladosMirada { iz, der }
    private Vector3[] lista_tamOriginal;
    private GLOBAL_TYPES.ladoMirada mirada;
    private GLOBAL_TYPES.ladoMirada currentMirada;
    private void Start()
    {
        lista_tamOriginal = new Vector3[objVolteables.Length];
        for (int i = 0; i < lista_tamOriginal.Length; i++)
        {
            lista_tamOriginal[i] = objVolteables[i].transform.localScale;
        }
        if (miradaNormalDerecha)
        {
            mirada = GLOBAL_TYPES.ladoMirada.derecha;
            currentMirada = GLOBAL_TYPES.ladoMirada.derecha;
            mirarDer();
        }
        else
        {
            mirada = GLOBAL_TYPES.ladoMirada.izquierda;
            currentMirada = GLOBAL_TYPES.ladoMirada.izquierda;
            mirarIZ();
        }
    }
    public GLOBAL_TYPES.ladoMirada getMirada()
    {
        return mirada;
    }
    public void miradaPj(float valor)
    {
        if (valor < 0f- offsetInput) currentMirada = GLOBAL_TYPES.ladoMirada.izquierda;
        if (valor > 0f+ offsetInput) currentMirada = GLOBAL_TYPES.ladoMirada.derecha;
        if (currentMirada != mirada)
        {
            mirada = currentMirada;
            changeMiradaFuncion();
        }
    }
    private void changeMiradaFuncion()
    {
        switch (currentMirada)
        {
            case GLOBAL_TYPES.ladoMirada.izquierda: { mirarIZ(); break; }
            case GLOBAL_TYPES.ladoMirada.derecha: { mirarDer(); break; }
        }
    }
    private void mirarIZ()
    {
        for (int i = 0; i < objVolteables.Length; i++)
        {
            if (miradaNormalDerecha)
                objVolteables[i].transform.localScale = new Vector3(-lista_tamOriginal[i].x, lista_tamOriginal[i].y, lista_tamOriginal[i].z);
            else
                objVolteables[i].transform.localScale = lista_tamOriginal[i];
        }
    }
    private void mirarDer()
    {
        for (int i = 0; i < objVolteables.Length; i++)
        {
            if(miradaNormalDerecha)
                objVolteables[i].transform.localScale = lista_tamOriginal[i];
            else
                objVolteables[i].transform.localScale = new Vector3(-lista_tamOriginal[i].x, lista_tamOriginal[i].y, lista_tamOriginal[i].z);
        }
    }
}
