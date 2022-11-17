using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SO_parrafo
{
    [Header("----- PJS -----")]
    public bool IZ_isTalking;
    public SO_PJ_EMOTION pj_iz;
    public SO_PJ_EMOTION pj_der;

    [Header("----- GLOBO -----")]
    public TIPO_DIALOGO.GLOBO sp_globo;
    //public Sprite sp_btnNext;

    //[Header("----- NOMBRES -----")]
    //public string[] text_name;//es:0 en:1
    
    [Space(15)]

    [Header("----- TEXTO:IDIOMA => [ 0: ES | 1: EN ]  -----")]
    public SO_IDIOMA[] text_IDIOMA;


    //
}
