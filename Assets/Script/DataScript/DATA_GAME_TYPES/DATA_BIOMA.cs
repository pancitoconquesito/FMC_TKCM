using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DATA_BIOMA 
{
    public DATA_ETAPA[] L_etapas;
    public string nombre;
    public DATA_BIOMA(string _nombre, DATA_ETAPA[]  _L_etapas)
    {
        //L_etapas = new DATA_ETAPA[](); { _L_etapas };
        nombre = _nombre;
    }
}
