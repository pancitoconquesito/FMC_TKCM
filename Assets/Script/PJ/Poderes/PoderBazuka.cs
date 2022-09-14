using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderBazuka : PoderBase
{
    [SerializeField] private GameObject objExplosion;
    [SerializeField] private Animator m_Animator_PJ;
    [SerializeField] private Animator m_Animator_Explosion;
    [SerializeField] private movementPJ m_movementPJ;
    public PoderBazuka() : base()
    {

    }
    private void Awake()
    {
        objExplosion.SetActive(false);
    }
    void Start()
    {
        //base.m_UpdateCirclePower = referencesMASTER.instancia.m_UpdateCirclePower;
        //base.m_UpdateRecargaPoder = referencesMASTER.instancia.m_UpdateRecargaPoder;
        //base.m_UpdateRecargaPoder.setParameters(base.tiempoRecarga);
        base.startParameterBase();
        m_Animator_PJ = referencesMASTER.instancia.m_animatorPJ;
        m_movementPJ = referencesMASTER.instancia.m_movementPJ;
    }
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
        print("ExplOsion!!!");
        objExplosion.SetActive(true);
        m_movementPJ.setEstadoAlterado_param(GLOBAL_TYPES.ESTADO_ALTERADO.explosionSonica, null);
        m_Animator_PJ.SetInteger("PODER_DATA", PODER_DATA.PoderBAzuka_anim);
        m_Animator_PJ.ResetTrigger("TriggerPoder");
        m_Animator_PJ.SetTrigger("TriggerPoder");
        //m_Animator_Explosion.SetTrigger("Start");
    }
    public override void disablePower()
    {
        base.disablePower();
        //efectos de cierre?
        print("Poder desactivado");
        objExplosion.SetActive(false);
        m_movementPJ.setEstadoAlterado_param(GLOBAL_TYPES.ESTADO_ALTERADO.none, null);

    }
}
