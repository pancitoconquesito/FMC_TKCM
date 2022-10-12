using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GLOBAL_TYPES 
{

   public enum ESTADOS_PJ
   {
        cinematic,
        normalMovement,
        pain,
        die,
        kick,
        talk,
        inventary,
        jumpingWalk,
        dash,
        special,
   }

    public enum TIPO_DANIO
    {
        normal, instakill
    }
    public enum ladoMirada {  izquierda, derecha }

    public enum AFECTA_A_
    {
        daniaA_pj, daniA_ns, daniaA_ALLL, nadie
    }

    public enum ESTADO_ALTERADO
    {
        none, plasma, explosionSonica
    }
    public enum TIPO_PREFAB
    {
        ITEM, NekoEsfera
    }
    public enum IDIOMA
    {
        ES, EN
    }
    public enum TIPO_SCENE
    {
        etapa, nivel
    }
    internal static int parseIdioma(IDIOMA m_idioma)
    {
        int retorno = 0;
        switch (m_idioma)
        {
            case GLOBAL_TYPES.IDIOMA.ES: { retorno = 0 ; break; }
            case GLOBAL_TYPES.IDIOMA.EN: { retorno = 1 ; break; }
        }
        return retorno;
    }
    public static float Round(float value, int digits)
    {
        float mult = Mathf.Pow(10.0f, (float)digits);
        return Mathf.Round(value * mult) / mult;
    }
    public static bool canInventary(GLOBAL_TYPES.ESTADOS_PJ estado)
    {
        //return estado==GLOBAL_TYPES.ESTADOS_PJ.normalMovement;
        return estado == GLOBAL_TYPES.ESTADOS_PJ.normalMovement || estado==GLOBAL_TYPES.ESTADOS_PJ.inventary || estado == GLOBAL_TYPES.ESTADOS_PJ.special;
    }

    internal static bool canSpecial(ESTADOS_PJ estado)
    {
        return estado != GLOBAL_TYPES.ESTADOS_PJ.talk && estado!=GLOBAL_TYPES.ESTADOS_PJ.inventary;
    }
    internal static bool canKick(ESTADOS_PJ estado)
    {
        return estado == GLOBAL_TYPES.ESTADOS_PJ.normalMovement || estado == GLOBAL_TYPES.ESTADOS_PJ.jumpingWalk;
    }

    internal static bool canDash(ESTADOS_PJ estados)
    {
        return estados == GLOBAL_TYPES.ESTADOS_PJ.normalMovement || estados == GLOBAL_TYPES.ESTADOS_PJ.jumpingWalk;
    }

    internal static bool canShoot(ESTADOS_PJ estados)
    {
        return estados == GLOBAL_TYPES.ESTADOS_PJ.normalMovement || estados == GLOBAL_TYPES.ESTADOS_PJ.jumpingWalk;
    }

    internal static bool canMov_X(ESTADOS_PJ estados)
    {
        return estados == GLOBAL_TYPES.ESTADOS_PJ.normalMovement || estados == GLOBAL_TYPES.ESTADOS_PJ.jumpingWalk || estados == GLOBAL_TYPES.ESTADOS_PJ.pain;
    }

}
