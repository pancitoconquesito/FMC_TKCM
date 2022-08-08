using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nS_Generico : MonoBehaviour, IDamageable
{
    [SerializeField]private int vida;
    [SerializeField] private float cadenciaRecibirDanio;
    private float current_cadenciaRecibirDanio;
    [SerializeField] private Animator m_animator;
    private bool vivo = true;

    public bool RecibirDanio_I(dataDanio m_dataDanio)
    {
        if (vivo && current_cadenciaRecibirDanio<0)
        {
            current_cadenciaRecibirDanio = cadenciaRecibirDanio;
            vida -= m_dataDanio.danio;

            if (vida <= 0)
            {
                vivo = false;
                morir();
            }
            else
            {
                //
            }
            return true;
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (current_cadenciaRecibirDanio > -1) current_cadenciaRecibirDanio -= Time.deltaTime;
    }

    private void morir()
    {
        print("ns muerto");
        //m_animator.SetTrigger("Morir");
        Destroy(transform.parent.gameObject);
    }
    
}
