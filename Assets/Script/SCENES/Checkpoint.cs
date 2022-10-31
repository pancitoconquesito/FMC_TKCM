using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int numero;
    private bool valor;
    public bool activo;
    public Vector3 miPosicion;
    private GestorCheckpoint m_GestorCheckpoint;
    public void setGestorCheckpoint(GestorCheckpoint value) => m_GestorCheckpoint = value;
    private void Awake()
    {
        valor = false;
        activo = true;
        miPosicion = new Vector3(transform.position.x, transform.position.y - (GetComponent<BoxCollider2D>().bounds.size.y / 2f), 0);
    }
    void Start()
    {
        //m_GestorCheckpoint = transform.parent.GetComponent<GestorCheckpoint>();
        //if(m_GestorCheckpoint==null) transform.parent.parent.GetComponent<GestorCheckpoint>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activo && collision.CompareTag("Player"))
        {
            //if(m_Data_Singleton.getIndiceCheckpoint() < numero)
            //{
                valor = true;
                m_GestorCheckpoint.setCheckpoint(numero);
            //}
        }
    }
    private void OnDrawGizmosSelected()
    {
        Vector3 miPosicionGizmo = new Vector3(transform.position.x, transform.position.y - (GetComponent<BoxCollider2D>().bounds.size.y / 2f), 0);
        Gizmos.color = Color.red;
        Gizmos.DrawCube(miPosicionGizmo, new Vector3(0.2f,0.2f,0.2f));
    }
}
