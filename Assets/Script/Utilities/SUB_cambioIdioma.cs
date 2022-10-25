using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SUB_cambioIdioma : MonoBehaviour
{
    public UnityEvent OnCambiarLenguaje;
    private GestorCambioIdioma m_GestorCambioIdioma;
    // Start is called before the first frame update
    void Start()
    {
        if (referencesMASTER.instancia == null) m_GestorCambioIdioma = GetComponent<GestorCambioIdioma>();
        else m_GestorCambioIdioma = referencesMASTER.instancia.m_GestorCambioIdioma;
        m_GestorCambioIdioma.CambioLenguaje += cambioLenguaje;
    }

    private void cambioLenguaje()
    {
        //print("Cambio lenguaje!!!!!");
        OnCambiarLenguaje.Invoke();
    }
}
