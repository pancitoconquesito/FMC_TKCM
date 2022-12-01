using UnityEngine;
using UnityEngine.Events;
public class SUB_cambioIdioma : MonoBehaviour
{
    public UnityEvent OnCambiarLenguaje;
    private GestorCambioIdioma m_GestorCambioIdioma;
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
