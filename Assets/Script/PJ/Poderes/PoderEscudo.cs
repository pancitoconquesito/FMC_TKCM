using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Timer))]
public class PoderEscudo : PoderBase
{
    [SerializeField] private float speedRotation;
    [SerializeField] private GameObject[] m_L_escudos;
    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    //[SerializeField]
    public PoderEscudo() : base()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        base.m_UpdateCirclePower = referencesMASTER.instancia.m_UpdateCirclePower;
        base.m_UpdateRecargaPoder = referencesMASTER.instancia.m_UpdateRecargaPoder;
        base.m_UpdateRecargaPoder.setParameters(base.tiempoRecarga);
    }
    void Update()
    {
        if(activoPoder)
            transform.Rotate(Vector3.forward, Time.deltaTime * speedRotation, Space.World);
    }
    public override void activatePower()
    {
        if (base.comprobar()) base.activatePower();
        else return;
        //implementacion de escudo
        foreach (GameObject item in m_L_escudos) item.SetActive(true);
        m_SpriteRenderer.enabled = true;
    }
    public override void disablePower()
    {
        base.disablePower();
        foreach (GameObject item in m_L_escudos) item.SetActive(false);
        m_SpriteRenderer.enabled = false;
    }
}
