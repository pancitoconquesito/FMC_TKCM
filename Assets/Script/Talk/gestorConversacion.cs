using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class gestorConversacion : MonoBehaviour
{
    [SerializeField] private GameObject fullPanel;
    [SerializeField] private Animator m_animator;

    [Header("-- Param --")]
    [SerializeField] private Image img_IZ;
    [SerializeField] private Image img_DER;
    [SerializeField] private Image img_globo;
    [SerializeField] private Image img_btnNext;
    [SerializeField] private TextMeshProUGUI text_text;
    [SerializeField] private TextMeshProUGUI text_name_iz;
    [SerializeField] private TextMeshProUGUI text_name_der;

    private SO_DIALOGO dialogoActual;
    private GLOBAL_TYPES.IDIOMA currentIdioma_tipo;
    private int current_Idioma;

    private int totalTurnos;
    private int current_turno;

    private int totalParrafos;
    private int current_parrafo;

    private Coroutine rutinaMostrarTexto;
    private triggerTalk m_triggerTalk;
    public void comenzarConversacion(SO_DIALOGO so_dialogo, triggerTalk _triggerTalk)
    {
        m_triggerTalk = _triggerTalk;
        parrafoComplete = false;
        fullPanel.SetActive(true);

        dialogoActual = so_dialogo;

        //current_Idioma = TIPO_DIALOGO.getIDIOMA(TIPO_DIALOGO.IDIOMA.es);//TODO: CARGAR IDIOMA
        current_Idioma = DATA.instance.getIdioma_INT();
        currentIdioma_tipo = TIPO_DIALOGO.getIDIOMA_TIPO(current_Idioma);

        totalTurnos = dialogoActual.parrafo.Length;
        current_turno= 0;

        totalParrafos=dialogoActual.parrafo[current_turno].text_IDIOMA[current_Idioma].text_textoParrafo.Length;
        current_parrafo=0;

        rutinaMostrarTexto = StartCoroutine(mostrarTexto());
        // Resources.Load<Sprite>("Conv_PJ/" + m_conversacion.parrafos[currentSTEP].PJ_img);
    }
    IEnumerator mostrarTexto()
    {
        updateSRC();
        //print("totalParrafos : "+ totalParrafos);
        parrafoComplete = false;
        int largoParrafo = textoParrafo.Length;
        string textoMostrado = "";
        for(int i = 0; i < largoParrafo; i++)
        {
            switch (textoParrafo[i])
            {
                case '*':
                    {
                        yield return new WaitForSeconds(0.5f);
                        break;
                    }
                default:
                    {
                        textoMostrado += textoParrafo[i];
                        text_text.text = textoMostrado;
                        yield return new WaitForSeconds(0.01f);
                        break;
                    }
            }
        }
        parrafoComplete = true;
        img_btnNext.color = new Color32(255, 255, 255, 255);
    }
    public void siguiente()
    {
        //print("siguiente");
        // ver si el texto esta listo, promover a un booleano
        if (parrafoComplete)
        {
            // aumentar
            current_parrafo++;
            if (current_parrafo == totalParrafos)
            {
                current_parrafo = 0;
                current_turno++;
            }
            // ver si es el final
            if(current_turno == totalTurnos)
            {
                // si es final hay que cambiar de estado en conversacion
                //salir
                //m_triggerTalk
                StopCoroutine(rutinaMostrarTexto);
                //m_animator.SetTrigger("Exit");
                fullPanel.SetActive(false);
                m_triggerTalk.exit();
                return;
            }
            // actualizar
            StopCoroutine(rutinaMostrarTexto);
            rutinaMostrarTexto = StartCoroutine(mostrarTexto());
        }
        else
        {
            StopCoroutine(rutinaMostrarTexto);
            //completar texto
            parrafoComplete = true;
            string textoSinSimbolos="";
            for (int i = 0; i < textoParrafo.Length; i++)
            {
                if (textoParrafo[i] != '*') textoSinSimbolos += textoParrafo[i];
            }
            text_text.text = textoSinSimbolos;
            parrafoComplete = true;
            img_btnNext.color = new Color32(255, 255, 255, 255);
        }
    }
    private string textoParrafo;
    private bool parrafoComplete;
    private void updateSRC()//"Conv_PJ/ pj_pensando"
    {
        /*print("iz : "+ "Conv_PJS/"
            + TIPO_DIALOGO.getName(dialogoActual.parrafo[current_turno].pj_iz.sp_PJ)
            + TIPO_DIALOGO.getEmotion(dialogoActual.parrafo[current_turno].pj_iz.sp_emotion));

        print("der : " + "Conv_NPC/"
            + TIPO_DIALOGO.getName(dialogoActual.parrafo[current_turno].pj_iz.sp_PJ)
            + TIPO_DIALOGO.getEmotion(dialogoActual.parrafo[current_turno].pj_iz.sp_emotion));*/

        //pjs
        totalParrafos = dialogoActual.parrafo[current_turno].text_IDIOMA[current_Idioma].text_textoParrafo.Length;
        img_IZ.sprite = Resources.Load<Sprite>("Conv_PJS/"
            + TIPO_DIALOGO.getName(dialogoActual.parrafo[current_turno].pj_iz.sp_PJ)
            + TIPO_DIALOGO.getEmotion(dialogoActual.parrafo[current_turno].pj_iz.sp_emotion));

        img_DER.sprite = Resources.Load<Sprite>("Conv_NPC/"
            + TIPO_DIALOGO.getName(dialogoActual.parrafo[current_turno].pj_der.sp_PJ)
            + TIPO_DIALOGO.getEmotion(dialogoActual.parrafo[current_turno].pj_der.sp_emotion));

        if (dialogoActual.parrafo[current_turno].IZ_isTalking)
        {
            img_IZ.color = new Color32(255, 255, 255, 255);
            img_DER.color = new Color32(200, 200, 200, 120);
        }
        else
        {
            img_IZ.color = new Color32(200, 200, 200, 120);
            img_DER.color = new Color32(255, 255, 255, 255);
        }
        //globo
        img_globo.sprite = Resources.Load<Sprite>("Conv_globo/"
            + TIPO_DIALOGO.getGlobo(dialogoActual.parrafo[current_turno].sp_globo));
        if(current_turno==totalTurnos-1 && current_parrafo== totalParrafos - 1)
        {
            img_btnNext.sprite = Resources.Load<Sprite>("Conv_globo/btn_CLOSE");
        }else img_btnNext.sprite = Resources.Load<Sprite>("Conv_globo/btn_NEXT");
        img_btnNext.color = new Color32(255,255,255,0);
        //nombres
        //current_Idioma
        text_name_iz.text = TIPO_DIALOGO.get_REAL_UI_Name(dialogoActual.parrafo[current_turno].pj_iz.sp_PJ, currentIdioma_tipo);
        text_name_der.text = TIPO_DIALOGO.get_REAL_UI_Name(dialogoActual.parrafo[current_turno].pj_der.sp_PJ, currentIdioma_tipo);

        //text_name_iz.text = TIPO_DIALOGO.getName(dialogoActual.parrafo[current_turno].pj_iz.sp_PJ);
        //text_name_der.text = TIPO_DIALOGO.getName(dialogoActual.parrafo[current_turno].pj_der.sp_PJ);

        //
        textoParrafo = dialogoActual.parrafo[current_turno].text_IDIOMA[current_Idioma].text_textoParrafo[current_parrafo];
        //text_text.text = textoParrafo;
    }

}
