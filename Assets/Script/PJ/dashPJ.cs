using System;
using UnityEngine;
public class dashPJ : MonoBehaviour
{
    [Header("-- Param --")]
    [SerializeField]private movementPJ m_movementPJ;
    [SerializeField] private Rigidbody2D rigiPJ;
    [SerializeField] private float potenciaDash;
    [SerializeField] private float cadencia;
    [SerializeField] private float duracionDash;
    [SerializeField] private ObjectPooling m_part_dash;
    [SerializeField] private TrailRenderer m_TrailRenderer;
    [SerializeField]private changeMirada m_changeMirada;
    [SerializeField] private Animator m_at_DashRecharge;
    private float current_cadencia;

    public void setValores(float _potenciaDash, float _cadenciaDash, float _duracionDash)
    {
        potenciaDash = _potenciaDash;
        cadencia = _cadenciaDash;
        duracionDash = _duracionDash;
    }


    private void Start()
    {
        current_cadencia = 0;
    }
    private bool mostrarRecharge = false;
    private bool firstDash = false;
    private void Update()
    {
        if (current_cadencia > -1)
            current_cadencia -= Time.deltaTime;
        DashRecharge();
    }

    private void DashRecharge()
    {
        if (current_cadencia < 0 && !mostrarRecharge && firstDash && m_movementPJ.pjCanRechargeDash() && !m_at_DashRecharge.GetCurrentAnimatorStateInfo(0).IsName("anima_dashRecharge_start"))
        {
            mostrarRecharge = true;
            //print("ahhhhhh");
            m_at_DashRecharge.SetTrigger("Start");
        }
    }

    public bool startDash(GLOBAL_TYPES.ladoMirada lado)
    {
        if(current_cadencia < 0)
        {
            firstDash = true;
            mostrarRecharge = false;
            //m_at_DashRecharge.SetTrigger("Start");
            GameObject objDash =  m_part_dash.emitirObj(0.4f,false);
            cameraShake.instancia.shake(4f, 0.5f);
            Vector3 scaleCurrent = objDash.transform.localScale;
            //si mira a la derecha ok, si mira a la izquierda voltear
            if (m_changeMirada.getMirada() == GLOBAL_TYPES.ladoMirada.izquierda)
            {
                //voltear
                objDash.transform.localScale = new Vector3(Mathf.Abs(scaleCurrent.x) *-1, scaleCurrent.y, scaleCurrent.z);
            }
            else
            {
                //ok
                objDash.transform.localScale = new Vector3(Mathf.Abs(scaleCurrent.x), scaleCurrent.y, scaleCurrent.z);
            }
            m_TrailRenderer.enabled = true;
            Invoke("terminarDash", duracionDash);
            
            current_cadencia = cadencia;
            int _lado;
            if (lado == GLOBAL_TYPES.ladoMirada.izquierda)
            {
                _lado = -1;
            }
            else
            {
                _lado = 1;
            }
            rigiPJ.velocity = Vector2.zero;
            rigiPJ.velocity = new Vector2(_lado * potenciaDash, 0) ;
            return true;
        }
        return false;
    }
    private void terminarDash()
    {
        cameraShake.instancia.shake(2f, 0.2f);
        m_movementPJ.returnNormalMovement();
        m_TrailRenderer.enabled = false;
    }

   
}
