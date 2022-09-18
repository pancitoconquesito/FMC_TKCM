using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testIdiomaSAVE_LOAD : MonoBehaviour
{
    private GLOBAL_TYPES.IDIOMA m_idioma;

    private void Start()
    {
        cargarIdioma();
    }
    private void cargarIdioma()
    {
        int valorIdioma = PlayerPrefs.GetInt("idioma",0);
        switch (valorIdioma)
        {
            case 0: { m_idioma = GLOBAL_TYPES.IDIOMA.ES; break; }
            case 1: { m_idioma = GLOBAL_TYPES.IDIOMA.EN; break; }
        }
        //print("Idioma actual : "+m_idioma);
    }
    public GLOBAL_TYPES.IDIOMA getIdioma()
    {
        return m_idioma;
    }
    public void setIdioma(int valorIdioma)
    {
        switch (valorIdioma)
        {
            case 0: { m_idioma = GLOBAL_TYPES.IDIOMA.ES; break; }
            case 1: { m_idioma = GLOBAL_TYPES.IDIOMA.EN; break; }
        }
    }
    public void saveIdioma()
    {
        PlayerPrefs.SetInt("idioma", GLOBAL_TYPES.parseIdioma(m_idioma));
    }
}
