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
    [SerializeField] private vida_PJ m_vida_PJ;

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
    private so_CONFIG_PJ RESP_so_Config_PJ;

    [Header("- Kick -")]
    [SerializeField] private float cadenciaKick;
    private float current_cadenciaKick=-1;

    [Header("- Shoot -")]
    [SerializeField] private shootPJ m_shootPJ;

    [Header("- Special -")]
    private ISpecial m_ISpecial;
    [SerializeField] private GLOBAL_TYPES.ESTADO_ALTERADO m_estadoAlterado=GLOBAL_TYPES.ESTADO_ALTERADO.none;
    //[SerializeField] private int aaaa;

    [Header("-- Particles --")]
    [SerializeField] private ObjectPooling m_OP_polvo;
    [SerializeField] private float tiempoPolvo_walk;
    [SerializeField] private float tiempoPolvo_run;
    private float currentTiempoPolvo;
    //--
    [SerializeField] private ObjectPooling m_OP_polvoPared;
    [SerializeField] private float tiempoPolvoPared;
    private float currentTiempoPolvoPared=0f;
    [SerializeField] private emitirParticulas m_PO_polvoSaltoSuelo;
    [SerializeField] private emitirParticulas m_PO_polvoSaltoPared;
    [SerializeField] private ObjectPooling m_PO_kick;


    [Header("-- Audio --")]
    [SerializeField] private SonidosPj m_SonidosPj;

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

        //m_ControlPJ.PLAYER.Horizontal.performed += ctx => getInput_Axis_LEFT(ctx.ReadValue<Vector2>().x);
        m_ControlPJ.PLAYER.Horizontal.canceled += setZerotInput_Axis_LEFT;
        m_ControlPJ.PLAYER.Jump.performed += ctx => jump();
        m_ControlPJ.PLAYER.Jump.canceled += ctx => detenerJump();
        m_ControlPJ.PLAYER.Run.performed += startRun;
        m_ControlPJ.PLAYER.Run.canceled += cancelarRun;
        m_ControlPJ.PLAYER.Dash.started += ctx => dash();
        m_ControlPJ.PLAYER.Kick.started += ctx => kick();
        m_ControlPJ.PLAYER.Shoot.performed += ctx => shootMethod();
        m_ControlPJ.PLAYER.Shoot.canceled += ctx => shootCancel();
        m_ControlPJ.PLAYER.Special.started += ctx => special();
        m_ControlPJ.PLAYER.Inventary.started += ctx => c_inventary();
    }
    private void c_inventary()
    {
        if (!m_vida_PJ.isVivo() || !GLOBAL_TYPES.canInventary(m_estados)) return;
        if (m_estados!= GLOBAL_TYPES.ESTADOS_PJ.inventary)
        {
            m_SonidosPj.playStartInventario();

            valorInput_Horizontal = 0;
            m_currentValor_X = 0;
            m_animator.SetFloat("velocidad_X", 0);

            m_estados = GLOBAL_TYPES.ESTADOS_PJ.inventary;
            m_animator.ResetTrigger("Inventario");
            m_animator.SetTrigger("Inventario");
            //print("ENTRAR Inventario");
            referencesMASTER.instancia.m_Gestor_UI_Inventario.turnActive(true);
        }
        else
        {
            m_SonidosPj.playExitInventario();


            //print("SALIR Inventario");
            m_animator.ResetTrigger("resetInventario");
            m_animator.SetTrigger("resetInventario");
            this.returnNormalMovement();
            referencesMASTER.instancia.m_Gestor_UI_Inventario.turnActive(false);
        }
    }
    public void setPoder(ISpecial m_Poder)=> m_ISpecial = m_Poder;
    private void special()
    {
        if (!m_vida_PJ.isVivo() || !GLOBAL_TYPES.canSpecial(m_estados)) return;
        if (m_ISpecial == null)
        {
            print("poder nulo");
            return;
        }
        m_ISpecial.activatePower();
    }
    
    public void setParamMovement(so_CONFIG_PJ m_so_CONFIG_PJ, bool saveConfig)
    {
        if(saveConfig)
            RESP_so_Config_PJ = m_so_CONFIG_PJ;
        velocidadCaminar = m_so_CONFIG_PJ.velocidadCaminar;
        velocidadRun = m_so_CONFIG_PJ.factorRun;
        potenciaSalto = m_so_CONFIG_PJ.potenciaSalto;
        velocidadLimiteCaida = m_so_CONFIG_PJ.velocidadLimiteCaida;

        factorCaidaWall = m_so_CONFIG_PJ.factorCaidaWall;
        potenciaRepulsionWALL_X = m_so_CONFIG_PJ.potenciaRepulsionWALL_X;
        potenciaRepulsionWALL_Y = m_so_CONFIG_PJ.potenciaRepulsionWALL_Y;
        tiempoInactivoRepulsion = m_so_CONFIG_PJ.tiempoInactivoRepulsionWALL;
        factorMovimientoX_Repulsion = m_so_CONFIG_PJ.factorMov_X_RepulsionWALL;

        m_dashPJ.setValores(m_so_CONFIG_PJ.potenciaDash, m_so_CONFIG_PJ.cadenciaDash, m_so_CONFIG_PJ.duracionDash);
    }
    private void shootMethod()
    {
        if (!m_vida_PJ.isVivo() || !GLOBAL_TYPES.canShoot(m_estados)) return;
        if (GLOBAL_TYPES.canShoot(m_estados) && !m_checkPared.checkIsPared()) //if ((m_estados == GLOBAL_TYPES.ESTADOS_PJ.normalMovement || m_estados == GLOBAL_TYPES.ESTADOS_PJ.jumpingWalk) && !m_checkPared.checkIsPared())
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
        if (!m_vida_PJ.isVivo() || !GLOBAL_TYPES.canKick(m_estados) || onWalk) return;
        if (current_cadenciaKick < 0)//m_estados == GLOBAL_TYPES.ESTADOS_PJ.normalMovement || m_estados == GLOBAL_TYPES.ESTADOS_PJ.jumpingWalk)
        {
            m_SonidosPj.playPatada();

            m_PO_kick.emitirObj(0.5f, false);
            current_cadenciaKick = cadenciaKick;
            m_animator.SetTrigger("Kick");
            m_estados = GLOBAL_TYPES.ESTADOS_PJ.kick;
        }
    }
    private bool accesoDash = true;
    public bool pjCanRechargeDash()
    {
        return accesoDash && GLOBAL_TYPES.canDash(m_estados) && m_vida_PJ.isVivo();
    }
    private void dash()
    {
        if (!m_vida_PJ.isVivo() || !GLOBAL_TYPES.canDash(m_estados) || (m_grounded && onWalk)) return;//|| (m_checkPared && !m_grounded)//FIX
        if (m_estadoAlterado == GLOBAL_TYPES.ESTADO_ALTERADO.plasma) return;
        if (accesoDash )//&& (m_estados == GLOBAL_TYPES.ESTADOS_PJ.normalMovement || m_estados == GLOBAL_TYPES.ESTADOS_PJ.jumpingWalk))
        {
            if (m_dashPJ.startDash(m_changeMirada.getMirada()))
            {
                m_animator.ResetTrigger("finish_Dash");

                m_SonidosPj.playDash();

                accesoDash = false;
                m_estados = GLOBAL_TYPES.ESTADOS_PJ.dash;
                m_animator.SetTrigger("start_Dash");
            }
        }
    }
    private void jump()
    {
        if (!m_vida_PJ.isVivo() || !GLOBAL_TYPES.canMov_X(m_estados)) return;
        //if (m_estados == GLOBAL_TYPES.ESTADOS_PJ.normalMovement)
        //{
        if (m_isGrounded)
        {
            m_SonidosPj.playSalto();

            m_PO_polvoSaltoSuelo.emitir();
            fisrtCencelJump = false;
            m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, potenciaSalto);
        }
        if (onWalk)//&& m_estados!= GLOBAL_TYPES.ESTADOS_PJ.dash )
        {
            m_SonidosPj.playSalto();


            m_PO_polvoSaltoPared.emitir();

            fisrtCencelJump = false;
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
            if(m_estados != GLOBAL_TYPES.ESTADOS_PJ.dash)//FIX
                Invoke("returnNormalMovement", tiempoInactivoRepulsion);
        }
        //}
    }
    private bool fisrtCencelJump = false;
    private void detenerJump()
    {
        if (!fisrtCencelJump) {
            fisrtCencelJump = true;
            m_rigidbody.velocity = new Vector3(m_rigidbody.velocity.x, m_rigidbody.velocity.y * 0.5f);
        }
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
        if (!m_vida_PJ.isVivo() || m_estados == GLOBAL_TYPES.ESTADOS_PJ.inventary) return;
        /**/

        //m_ControlPJ.PLAYER.Horizontal.performed += ctx => getInput_Axis_LEFT(ctx.ReadValue<Vector2>().x);

        //if(m_estados == GLOBAL_TYPES.ESTADOS_PJ.normalMovement || m_estados == GLOBAL_TYPES.ESTADOS_PJ.jumpingWalk || m_estados == GLOBAL_TYPES.ESTADOS_PJ.pain)
        //{
         //getInput_Axis_LEFT(m_ControlPJ.PLAYER.Horizontal.ReadValue<Vector2>().x);

            m_currentValor_X = currentValor_X;
            //print("m_currentValor_X : "+ m_currentValor_X);
            float currentValorX_abs = Mathf.Abs(currentValor_X);
            if (currentValorX_abs > limiteInput_movX)
                valorInput_Horizontal = currentValor_X;
            else valorInput_Horizontal = 0;
            m_animator.SetFloat("velocidad_X", currentValorX_abs);//FIX
        // }
       /*if (m_estados == GLOBAL_TYPES.ESTADOS_PJ.inventary )//|| m_estados == GLOBAL_TYPES.ESTADOS_PJ.dash || m_estados == GLOBAL_TYPES.ESTADOS_PJ.kick)//|| !GLOBAL_TYPES.canMov_X(m_estados))
        {
            valorInput_Horizontal = 0;
            m_currentValor_X = 0;
            //if(m_estados== GLOBAL_TYPES.ESTADOS_PJ.jumpingWalk) m_animator.SetFloat("velocidad_X", currentValor_X);
            //else 
            m_animator.SetFloat("velocidad_X", 0);
            //return;
        }*/
    }
    private void setZerotInput_Axis_LEFT(InputAction.CallbackContext ctx)
    {
        //if (m_currentValor_X != 0) return;
        valorInput_Horizontal = 0;
        m_animator.SetFloat("velocidad_X", 0);
    }
    private void Awake()
    {
        Invoke("setControl",1f);
    }
    void Start()
    {
        m_estados = GLOBAL_TYPES.ESTADOS_PJ.normalMovement;//GONZO
        m_animator.SetBool("Vivo", true);

    }
    private void landed_function()
    {
        m_SonidosPj.playLanded();

    }
    // Update is called once per frame
    void Update()
    {
        if (m_vida_PJ.isVivo())
        {
            if (m_ControlPJ != null)
            {
                getInput_Axis_LEFT(m_ControlPJ.PLAYER.Horizontal.ReadValue<Vector2>().x);
                
                //print(InputSystem.GetDevice<Gamepad>().IsActuated());

            }

            m_animator.SetFloat("Velocidad_Y",m_rigidbody.velocity.y);

            grounded_landed();

            if (m_rigidbody.velocity.y < velocidadLimiteCaida) m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, velocidadLimiteCaida);

            if (m_estados == GLOBAL_TYPES.ESTADOS_PJ.normalMovement || m_estados == GLOBAL_TYPES.ESTADOS_PJ.jumpingWalk)
            {
                isPared();
                m_changeMirada.miradaPj(m_currentValor_X);
            }
            if (m_estados != GLOBAL_TYPES.ESTADOS_PJ.kick && current_cadenciaKick > -1)
            {
                current_cadenciaKick -= Time.deltaTime;
            }
            emitirParticulas();
        }
    }
    private void emitirParticulas()
    {
        if (m_estados == GLOBAL_TYPES.ESTADOS_PJ.talk) return;
        emitirPolvoSuelo();
        emitirPolvoPared();
    }
    private void emitirPolvoPared()
    {
        if (currentTiempoPolvoPared > -1f)
            currentTiempoPolvoPared -= Time.deltaTime;
        if (onWalk && currentTiempoPolvoPared < 0)
        {
            currentTiempoPolvoPared = tiempoPolvoPared;
            m_OP_polvoPared.emitirObj(1f, false);
        }
    }
    private void emitirPolvoSuelo()
    {
        if (currentTiempoPolvo > -1)
            currentTiempoPolvo -= Time.deltaTime;
        if (currentTiempoPolvo < 0 && m_isGrounded && m_animator.GetFloat("velocidad_X") !=0)
        {
            float n_random = UnityEngine.Random.Range(0.2f, 0.8f);// Random.Range(1f,3f);// .(0.1f, 0.5f);
            if (isRun)
            {
                currentTiempoPolvo = tiempoPolvo_run;
            }
            else
            {
                currentTiempoPolvo = tiempoPolvo_walk;
            }
            m_OP_polvo.emitirObj(1f + n_random, false);

        }
    }
    private void grounded_landed()
    {
        m_isGrounded = m_grounded.isGrounded();
        if (m_isGrounded) accesoDash = true;
        else landed = false;
        if (!landed && m_isGrounded)
        {
            landed = true;

            landed_function();
        }
        m_animator.SetBool("onGround", m_isGrounded);
    }

    private void isPared()
    {
        //GONZO
        if(m_estadoAlterado == GLOBAL_TYPES.ESTADO_ALTERADO.plasma)
        {
            onWalk = false;
            m_animator.SetBool("checkWalk", false);
            return;
        }
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

        /*if (m_estados != GLOBAL_TYPES.ESTADOS_PJ.jumpingWalk)
        {
            if (onWalk)
            {
                if(!m_animator.GetBool("checkWalk") || !m_animator.GetCurrentAnimatorStateInfo(0).IsName("anim_pj_onWalk"))
                    m_animator.SetTrigger("onWalk");
                m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, m_rigidbody.velocity.y*factorCaidaWall);
            }else m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, m_rigidbody.velocity.y);
        }*/
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
                    m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x , 1.4f);
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
            case GLOBAL_TYPES.ESTADOS_PJ.die:
                {
                    m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x * 0.2f, m_rigidbody.velocity.y * 0.2f);
                    break;
                }
            case GLOBAL_TYPES.ESTADOS_PJ.inventary:
                {
                    m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x * 0.1f, m_rigidbody.velocity.y);
                    break;
                }
        }



        if (m_estados != GLOBAL_TYPES.ESTADOS_PJ.jumpingWalk)
        {
            if (onWalk)
            {
                if (!m_animator.GetBool("checkWalk") || !m_animator.GetCurrentAnimatorStateInfo(0).IsName("anim_pj_onWalk"))
                    m_animator.SetTrigger("onWalk");
                m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, m_rigidbody.velocity.y * factorCaidaWall);
            }
            else m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x, m_rigidbody.velocity.y);
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
        if (m_estados == GLOBAL_TYPES.ESTADOS_PJ.die) return;
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
    private Animator m_at_ui_dolor;
    public void recibirDanio(dataDanio m_dataDanio, bool vvv)
    {
        m_SonidosPj.playRecibirDanio();


        referencesMASTER.instancia.m_Gestor_UI_Inventario.closeInventary();
        m_at_ui_dolor = referencesMASTER.instancia.m_at_ui_dolor;
        m_at_ui_dolor.SetTrigger("Start");


        m_estados = GLOBAL_TYPES.ESTADOS_PJ.pain;
        m_animator.SetTrigger("Pain");
        m_rigidbody.velocity = Vector2.zero;
        m_rigidbody.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        
        StartCoroutine(detenerTiempo());
    }
    IEnumerator detenerTiempo()
    {
        Time.timeScale = 0.01f;
        yield return new WaitForSecondsRealtime(0.2f);
        Time.timeScale = 1f;
    }
    private void cancelarInventario()
    {
        referencesMASTER.instancia.m_Gestor_UI_Inventario.closeInventary();
    }

    public void morir()
    {
        m_animator.SetBool("Vivo",false);


        m_SonidosPj.playMorir();

        setEstadoAlterado_param(GLOBAL_TYPES.ESTADO_ALTERADO.none,null);
        m_estados = GLOBAL_TYPES.ESTADOS_PJ.die;
        m_animator.SetTrigger("Die");
        m_rigidbody.velocity = Vector2.zero;
        m_rigidbody.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        //desactivarControles();
        m_rigidbody.constraints= RigidbodyConstraints2D.FreezeAll;
        respawnear();

        Destroy(referencesMASTER.instancia.m_GO_ConfinerCamera.gameObject);
        

        disabledALL();
        referencesMASTER.instancia.m_GO_UI_died.SetActive(true);

        //quitar poderes
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
    public void setEstadoAlterado_param(GLOBAL_TYPES.ESTADO_ALTERADO estadoAlterado_, so_CONFIG_PJ newParam)
    {
        //print("acaaaa");
        //if (newParam == null) estadoAlterado_ = GLOBAL_TYPES.ESTADO_ALTERADO.none;
        m_estadoAlterado = estadoAlterado_;
        switch (m_estadoAlterado) {
            case GLOBAL_TYPES.ESTADO_ALTERADO.none:
                {
                    if(m_ControlPJ == null)
                        setControl();
                    setParamMovement(RESP_so_Config_PJ, false);
                    break;
                }
            case GLOBAL_TYPES.ESTADO_ALTERADO.plasma:{
                    setParamMovement(newParam, false);
                    break;
                }
            case GLOBAL_TYPES.ESTADO_ALTERADO.explosionSonica:
                {
                    desactivarControles();
                    //setParamMovement(newParam, false);
                    m_rigidbody.velocity = Vector2.zero;
                    velocidadLimiteCaida = 0f;
                    break;
                }
        }
    }
    internal void disabledALL()
    {
        m_estados = GLOBAL_TYPES.ESTADOS_PJ.cinematic;
        m_estadoAlterado = GLOBAL_TYPES.ESTADO_ALTERADO.none;
        desactivarControles();
    }
    public GLOBAL_TYPES.ESTADOS_PJ getEstado() => m_estados;

    internal void getNekoEsfera()
    {
        // inhabilitar pj mov
        disabledALL();
        // no danio pj
        referencesMASTER.instancia.m_GO_recibirDanio.SetActive(false);
        // set anim festejo => camara + cerca
        m_animator.SetTrigger("Win_A");
        m_rigidbody.velocity = Vector2.zero;

    }
    public void startObjectGeneric(float delay)
    {
        m_rigidbody.velocity = Vector2.zero;
        m_rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
        m_estados = GLOBAL_TYPES.ESTADOS_PJ.talk;
        m_animator.SetTrigger("StartGetOBject");
        disabledALL();
        Invoke("salirGetObject", delay);
    }
    private void salirGetObject()
    {
        m_rigidbody.constraints = RigidbodyConstraints2D.None;
        m_rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        m_estados = GLOBAL_TYPES.ESTADOS_PJ.normalMovement;
        m_animator.SetTrigger("ExitGetOBject");
        setControl();
    }
}
