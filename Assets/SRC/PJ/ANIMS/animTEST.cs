using UnityEngine;
public class animTEST : MonoBehaviour
{
    [SerializeField] private int select_anim_PJ;
    [SerializeField] private int select_anim_ARMA;
    [SerializeField] private Animator m_Animator_PJ;
    [SerializeField] private Animator m_Animator_ARMA;
    void Start()
    {
        m_Animator_PJ.SetInteger("var", select_anim_PJ);
        m_Animator_ARMA.SetTrigger("ChangeGun");
        m_Animator_ARMA.SetInteger("Arma_ID", select_anim_ARMA);
    }
}
