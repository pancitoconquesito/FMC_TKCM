using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterInteraccion : MonoBehaviour
{
    public enum ESTADO_ACTIVO
    {
        exit, enter, active
    }
    [SerializeField] private ESTADO_ACTIVO m_ESTADO_ACTIVO;
    private movementPJ m_movementPJ;
    private NewControls m_Control_BIOMA;
    private Collider2D m_Collider2D;
    private IInteraccion m_IInteraccion;
    // Start is called before the first frame update
    private void Awake()
    {
        m_Collider2D = GetComponent<BoxCollider2D>();
        m_IInteraccion = GetComponent<IInteraccion>();
    }
    void Start()
    {
        m_ESTADO_ACTIVO = ESTADO_ACTIVO.exit;
        m_movementPJ = referencesMASTER.instancia.m_movementPJ;
    }
    /*private void OnEnable()
    {
        activarControles();
    }*/
    private void OnDisable()
    {
        desactivarControles();
    }
    private void OnDestroy()
    {
        desactivarControles();
    }
    private void activarControles()
    {
        m_Control_BIOMA = new NewControls();
        m_Control_BIOMA.INTERACCION.Enable();

        //m_Control_BIOMA.PLAYER.Horizontal.performed += ctx => getInput_Axis_LEFT(ctx.ReadValue<Vector2>().x);
        m_Control_BIOMA.INTERACCION.Aceptar.started += ctx => accederBioma();
        m_Control_BIOMA.INTERACCION.Cancelar.started += ctx => cancelarBioma();
    }
    private void desactivarControles()
    {
        if (m_Control_BIOMA != null)
        {
            m_Control_BIOMA.INTERACCION.Disable();
            m_Control_BIOMA = null;
        }
    }
    private void accederBioma()
    {
        if(m_ESTADO_ACTIVO == ESTADO_ACTIVO.enter && m_movementPJ.comenzarTalk(transform.position.x))
        {
            activarBioma();
        }
    }
    private void activarBioma()
    {
        print("- Activar BIOMA -");
        m_ESTADO_ACTIVO = ESTADO_ACTIVO.active;
        m_IInteraccion.comenzarInteraccion();
    }
    private void cancelarBioma()
    {
        if (m_ESTADO_ACTIVO == ESTADO_ACTIVO.active)
        {
            m_Collider2D.enabled = false;
            desactivarBioma();
        }
    }

    private void desactivarBioma()
    {
        print("- Desactivar BIOMA -");
        m_IInteraccion.cancelarInteraccion();
        m_ESTADO_ACTIVO = ESTADO_ACTIVO.exit;
        m_Collider2D.enabled = true;
        m_movementPJ.returnNormalMovement();

    }

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && m_ESTADO_ACTIVO==ESTADO_ACTIVO.exit)
        {
            m_ESTADO_ACTIVO = ESTADO_ACTIVO.enter;
            activarControles();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_ESTADO_ACTIVO = ESTADO_ACTIVO.exit;
            desactivarControles();
        }    
    }
}
