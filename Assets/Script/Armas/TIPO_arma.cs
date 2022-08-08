using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TIPO_arma 
{
    public enum ArmaTipo
    {
        pistola, bazuca, ametralladora, plasma
    }
    public enum Au
    {
        automatica, NO_automatica
    }
    // ///               CAMBIAR SI SE AGREGA OTRA ARMA(LOS 2 PARSE)
    public static int getParse_TipoArma_INTEGER(TIPO_arma.ArmaTipo arma)
    {
        int retorno = 0;
        switch (arma)
        {
            case TIPO_arma.ArmaTipo.pistola:
                {
                    retorno = 0;
                    break;
                }
            case TIPO_arma.ArmaTipo.bazuca:
                {
                    retorno = 1;
                    break;
                }
            case TIPO_arma.ArmaTipo.ametralladora:
                {
                    retorno = 2;
                    break;
                }
            case TIPO_arma.ArmaTipo.plasma:
                {
                    retorno = 3;
                    break;
                }
        }
        return retorno;
    }
    
    public static string getParse_TipoArma_STRING(TIPO_arma.ArmaTipo arma)
    {
        string retorno = "ERROR";
        switch (arma)
        {
            case TIPO_arma.ArmaTipo.pistola:
                {
                    retorno = "Pistola";
                    break;
                }
            case TIPO_arma.ArmaTipo.bazuca:
                {
                    retorno = "Bazuka";
                    break;
                }
            case TIPO_arma.ArmaTipo.ametralladora:
                {
                    retorno = "Ametralladora";
                    break;
                }
            case TIPO_arma.ArmaTipo.plasma:
                {
                    retorno = "Plasma";
                    break;
                }
        }
        return retorno;
    }
}
