using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class referencesMASTER : MonoBehaviour
{
    public static referencesMASTER instancia;
    public movementPJ m_movementPJ;
    public gestorConversacion m_gestorConversacion;
    public CinemachineCameraOffset offsetCamera_X_Talk;
    public SpriteRenderer sp_brazo;
    public SpriteRenderer sp_Arma;
    public Animator animator_ARMA;
    public ObjectPooling ObjectPooling_BALA_PJ;
    public changeMirada miradaPJ;
    public shootPJ m_shootPJ;
    public Transform m_transformPJ;
    // Start is called before the first frame update

    private void Awake()
    {
        instancia=this;
    }

}
