using System;
using UnityEngine;
public class dashPJ : MonoBehaviour
{
    [Header("-- Param --")]
    [SerializeField]private movementPJ m_movementPJ;
    [SerializeField] private Rigidbody2D rigiPJ;
    [SerializeField] private float potenciaDash;
    [SerializeField] private float cadencia;
    [SerializeField] private float duracionDash;
    
    private float current_cadencia;

    public void setValores(float _potenciaDash, float _cadenciaDash, float _duracionDash)
    {
        potenciaDash = _potenciaDash;
        cadencia = _cadenciaDash;
        duracionDash = _duracionDash;
    }


    private void Start()
    {
        current_cadencia = 0;
    }
    private void Update()
    {
        if(current_cadencia>-1)
            current_cadencia -= Time.deltaTime;
    }
    public bool startDash(GLOBAL_TYPES.ladoMirada lado)
    {
        if(current_cadencia < 0)
        {
            Invoke("terminarDash", duracionDash);
            current_cadencia = cadencia;
            int _lado;
            if (lado == GLOBAL_TYPES.ladoMirada.izquierda)
            {
                _lado = -1;
            }
            else
            {
                _lado = 1;
            }
            rigiPJ.velocity = Vector2.zero;
            rigiPJ.velocity = new Vector2(_lado * potenciaDash, 0) ;
            return true;
        }
        return false;
    }
    private void terminarDash()
    {
        m_movementPJ.returnNormalMovement();
    }

   
}
