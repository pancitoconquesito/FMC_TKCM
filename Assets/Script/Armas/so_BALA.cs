using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bala", menuName = "ARMA/Bala")]
public class so_BALA : ScriptableObject
{
    //public int danio;// cuando danio hace al objetivo
    public float empuje;//cuando empuja al objetivo 
    //public bool rebote;// si rebota al chocar con un solido
    public float duracion;//cuanto dura antes de destruirse

    public string dirPrefab;
    public float velocidadBala;
    //public bool rebote;
    //[Header("- DANIO -")]
    //public dataDanio m_dataDanio;
}
