using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(changeMirada))]
public class NS_mov_IZDER : MonoBehaviour
{
    [SerializeField] private GLOBAL_TYPES.ladoMirada direccionCaminata;
    [SerializeField] private float velocidad;
    [Range(0,100f)][SerializeField] private float rangoPatrulla;
    [SerializeField] private Rigidbody2D m_rigidbody;
    [SerializeField] private float factorRetrocesoAlRecibirDanio;
    [SerializeField] private NS_Generico m_NS_Generico;
    private changeMirada m_changeMirada;
    void Start()
    {
        m_changeMirada = GetComponent<changeMirada>();

        direccionCaminata = GLOBAL_TYPES.ladoMirada.izquierda;
        vec_IZ= new Vector3(transform.position.x - rangoPatrulla, transform.position.y, transform.position.z);
        vec_DER= new Vector3(transform.position.x + rangoPatrulla, transform.position.y, transform.position.z);
    }

    private Vector3 vec_IZ, vec_DER;
    void Update()
    {
        if (m_NS_Generico.isEmpujado()) return;
        setLado();
        //m_NS_Generico ==null || (m_NS_Generico != null && !m_NS_Generico.isEmpujado()))
            moverse();
        /*else
        {
            print("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
           // m_rigidbody.AddForce(m_NS_Generico.getDir() * m_NS_Generico.getEmpuje() * 10f, ForceMode2D.Impulse);
        }*/

    }

    private void setLado()
    {
        if (direccionCaminata == GLOBAL_TYPES.ladoMirada.izquierda && transform.position.x < vec_IZ.x )
        {
            direccionCaminata = GLOBAL_TYPES.ladoMirada.derecha;
        }
        if (direccionCaminata == GLOBAL_TYPES.ladoMirada.derecha && transform.position.x > vec_DER.x)
        {
            direccionCaminata = GLOBAL_TYPES.ladoMirada.izquierda;
        }
    }
    private Vector3 lado;
    private void FixedUpdate()
    {
        if (m_NS_Generico.isEmpujado()) return;
        if (!reciboiendoDanio)
            m_rigidbody.velocity = velocidad * lado;
        else
            m_rigidbody.velocity = lado;
    }
    private void moverse()
    {
        if(vivo && !reciboiendoDanio)
        {
            if (direccionCaminata == GLOBAL_TYPES.ladoMirada.izquierda) lado = Vector3.left;
            else lado = Vector3.right;
            m_changeMirada.miradaPj(lado.x);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x - rangoPatrulla, transform.position.y, transform.position.z));
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + rangoPatrulla, transform.position.y, transform.position.z));
    }
    public void morir()
    {
        vivo = false;
        velocidad = 0;
    }
    private bool reciboiendoDanio=false;
    private bool vivo = true;
    
    public void recibirDanio(dataDanio m_dataDanio)
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAA");
        //si no esta recibiendo da�o ya
        reciboiendoDanio = true;
        Vector3 dirEmpuje = (transform.position - m_dataDanio.m_transformAtacante.position).normalized;

        lado = m_dataDanio.getImpactoEmpuje() * dirEmpuje * factorRetrocesoAlRecibirDanio;
        Invoke("quitarDanio",0.3f);
    }
    private void quitarDanio()
    {
        if(reciboiendoDanio && vivo) reciboiendoDanio = false;
    }
}
