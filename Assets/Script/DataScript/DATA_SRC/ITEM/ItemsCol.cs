using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ItemsCol : MonoBehaviour
{
    public enum ACTION_TO_GET
    {
        destroy, animation, none
    }
    //[SerializeField]private 
    //[SerializeField] private ui_itemObtenido m_ui_itemObtenido;
    [SerializeField] protected SO_ITEM m_so_item;
    [SerializeField] private GameObject ui_item_GO;
    [SerializeField] private float tiempoDespuesDeColisionar;
    [SerializeField] protected ACTION_TO_GET m_ACTION_TO_GET;
    [SerializeField]private Animator m_Animator;
    [SerializeField] private string TriggerNameNewAnimation;
    public UnityEvent alColisionar;
    public UnityEvent XTiempoDespuesDeColisionar;
    protected movementPJ m_movementPJ;
    void Start()
    {
        m_movementPJ=GameObject.FindGameObjectWithTag("Player").GetComponent<movementPJ>();

        /*if (DATA.instance.save_load_system.isItemObtenido(m_so_item.ID_ITEM))
        {
            Destroy(gameObject);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Invoke("ejecutar_eventoXtiempoDespuesDeCol",tiempoDespuesDeColisionar);
            //XTiempoDespuesDeColisionar.Invoke();
            switch (m_ACTION_TO_GET)
            {
                case ACTION_TO_GET.destroy:
                    {
                        Destroy(gameObject);
                        break;
                    }
                case ACTION_TO_GET.animation:
                    {
                        m_Animator.SetTrigger(TriggerNameNewAnimation);
                        break;
                    }
            }
            //m_movementPJ.cogerItem();
            //ui_item_GO.SetActive(true);
            //m_ui_itemObtenido.setValues(m_so_item);
            alColisionar.Invoke();

            //DATA.instance.save_load_system.saveItem(m_so_item.ID_ITEM);
        }
    }
    private void ejecutar_eventoXtiempoDespuesDeCol()
    {
        XTiempoDespuesDeColisionar.Invoke();
    }
}
