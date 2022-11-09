using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
public class referencesMASTER : MonoBehaviour
{
    public static referencesMASTER instancia;
    [Header("------------  PJ  ------------")]
    public Transform    m_transformPJ;
    public movementPJ   m_movementPJ;
    public vida_PJ      m_vida_PJ;
    public Animator     m_animatorPJ;
    public Animator     m_brazoPJ;
    public changeMirada miradaPJ;
    public shootPJ      m_shootPJ;
    public GameObject   m_GO_recibirDanio;
    public respawnPJ m_respawnPJ;

    [Header("------------  ARMA  ------------")]
    public SpriteRenderer   sp_brazo;
    public SpriteRenderer   sp_Arma;
    public Animator         animator_ARMA;
    public ObjectPooling    ObjectPooling_BALA_PJ;

    [Header("------------  CAM  ------------")]
    public CinemachineCameraOffset offsetCamera_X_Talk;

    [Header("------------  UI  ------------")]
    public gestorConversacion   m_gestorConversacion;
    public UpdateCirclePower    m_UpdateCirclePower;
    public UpdateRecargaPoder   m_UpdateRecargaPoder;
    public Gestor_UI_Inventario m_Gestor_UI_Inventario;
    public Gestor_UI_Bioma      m_Gestor_UI_Bioma;
    public ui_corazon           m_ui_corazon;
    public Image                m_img_uiVida;
    public GameObject           m_GO_UI_nekoEsfera;
    public GameObject           m_GO_UI_CargadorPoder;
    public GameObject           m_GO_UI_volverNivel;
    public GameObject           m_GO_UI_died;
    public Animator             m_anim_UI_transicion;
    public Animator             m_at_ui_dolor;
    public GameObject           m_GO_ConfinerCamera;

    [Header("-- Xtra --")]
    public Data_Singleton m_Data_Singleton;
    public DataScene m_DataScene;
    public GestorCambioIdioma m_GestorCambioIdioma;

    private void Awake()
    {
        instancia =this;
        m_DataScene = GameObject.FindGameObjectWithTag("DataScene").GetComponent<DataScene>();
        m_Data_Singleton = GameObject.FindGameObjectWithTag("Data_Singleton").GetComponent<Data_Singleton>();
    }
    public void disableALL()
    {
        m_movementPJ.disabledALL();
    }
}
