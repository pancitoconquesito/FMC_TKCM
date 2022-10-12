using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PoderPlasma : PoderBase
{
    [SerializeField] private so_CONFIG_PJ m_so_CONFIG_PJ;
    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    private Animator m_Animator_PJ;
    private Animator m_brazoPJ;
    private vida_PJ m_vida_PJ;
    private movementPJ m_movementPJ;
    private void Awake()
    {
        m_SpriteRenderer.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        //base.m_UpdateCirclePower = referencesMASTER.instancia.m_UpdateCirclePower;
        //base.m_UpdateRecargaPoder = referencesMASTER.instancia.m_UpdateRecargaPoder;
        //base.m_UpdateRecargaPoder.setParameters(base.tiempoRecarga);
        base.startParameterBase();
        m_Animator_PJ = referencesMASTER.instancia.m_animatorPJ;
        m_vida_PJ = referencesMASTER.instancia.m_vida_PJ;
        m_movementPJ = referencesMASTER.instancia.m_movementPJ;
        m_brazoPJ = referencesMASTER.instancia.m_brazoPJ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void activatePower()
    {
        if (base.comprobar()) base.activatePower();
        else return;


        //implementar explosion
        ejecutarPoder();
    }
    private void ejecutarPoder()
    {
        print("plasma!!!");
        //m_Animator_PJ.SetInteger("PODER_DATA", PODER_DATA.PoderPlasma_anim);
        //m_Animator_PJ.ResetTrigger("TriggerPoder");
        //m_Animator_PJ.SetTrigger("TriggerPoder");
        m_Animator_PJ.SetLayerWeight(PODER_DATA.layer_plasma, 1);
        m_brazoPJ.SetLayerWeight(PODER_DATA.layer_plasma, 1);
        m_vida_PJ.turnInvulnerable(true);
        m_movementPJ.setEstadoAlterado_param(GLOBAL_TYPES.ESTADO_ALTERADO.plasma, m_so_CONFIG_PJ);
        //m_SpriteRenderer.enabled = true;        
    }
    public override void disablePower()
    {
        base.disablePower();
        print("Poder desactivado"); 
        m_Animator_PJ.ResetTrigger("Trigger_exit_plasma");
        m_Animator_PJ.SetTrigger("Trigger_exit_plasma");
        m_Animator_PJ.SetLayerWeight(PODER_DATA.layer_plasma, 0);
        m_brazoPJ.SetLayerWeight(PODER_DATA.layer_plasma, 0);
        m_vida_PJ.turnInvulnerable(false);
        m_movementPJ.setEstadoAlterado_param(GLOBAL_TYPES.ESTADO_ALTERADO.none, null);
       //m_SpriteRenderer.enabled = false;
    }
}
