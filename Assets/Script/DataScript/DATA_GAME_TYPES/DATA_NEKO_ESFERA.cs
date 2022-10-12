using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DATA_NEKO_ESFERA
{
    public DATA_ETAPA[] L_D_etapas;
    public DATA_ETAPA[] L_D_etapas_SECRETAS;
    public int cantidadDe_NekoEsfera;

    public DATA_NEKO_ESFERA()
    {
        cantidadDe_NekoEsfera = 0;

        int TAM_NIVELES = 5;
        int TAM_BIOMAS = 3;
        int TAM_ETAPAS = 4;
        int TAM_SECRETAS = TAM_NIVELES;

        int posicion = 0;
        L_D_etapas = new DATA_ETAPA[TAM_NIVELES * TAM_BIOMAS * TAM_ETAPAS];
        for (int n = 0; n < TAM_NIVELES; n++)//nivel
        {
            for (int b = 0; b < TAM_BIOMAS; b++)//bioma
            {
                for (int e = 0; e < TAM_ETAPAS; e++)//etapa
                {
                    //int posicion = j * (TAM_ETAPAS - 1) + k;
                    //Debug.Log("posicion : "+posicion);
                    DATA_ETAPA nuevaEtapa = new DATA_ETAPA($"N{n} - B{b} - E{e}", n, b);
                    L_D_etapas[posicion] = nuevaEtapa;
                    posicion++;
                }
            }
        }

        L_D_etapas_SECRETAS = new DATA_ETAPA[TAM_SECRETAS];
        for (int i = 0; i < TAM_SECRETAS; i++)
        {
            DATA_ETAPA nuevaEtapaSecreta = new DATA_ETAPA($"ESPECIAL {i}", i, -1);
            L_D_etapas_SECRETAS[i] = nuevaEtapaSecreta;
        }
    }
    
}
