using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danioPatada : MonoBehaviour
{
    [SerializeField] private dataDanio m_dataDanio;
    private void OnTriggerStay2D(Collider2D collision)
    {
        IDamageable idamageable = collision.GetComponent<IDamageable>();
        m_dataDanio.setTransform(this.transform);
        m_dataDanio.posicionDanio = transform.position;
        if (idamageable != null)    idamageable.RecibirDanio_I(m_dataDanio);
    }
}
