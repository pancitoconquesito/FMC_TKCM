using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class retornarObjectPooling : MonoBehaviour
{
    public ObjectPooling m_ObjectPooling;
    [SerializeField] private ObjectPooling m_OP_PART_BALA;


    private void Start()
    {
        
    }
    public void setObjectPoolingMASTER(ObjectPooling ObjectPooling_)
    {
        m_ObjectPooling = ObjectPooling_;
    }
    public void retornar()
    {
        if (m_OP_PART_BALA != null)
        {
            //print("NICE");
            m_OP_PART_BALA.emitirObj(1.5f, false);
        }
        if (m_ObjectPooling == null)
        {
            print("ES NULO");
            Destroy(gameObject);
            //Debug.Break();
        }else
            m_ObjectPooling.ReturnObjPool(gameObject);
    }
}
