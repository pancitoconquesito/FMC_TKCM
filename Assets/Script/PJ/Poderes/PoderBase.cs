using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PoderBase : MonoBehaviour, ISpecial
{
    [SerializeField] protected Timer m_timer;
    [SerializeField] protected float tiempoRecarga;
    protected UpdateCirclePower m_UpdateCirclePower;
    protected UpdateRecargaPoder m_UpdateRecargaPoder;
    protected bool activoPoder = false;

    public PoderBase()
    {
        
    }
    void Start()
    {
       
    }
    void Update()
    {
    }

    //[ContextMenu("activatePower")]
    public virtual void activatePower()
    {
        m_timer.restart();
        activoPoder = true;
        m_UpdateCirclePower.setActivo(true);
        m_UpdateRecargaPoder.setActive(true);
        //m_UpdateRecargaPoder.setCurrentValue(0);
    }

    public virtual void disablePower()
    {
        activoPoder = false;
        m_UpdateCirclePower.setActivo(false);
        m_UpdateRecargaPoder.setActive(false);
    }
    protected bool comprobar()
    {
        if (activoPoder)
        {
            print("el poder ya esta activo!");
            return false;
        }
        if (!m_UpdateRecargaPoder.CanStartPower())
        {
            print("aun no carga la barra de poder");
            return false; 
        }
        return true;
    }
}
