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
        normal
    }
    public enum ladoMirada {  izquierda, derecha }

    public enum AFECTA_A_
    {
        daniaA_pj, daniA_ns, daniaA_ALLL, nadie
    }
}
