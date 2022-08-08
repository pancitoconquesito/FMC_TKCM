using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class balaMovement : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private Rigidbody2D m_Rigidbody2D;
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private float lado;
    public void setLado()
    {
        changeMirada miradaPJ = referencesMASTER.instancia.miradaPJ;
        if (miradaPJ.getMirada() == GLOBAL_TYPES.ladoMirada.izquierda)
            lado = -1;
        else lado = 1;
    }
    public float getVelocidad()
    {
        return velocidad;
    }
    public void setVelocidad(float valor)
    {
        velocidad = valor;
    }
    private void OnEnable()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        setLado();
    }
    private void FixedUpdate()
    {
        m_Rigidbody2D.velocity=Vector2.right * velocidad * lado;
    }
}
