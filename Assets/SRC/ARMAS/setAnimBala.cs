using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setAnimBala : MonoBehaviour
{
    public enum Type_BALA_ANIM
    {
        pistola_0, bazuka_1, ametralladora_2, plasma_3
    }
    [SerializeField] private Type_BALA_ANIM typeBalaArma;
    private Animator m_Animator;


    private void setAnim()
    {
        switch (typeBalaArma)
        {
            case Type_BALA_ANIM.pistola_0:
                {
                    m_Animator.SetInteger("id_bala", 0);
                    break;
                }
            case Type_BALA_ANIM.bazuka_1:
                {
                    m_Animator.SetInteger("id_bala", 1);
                    break;
                }
            case Type_BALA_ANIM.ametralladora_2:
                {
                    m_Animator.SetInteger("id_bala", 2);
                    break;
                }
            case Type_BALA_ANIM.plasma_3:
                {
                    m_Animator.SetInteger("id_bala", 3);
                    break;
                }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        //setAnim();
    }
    private void OnEnable()
    {
        if(m_Animator==null)
            m_Animator = GetComponent<Animator>();
        setAnim();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
