using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class referencesMASTER : MonoBehaviour
{
    public static referencesMASTER instancia;
    [Header("------------  PJ  ------------")]
    public Transform m_transformPJ;
    public movementPJ m_movementPJ;
    public vida_PJ m_vida_PJ;
    public Animator m_animatorPJ;
    public changeMirada miradaPJ;
    public shootPJ m_shootPJ;

    [Header("------------  ARMA  ------------")]
    public SpriteRenderer sp_brazo;
    public SpriteRenderer sp_Arma;
    public Animator animator_ARMA;
    public ObjectPooling ObjectPooling_BALA_PJ;

    [Header("------------  CAM  ------------")]
    public CinemachineCameraOffset offsetCamera_X_Talk;

    [Header("------------  UI  ------------")]
    public gestorConversacion m_gestorConversacion;
    public UpdateCirclePower m_UpdateCirclePower;
    public UpdateRecargaPoder m_UpdateRecargaPoder;
    public Gestor_UI_Inventario m_Gestor_UI_Inventario;
    public Gestor_UI_Bioma m_Gestor_UI_Bioma;

    private void Awake()
    {
        instancia=this;
    }

    public void disableALL()
    {
        m_movementPJ.disabledALL();
    }
}
