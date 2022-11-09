using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class habilitarAlDisparar : MonoBehaviour, IDamageable
{
    [SerializeField] private Collider2D m_collider;
    [SerializeField] private Animator m_animator;
    private bool activado = false;
    private bool overlapPlayer = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent!=null && collision.transform.parent.CompareTag("Player")) overlapPlayer = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent != null && collision.transform.parent.CompareTag("Player")) overlapPlayer = false;
    }
    public bool RecibirDanio_I(dataDanio m_dataDanio)
    {
        if (overlapPlayer) return false;
        if (!activado)
        {
            activado = true;
            m_animator.SetTrigger("Visible");
            m_collider.enabled = true;
        }
        return true;
    }

    public void desactivar()
    {
        activado = false;
        m_collider.enabled = false;
    }
}
