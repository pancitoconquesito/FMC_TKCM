using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Checkpoint : MonoBehaviour
{
    public GameObject particles;
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
        if (activo && collision.CompareTag("Player") && !valor)
        {
            valor = true;
            m_GestorCheckpoint.setCheckpoint(numero);

            if(particles!=null)
                Instantiate(particles, new Vector3(transform.position.x, transform.position.y-2f,0), Quaternion.identity);
            m_GestorCheckpoint.reproducirAudio();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Vector3 miPosicionGizmo = new Vector3(transform.position.x, transform.position.y - (GetComponent<BoxCollider2D>().bounds.size.y / 2f), 0);
        Gizmos.color = Color.red;
        Gizmos.DrawCube(miPosicionGizmo, new Vector3(0.2f,0.2f,0.2f));
    }
}
