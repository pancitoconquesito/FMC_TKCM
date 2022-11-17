using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_Item : ItemsCol
{
    [Header("-- ColItem Params --")]

    [SerializeField] private Collider2D m_Collider2D;
    [SerializeField] private float delay;

    private GestorUI_ObjetoObtenido m_GestorUI_ObjetoObtenido;
    private void Start()
    {
        m_GestorUI_ObjetoObtenido = referencesMASTER.instancia.m_GestorUI_ObjetoObtenido;
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        m_Collider2D.enabled = false;
        if(m_movementPJ==null) m_movementPJ = GameObject.FindGameObjectWithTag("Player").GetComponent<movementPJ>();
        m_movementPJ.startObjectGeneric(delay);
        m_GestorUI_ObjetoObtenido.setValues(m_so_item, delay);

        DATA.instance.save_load_system.saveItem(m_so_item.ID_ITEM);
        base.OnTriggerEnter2D(collision);
    }

}
