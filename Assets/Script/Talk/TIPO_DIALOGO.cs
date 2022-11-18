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
        test,
        lagarto
    }
    public enum EMOTIONS
    {
        normal, pensando, alegre, triste, enojado, asustado, cringe
    }


    static public string getName(TIPO_DIALOGO.PJ_NAMES _name)
    {
        string retorno = "ERROR";
        switch (_name)
        {
            case PJ_NAMES.PJ: { retorno = "Pj"; break; }
            case PJ_NAMES.test: { retorno = "Test";break; }
            case PJ_NAMES.lagarto: { retorno = "lagarto"; break; }
        }
        return retorno;
    }
    static public string get_REAL_UI_Name(TIPO_DIALOGO.PJ_NAMES _name, GLOBAL_TYPES.IDIOMA _idioma)
    {
        string retorno = "ERROR";
        switch (_idioma)
        {
            case GLOBAL_TYPES.IDIOMA.ES:
                {
                    switch (_name)
                    {
                        case PJ_NAMES.PJ: { retorno = "Betty"; break; }
                        case PJ_NAMES.test: { retorno = "Test"; break; }
                        case PJ_NAMES.lagarto: { retorno = "Lagarto botánico"; break; }
                    }
                    break;
                }
            case GLOBAL_TYPES.IDIOMA.EN:
                {
                    switch (_name)
                    {
                        case PJ_NAMES.PJ: { retorno = "Betty"; break; }
                        case PJ_NAMES.test: { retorno = "Test"; break; }
                        case PJ_NAMES.lagarto: { retorno = "Botanical lizard"; break; }
                    }
                    break;
                }
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
            case EMOTIONS.triste: { retorno = "_triste"; break; }
            case EMOTIONS.cringe: { retorno = "_cringe"; break; }
            case EMOTIONS.asustado: { retorno = "_asustado"; break; }

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
    static public int getIDIOMA_INT(TIPO_DIALOGO.IDIOMA _idioma)
    {
        int retorno = 0;
        switch (_idioma)
        {
            case IDIOMA.es: { retorno = 0; break; }
            case IDIOMA.en: { retorno = 1; break; }
        }
        return retorno;
    }
    static public GLOBAL_TYPES.IDIOMA getIDIOMA_TIPO(int _idioma)
    {
        GLOBAL_TYPES.IDIOMA retorno = 0;
        switch (_idioma)
        {
            case 0: { retorno = GLOBAL_TYPES.IDIOMA.ES; break; }
            case 1: { retorno = GLOBAL_TYPES.IDIOMA.EN; break; }
        }
        return retorno;
    }
}
