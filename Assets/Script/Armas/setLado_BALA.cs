using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setLado_BALA : MonoBehaviour
{
    private changeMirada miradaPJ;
    private balaMovement m_balaMovement;
    // Start is called before the first frame update
    void Start()
    {
        miradaPJ = referencesMASTER.instancia.miradaPJ;
        m_balaMovement = GetComponent<balaMovement>();
    }
    /*
    private void OnEnable()
    {
        if(miradaPJ==null) miradaPJ = referencesMASTER.instancia.miradaPJ;
        if (m_balaMovement==null) m_balaMovement = GetComponent<balaMovement>();
        if (miradaPJ.getMirada()==GLOBAL_TYPES.ladoMirada.derecha)
            m_balaMovement.setVelocidad(-m_balaMovement.getVelocidad());
    }*/
    // Update is called once per frame
    void Update()
    {
        
    }
}
