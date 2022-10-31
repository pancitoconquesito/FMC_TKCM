using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPooling))]
public class emitirParticulas : MonoBehaviour
{
    [SerializeField] private changeMirada m_changeMirada;
    [SerializeField]private float tiempo;
    [SerializeField] private ObjectPooling m_ObjectPooling;
    [SerializeField] private bool invertirLados;
    private Vector3 localScale;
    private void Awake()
    {
       // m_ObjectPooling = GetComponent<ObjectPooling>();
    }



    [ContextMenu("funcionA")]
    public void emitir()
    {
        //print("Emitir!!!!!!");
        
        if (invertirLados)
        {
            GameObject obj = m_ObjectPooling.emitirObj(tiempo, false);
            if (m_changeMirada.getMirada() == GLOBAL_TYPES.ladoMirada.izquierda)
            {
                //1
                obj.transform.localScale = new Vector3(1,1,1);
            }
            else
            {
                obj.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            m_ObjectPooling.emitirObj(tiempo, false);
        }
        /*if(m_changeMirada.getMirada() == GLOBAL_TYPES.ladoMirada.izquierda)
        {
            obj.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }
        else
        {
            obj.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }*/
    }
}
