using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class A_B_Manager : MonoBehaviour
{
    public enum Estado_AB
    {
        A,B
    }
    [SerializeField] private Estado_AB m_Estado_AB;
    public A_B_Manager.Estado_AB Estado { get { return m_Estado_AB; } set { m_Estado_AB = value; } }
    [SerializeField] private GameObject m_Container_A, m_Container_B;
    private List<AB_controller> m_A;
    private List<AB_controller> m_B;
    private void Start()
    {
        int countA = m_Container_A.transform.childCount;
        m_A = new List<AB_controller>();
        for (int i = 0; i < countA; i++)
        {
            m_A.Add(m_Container_A.transform.GetChild(i).GetComponent<AB_controller>());
        }
        int countB = m_Container_B.transform.childCount;
        m_B = new List<AB_controller>();
        for (int i = 0; i < countB; i++)
        {
            m_B.Add(m_Container_B.transform.GetChild(i).GetComponent<AB_controller>());
        }

        foreach (var item in m_A)
        {
            item.updateEstado(m_Estado_AB);
        }
        foreach (var item in m_B)
        {
            item.updateEstado(m_Estado_AB);
        }
    }
    
    public void updateEstado(A_B_Manager.Estado_AB _estado)
    {
        m_Estado_AB = _estado;
        foreach (var item in m_A)
        {
            item.updateEstado(m_Estado_AB);
        }
        foreach (var item in m_B)
        {
            item.updateEstado(m_Estado_AB);
        }
    }

    internal bool isOverlapPJ(Estado_AB otherState)
    {
      // if(otherState == Estado_AB.A)
       // {
            foreach (var item in m_A)
            {
                if (item.isOverlapPJ()) return true;
            }
       //}
        //else
       // {
            foreach (var item in m_B)
            {
                if (item.isOverlapPJ()) return true;
            }
        //}
        return false;
    }
}
