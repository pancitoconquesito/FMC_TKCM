using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Arma", menuName = "ARMA/Arma")]
public class so_ARMA : ScriptableObject
{
    [Header("- ARMA -")]
    public float cadencia;
    public float retroceso_pj;
    //public float retroceso_NS;
    public TIPO_arma.Au au_noAu;
    public bool instantaneo;
    public int cantidadPool;

    [Header("- Shake -")]
    public float shake_amount;
    public float shake_time;

    [Header("- BALA -")]
    public so_BALA _bala;
    //public string dirPrefab;
    //public float velocidadBala;
    //public float[] probBalas;

    [Header("- CONFIG PJ -")]
    public so_CONFIG_PJ m_so_CONFIG_PJ;
}
