using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DATA_NIVEL 
{
    public int numeroNivel;
    public DATA_BIOMA[] L_Biomas; 
    public DATA_NIVEL(int _numeroNivel)
    {
        numeroNivel = _numeroNivel;
        L_Biomas = new DATA_BIOMA[] { };
    }
}
