using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ConfigPJ", menuName = "ARMA/ConfigPJ")]
public class so_CONFIG_PJ : ScriptableObject
{
    [Header("-- Normal Movement -")]
    public float velocidadCaminar;
    public float factorRun;
    public float velocidadLimiteCaida;
    public float potenciaSalto;

    [Header("- WALL -")]
    public float factorCaidaWall;
    public float potenciaRepulsionWALL_X;
    public float potenciaRepulsionWALL_Y;
    public float tiempoInactivoRepulsionWALL;
    public float factorMov_X_RepulsionWALL;

    [Header("- DASH -")]
    public float potenciaDash;
    public float cadenciaDash;
    public float duracionDash;
}
