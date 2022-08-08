using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TIPO_DIALOGO 
{
    public enum IDIOMA
    {
        es, en
    }
    public enum GLOBO
    {
        normal_iz,
        normal_der,
        pensando_iz,
        pensando_der,

    }
    public enum PJ_NAMES
    {
        PJ,
        test
    }
    public enum EMOTIONS
    {
        normal, pensando, alegre, triste, enojado
    }


    static public string getName(TIPO_DIALOGO.PJ_NAMES _name)
    {
        string retorno = "ERROR";
        switch (_name)
        {
            case PJ_NAMES.PJ: { retorno = "Pj"; break; }
            case PJ_NAMES.test: { retorno = "Test";break; }
        }
        return retorno;
    }
    static public string getEmotion(TIPO_DIALOGO.EMOTIONS _emotion)
    {
        string retorno = "ERROR";
        switch (_emotion)
        {
            case EMOTIONS.normal: { retorno = "_normal"; break; }
            case EMOTIONS.pensando: { retorno = "_pensando"; break; }
        }
        return retorno;
    }
    static public string getGlobo(TIPO_DIALOGO.GLOBO _globo)
    {
        string retorno = "ERROR";
        switch (_globo)
        {
            case GLOBO.normal_iz: { retorno = "globo_normal_iz"; break; }
            case GLOBO.normal_der: { retorno = "globo_normal_der"; break; }
            case GLOBO.pensando_iz: { retorno = "globo_pensando_iz";break; }
            case GLOBO.pensando_der: { retorno = "globo_pensando_der"; break; }
        }
        return retorno;
    }
    static public int getIDIOMA(TIPO_DIALOGO.IDIOMA _idioma)
    {
        int retorno = 0;
        switch (_idioma)
        {
            case IDIOMA.es: { retorno = 0; break; }
            case IDIOMA.en: { retorno = 1; break; }
        }
        return retorno;
    }
}
