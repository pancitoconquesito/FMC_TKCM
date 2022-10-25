using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_NekoEsfera : ItemsCol
{
    [Header("-- ColNeko Params --")]
    [SerializeField] private CambiarScene m_CambiarScene;
    [SerializeField] private float delayTransicion;
    [SerializeField] private float delayChangeStage;
    [SerializeField] private Collider2D m_Collider2D;
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        print("hijo");
        m_Collider2D.enabled = false;
        //m_ACTION_TO_GET = ACTION_TO_GET.animation;
        // inhabilitar pj mov
        // no danio pj
        // set anim festejo => camara + cerca
        referencesMASTER.instancia.m_movementPJ.getNekoEsfera();
        // esfera get animation

        // anim target
        //referencesMASTER.instancia.m_animatorNekoEsfera.Settrigger("Start");


        // transicion
        //referencesMASTER.instancia.
        Invoke("transicion", delayTransicion);
        // exit etapa
        Invoke("changeStage", delayChangeStage);

        base.OnTriggerEnter2D(collision);
    }
    private void transicion()
    {
        print("transicion");
        referencesMASTER.instancia.m_anim_UI_transicion.SetTrigger("negro");

    }
    private void changeStage()
    {
        print("changeStage");

        m_CambiarScene.changeScene();
    }
}
