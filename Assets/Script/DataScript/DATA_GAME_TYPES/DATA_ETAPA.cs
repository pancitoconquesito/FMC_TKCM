using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DATA_ETAPA
{
    public bool completado;
    public string nombre;
    public int numeroNivel;
    public int numeroBioma;
    public DATA_ETAPA(string _nombre, int _numeroNivel, int _numeroBioma)
    {
        nombre = _nombre;
        numeroNivel = _numeroNivel;
        numeroBioma = _numeroBioma;
    }
}
