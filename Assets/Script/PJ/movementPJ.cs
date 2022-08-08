using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class movementPJ : MonoBehaviour
{
    [Header("- COMPONENTES EXPUESTOS -")]
    [SerializeField] private Rigidbody2D m_rigidbody;
    [SerializeField] private Animator m_animator;
    [SerializeField] private grounded m_grounded;
    [SerializeField] private checkPared m_checkPared;
    [SerializeField] private changeMirada m_changeMirada;
    [SerializeField] private dashPJ m_dashPJ;
    [SerializeField] private respawnPJ m_respawnPJ;

    [Header("- PARAMETROS MOVEMENT ESTATICOS-")]
    [SerializeField] private float limiteInput_movX;

    [Header("- PARAMETRO SEGUN ARMA (BASICO) -")]
    [SerializeField] private float velocidadCaminar;
    [SerializeField] private float velocidadRun;
    [SerializeField] private float velocidadLimiteCaida;
    [SerializeField] private float potenciaSalto;

    [Header("- PARAMETRO SEGUN ARMA (WALL) -")]
    [SerializeField] private float factorCaidaWall;
    [SerializeField] private float potenciaRepulsionWALL_X;
    [SerializeField] private float potenciaRepulsionWALL_Y;
    [SerializeField] private float tiempoInactivoRepulsion;
    [SerializeField]private float factorMovimientoX_Repulsion;

    [Header("- Kick -")]
    [SerializeField] private float cadenciaKick;
    private float current_cadenciaKick=-1;

    [Header("- Shoot -")]
    [SerializeField] private shootPJ m_shootPJ;

    private NewControls m_ControlPJ;
    private float valorInput_Horizontal;
    private bool m_isGrounded = false;

    private bool isRun = false;
    private GLOBAL_TYPES.ESTADOS_PJ m_estados;
    private bool onWalk = false;
    private bool landed = false;

    private void setControl()
    {
        m_ControlPJ = new NewControls();
        m_ControlPJ.PLAYER.Enable();

        m_ControlPJ.PLAYER.Horizontal.performed += ctx => getInput_Axis_LEFT(ctx.ReadValue<Vector2>().x);
        m_ControlPJ.PLAYER.Horizontal.canceled += setZerotInput_Axis_LEFT;

        m_ControlPJ.PLAYER.Jump.performed += ctx => jump();
        m_ControlPJ.PLAYER.Jump.canceled += ctx => detenerJump();

        m_ControlPJ.PLAYER.Run.performed += startRun;
        m_ControlPJ.PLAYER.Run.canceled += cancelarRun;

        m_ControlPJ.PLAYER.Dash.started += ctx => dash();

        m_ControlPJ.PLAYER.Kick.started += ctx => kick();

        m_ControlPJ.PLAYER.Shoot.performed += ctx => shootMethod();
        m_ControlPJ.PLAYER.Shoot.canceled += ctx => shootCancel();
    }

    public void setParamMovement(so_CONFIG_PJ m_so_CONFIG_PJ)
    {
        velocidadCaminar = m_so_CONFIG_PJ.velocidadCaminar;
        velocidadRun = m_so_CONFIG_PJ.factorRun;
        velocidadLimiteCaida = m_so_CONFIG_PJ.velocidadLimiteCaida;
        potenciaSalto = m_so_CONFIG_PJ.potenciaSalto;

        factorCaidaWall = m_so_CONFIG_PJ.factorCaidaWall;
        potenciaRepulsionWALL_X = m_so_CONFIG_PJ.potenciaRepulsionWALL_X;
        potenciaRepulsionWALL_Y = m_so_CONFIG_PJ.potenciaRepulsionWALL_Y;
        tiempoInactivoRepulsion = m_so_CONFIG_PJ.tiempoInactivoRepulsionWALL;
        factorMovimientoX_Repulsion = m_so_CONFIG_PJ.factorMov_X_RepulsionWALL;

        m_dashPJ.setValores(m_so_CONFIG_PJ.potenciaDash, m_so_CONFIG_PJ.cadenciaDash, m_so_CONFIG_PJ.duracionDash);
    }
    private void shootMethod()
    {
        if((m_estados == GLOBAL_TYPES.ESTADOS_PJ.normalMovement || m_estados == GLOBAL_TYPES.ESTADOS_PJ.jumpingWalk) && !m_checkPared.checkIsPared())
        {
            m_shootPJ.Shoot();
        }
    }
    private void shootCancel()
    {
        m_shootPJ.shootRelease();
    }
    public bool canShoot()
    {
        return (m_estados == GLOBAL_TYPES.ESTADOS_PJ.normalMovement || m_estados == GLOBAL_TYPES.ESTADOS_PJ.jumpingWalk) && !m_checkPared.checkIsPared();
    }
    private void kick()
    {
        if (current_cadenciaKick < 0 && m_estados == GLOBAL_TYPES.ESTADOS_PJ.normalMovement || m_estados == GLOBAL_TYPES.ESTADOS_PJ.jumpingWalk)
        {
            current_cadenciaKick = cadenciaKick;
            m_animator.SetTrigger("Kick");
            m_estados = GLOBAL_TYPES.ESTADOS_PJ.kick;
        }
    }
    private bool accesoDash = true;
    private void dash()
    {
        if (accesoDash && (m_estados == GLOBAL_TYPES.ESTADOS_PJ.normalMovement || m_estados == GLOBAL_TYPES.ESTADOS_PJ.jumpingWalk))
        {
            if (m_dashPJ.startDash(m_changeMirada.getMirada()))
            {
                accesoDash = false;
                m_estados = GLOBAL_TYPES.ESTADOS_PJ.dash;
                m_animator.SetTrigger("start_Dash");
            }
        }
    }

    private void jump()
    {
        if (m_estados == GLOBAL_TYPES.ESTADOS_PJ.normalMovement)
        {

            if (m_isGrounded)
                m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, potenciaSalto);
            if (onWalk)
            {
                onWalk = false;
                m_estados = GLOBAL_TYPES.ESTADOS_PJ.jumpingWalk;
                m_animator.Play("anim_pj_jump");
                //referencesMASTER.instancia.sp_brazo.enabled = true;
                //referencesMASTER.instancia.sp_Arma.enabled = true;

                if (m_changeMirada.getMirada() == GLOBAL_TYPES.ladoMirada.izquierda)
                {
                    m_rigidbody.AddForce(new Vector2(potenciaRepulsionWALL_X, potenciaRepulsionWALL_Y),ForceMode2D.Impulse);
                }
                else
                {
                    m_rigidbody.AddForce(new Vector2(-potenciaRepulsionWALL_X, potenciaRepulsionWALL_Y), ForceMode2D.Impulse);
                }
                Invoke("returnNormalMovement", tiempoInactivoRepulsion);
            }
        }
    }

    private void detenerJump()
    {
        m_rigidbody.velocity = new Vector3(m_rigidbody.velocity.x, m_rigidbody.velocity.y * 0.5f);
    }
    
    private void startRun(InputAction.CallbackContext ctx)
    {
        if (!isRun)
            m_animator.SetBool("run", true);
        isRun = true;
    }
    private void cancelarRun(InputAction.CallbackContext ctx)
    {
        isRun = false;
        m_animator.SetBool("run", false);
    }
    private float m_currentValor_X;
    private void getInput_Axis_LEFT(float currentValor_X)
    {
        //if(m_estados == GLOBAL_TYPES.ESTADOS_PJ.normalMovement || m_estados == GLOBAL_TYPES.ESTADOS_PJ.jumpingWalk || m_estados == GLOBAL_TYPES.ESTADOS_PJ.pain)
        //{
            m_currentValor_X = currentValor_X;
            float currentValorX_abs = Mathf.Abs(currentValor_X);
            if (currentValorX_abs > limiteInput_movX)
                valorInput_Horizontal = currentValor_X;
            else valorInput_Horizontal = 0;

            m_animator.SetFloat("velocidad_X",currentValorX_abs);
       // }

    }
    private void setZerotInput_Axis_LEFT(InputAction.CallbackContext ctx)
    {
        valorInput_Horizontal = 0;
        m_animator.SetFloat("velocidad_X", 0);
    }
    private void Awake()
    {
        setControl();
    }
    void Start()
    {
        m_estados = GLOBAL_TYPES.ESTADOS_PJ.normalMovement;
    }
    private void landed_function()
    {

    }
    // Update is called once per frame
    void Update()
    {
        grounded_landed();

        if (m_rigidbody.velocity.y < velocidadLimiteCaida) m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, velocidadLimiteCaida);

        if (m_estados == GLOBAL_TYPES.ESTADOS_PJ.normalMovement)
        {
            isPared();
            m_changeMirada.miradaPj(m_currentValor_X);
        }
        if (m_estados != GLOBAL_TYPES.ESTADOS_PJ.kick && current_cadenciaKick > -1)
        {
            current_cadenciaKick -= Time.deltaTime;
        }
    }

    private void grounded_landed()
    {
        m_isGrounded = m_grounded.isGrounded();
        if (m_isGrounded) accesoDash = true;
        else landed = false;
        if (!landed && m_isGrounded)
        {
            landed_function();
        }
        m_animator.SetBool("onGround", m_isGrounded);
    }

    private void isPared()
    {
        if (!m_isGrounded && m_checkPared.checkIsPared() && m_rigidbody.velocity.y < 0)
        {
            if (m_changeMirada.getMirada() == GLOBAL_TYPES.ladoMirada.derecha && valorInput_Horizontal > 0.1f)
            {
                onWalk = true;
            }
            else if (m_changeMirada.getMirada() == GLOBAL_TYPES.ladoMirada.izquierda && valorInput_Horizontal < -0.1f)
            {
                onWalk = true;
            }else onWalk = false;
        }
        else onWalk = false;

        if (m_estados != GLOBAL_TYPES.ESTADOS_PJ.jumpingWalk)
        {
            if (onWalk)
            {
                if(!m_animator.GetBool("checkWalk") || !m_animator.GetCurrentAnimatorStateInfo(0).IsName("anim_pj_onWalk"))
                    m_animator.SetTrigger("onWalk");
                m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, m_rigidbody.velocity.y*factorCaidaWall);
            }else m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, m_rigidbody.velocity.y);
        }
        m_animator.SetBool("checkWalk", onWalk);

    }
    private void FixedUpdate()
    {
        switch (m_estados)
        {
            case GLOBAL_TYPES.ESTADOS_PJ.normalMovement:
                {
                    if (isRun)
                        m_rigidbody.velocity = new Vector2(valorInput_Horizontal * velocidadCaminar * velocidadRun, m_rigidbody.velocity.y);
                    else
                        m_rigidbody.velocity = new Vector2(valorInput_Horizontal * velocidadCaminar, m_rigidbody.velocity.y);
                    break;
                }
            case GLOBAL_TYPES.ESTADOS_PJ.jumpingWalk:
                {
                    m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x + (valorInput_Horizontal * velocidadCaminar * factorMovimientoX_Repulsion), m_rigidbody.velocity.y);
                    break;
                }
            case GLOBAL_TYPES.ESTADOS_PJ.dash:
                {
                    m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x , 0);
                    break;
                }
            case GLOBAL_TYPES.ESTADOS_PJ.kick:
                {
                    m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x * 0.2f, m_rigidbody.velocity.y*0.2f);
                    break;
                }
            case GLOBAL_TYPES.ESTADOS_PJ.pain:
                {
                    m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x * 0.2f, m_rigidbody.velocity.y * 0.2f);
                    break;
                }
            case GLOBAL_TYPES.ESTADOS_PJ.talk:
                {
                    m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x * 0.2f, m_rigidbody.velocity.y * 0.2f);
                    break;
                }
        }
    }
    private void OnDisable() { desactivarControles(); }
    private void desactivarControles()
    {
        if (m_ControlPJ != null)
        {
            m_ControlPJ.PLAYER.Disable();
            m_ControlPJ = null;
        }
    }
    public void returnNormalMovement()//FIX
    {
        switch (m_estados)
        {
            case GLOBAL_TYPES.ESTADOS_PJ.dash:
                {
                    m_animator.SetTrigger("finish_Dash");
                    break;
                }
            case GLOBAL_TYPES.ESTADOS_PJ.talk:
                {
                    m_animator.SetTrigger("FinishTalk");
                    break;
                }
        }
        m_estados = GLOBAL_TYPES.ESTADOS_PJ.normalMovement;
    }
    public void setEstadoPj(GLOBAL_TYPES.ESTADOS_PJ _estado)
    {
        m_estados = _estado;
    }

    public void recibirDanio(dataDanio m_dataDanio, bool vvv)
    {
        /*
        Vector3 dir = Vector3.up;
        if (m_dataDanio.posicionDanio.x != 0)
        {
            Vector3 posicionNueva = new Vector3(m_dataDanio.posicionDanio.x, m_dataDanio.posicionDanio.y,0);
            if(Mathf.Abs(posicionNueva.x) > 0.1f)
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Instantiate(sphere, posicionNueva, Quaternion.identity);
                dir = (transform.position - posicionNueva).normalized;
                print("instanciado");
            }

        }
        */
        m_estados = GLOBAL_TYPES.ESTADOS_PJ.pain;
        m_animator.SetTrigger("Pain");
        m_rigidbody.velocity = Vector2.zero;
        m_rigidbody.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
    }
    public void morir()
    {
        m_estados = GLOBAL_TYPES.ESTADOS_PJ.die;
        m_animator.SetTrigger("Die");
        m_rigidbody.velocity = Vector2.zero;
        m_rigidbody.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        respawnear();
    }

    public bool comenzarTalk(float x_pos_NPC)
    {
        if(m_estados==GLOBAL_TYPES.ESTADOS_PJ.normalMovement && m_isGrounded)
        {
            m_estados = GLOBAL_TYPES.ESTADOS_PJ.talk;
            m_animator.SetTrigger("StartTalk");
            if(transform.position.x < x_pos_NPC)
            {
                //mire a la derecha
                m_changeMirada.miradaPj(1);
                referencesMASTER.instancia.offsetCamera_X_Talk.m_Offset.x = Mathf.Abs(referencesMASTER.instancia.offsetCamera_X_Talk.m_Offset.x);
            }
            else
            {
                //mire a la izquierda
                m_changeMirada.miradaPj(-1);
                referencesMASTER.instancia.offsetCamera_X_Talk.m_Offset.x = -Mathf.Abs(referencesMASTER.instancia.offsetCamera_X_Talk.m_Offset.x);
            }
            //if(m_changeMirada.getMirada()== GLOBAL_TYPES.ladoMirada.izquierda)
            return true;
        }
        return false;
    }
    public void respawnear()
    {
        m_respawnPJ.respawn();
    }

    public void retrocesoDisparo(float retroceso)
    {
        if (m_changeMirada.getMirada() == GLOBAL_TYPES.ladoMirada.izquierda)
        {
            m_rigidbody.AddForce(Vector2.right * retroceso * 100f, ForceMode2D.Force);
            //m_rigidbody.AddForce(new Vector2(retroceso,0), ForceMode2D.Impulse);
        }
        else
        {
            m_rigidbody.AddForce(Vector2.left * retroceso * 100f, ForceMode2D.Force);
            //m_rigidbody.AddForce(new Vector2(-retroceso, 0), ForceMode2D.Impulse);
        }
    }
}
