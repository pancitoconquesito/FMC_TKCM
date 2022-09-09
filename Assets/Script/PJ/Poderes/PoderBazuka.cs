using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderBazuka : PoderBase
{
    [SerializeField] private GameObject objExplosion;
    [SerializeField] private Animator m_Animator_PJ;
    [SerializeField] private Animator m_Animator_Explosion;
    public PoderBazuka() : base()
    {

    }
    void Start()
    {
        base.m_UpdateCirclePower = referencesMASTER.instancia.m_UpdateCirclePower;
        base.m_UpdateRecargaPoder = referencesMASTER.instancia.m_UpdateRecargaPoder;
        base.m_UpdateRecargaPoder.setParameters(base.tiempoRecarga);
        m_Animator_PJ = referencesMASTER.instancia.m_animatorPJ;
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
        m_Animator_PJ.SetInteger("PODER_DATA", PODER_DATA.PoderBAzuka);
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

    }
}
