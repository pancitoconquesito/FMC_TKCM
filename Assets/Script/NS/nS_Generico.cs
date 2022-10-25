using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NS_Generico : MonoBehaviour, IDamageable
{
    [Header("-- NS --")]
    [SerializeField] private int vidaTotal;
    [SerializeField] private GameObject container;

    private ObjectPooling m_ObjectPooling;
    [SerializeField] private Rigidbody2D m_rigidbody;
    [SerializeField]private float m_cadenciaRecibirDanio=0.15f;
    [SerializeField] private bool recibeEmpuje = true;
    [SerializeField] private float factorEmpuje = 1f;
    [SerializeField] private Animator m_Animator;
    [SerializeField] private Collider2D m_Collider2D_realizarDanio;
    [SerializeField] private Collider2D m_Collider2D_recibirDanio;
    private float current_cadenciaRecibirDanio=0;
    protected bool vivo;

    public NS_Generico()
    {
        vivo = true;
       //m_ObjectPooling = _ObjectPooling;
    }
    public bool RecibirDanio_I(dataDanio m_dataDanio)
    {
        bool retorno = false;
        if(vivo)
            retorno = recibirDanio(m_dataDanio);
        return retorno;
    }
    private Vector2 dir;
    private float empuje;
    private bool empujado;
    public float getEmpuje()=> empuje;
    public Vector2 getDir() => dir;
    public virtual bool recibirDanio(dataDanio m_dataDanio)
    {
        //print("ns generico");
        if (current_cadenciaRecibirDanio > 0) return false;
        if (m_dataDanio.m_A_QuienDania != GLOBAL_TYPES.AFECTA_A_.daniA_ns && m_dataDanio.m_A_QuienDania != GLOBAL_TYPES.AFECTA_A_.daniaA_ALLL) return false;
        bool retorno = false;
        //print("Yo " + gameObject.name + " recibi danio desde Generico");
        vidaTotal -= m_dataDanio.danio;
        current_cadenciaRecibirDanio = m_cadenciaRecibirDanio;
        if (vidaTotal < 0)
        {
            morir(m_dataDanio);
            retorno = true;
        }


        /*GameObject cubeObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubeObject.transform.localPosition = m_dataDanio.posicionDanio;
        cubeObject.transform.localScale = new Vector3(.1f, .1f, .1f);
        */
        float posX_PJ = referencesMASTER.instancia.m_transformPJ.position.x;
        float posX_NS = transform.position.x;
        float posX_BALA = m_dataDanio.posicionDanio.x;
        float posY_BALA = m_dataDanio.posicionDanio.y;
        if (posX_PJ< posX_NS && posX_NS < posX_BALA)//hacia la derecha
        {
            posX_BALA = posX_PJ;
            //print($"A  posKick_{posX_BALA}____{m_dataDanio.posicionDanio.x}");
        }
        if (posX_BALA<posX_NS && posX_NS<posX_PJ)//hacia la izquierda
        {
            posX_BALA = posX_PJ;
            //print("B");
        }

        //dir = new Vector2(transform.position.x-m_dataDanio.posicionDanio.x ,transform.position.y -m_dataDanio.posicionDanio.y);
        dir = new Vector2(posX_NS - posX_BALA, transform.position.y - posY_BALA);
        dir = dir.normalized;
        

        Debug.DrawRay(transform.position, dir, Color.yellow);

        empuje = m_dataDanio.getImpactoEmpuje();
        //print("Empuje : "+ empuje);
        if(recibeEmpuje)
            m_rigidbody.AddForce(dir * empuje * factorEmpuje, ForceMode2D.Impulse);
        return retorno;
    }
    public virtual void morir(dataDanio m_dataDanio)
    {
        vivo = false;
        //print("acabo de morir!");
        //Destroy(container);
        m_Animator.SetTrigger("died");
        m_Collider2D_realizarDanio.enabled = false;
        m_Collider2D_recibirDanio.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (current_cadenciaRecibirDanio > -1) current_cadenciaRecibirDanio -= Time.deltaTime;
        empujado = recibeEmpuje && current_cadenciaRecibirDanio > m_cadenciaRecibirDanio / 2f;
    }
    public bool isEmpujado()
    {
        return empujado;
    }
    public bool getIsVivo() => vivo;
}
