using UnityEngine;
public class AB_controller : MonoBehaviour, IDamageable
{
    [SerializeField] private A_B_Manager.Estado_AB m_estado;
    [SerializeField] private A_B_Manager m_A_B_Manager;

    [SerializeField] private Animator m_animator;
    [SerializeField] private Collider2D m_Collider2D;

    [SerializeField] private bool activo;
    private float currentTime = 0;
    private A_B_Manager.Estado_AB otherState;
    private void Start()
    {
        if (m_estado == A_B_Manager.Estado_AB.A) otherState = A_B_Manager.Estado_AB.B;
        else otherState = A_B_Manager.Estado_AB.A;
    }
    private void Update()
    {
        if (currentTime > -1) currentTime -= Time.deltaTime;
    }
    public void updateEstado(A_B_Manager.Estado_AB _estado)
    {
        activo = (m_estado == _estado);
        if(activo)
            m_animator.SetTrigger("Activo");
        else
            m_animator.SetTrigger("Apagado");
        m_Collider2D.enabled = activo;
    }
    public bool RecibirDanio_I(dataDanio m_dataDanio)
    {
        if (currentTime > 0) return false;
        currentTime = 0.35f;
        //m_Collider2D.enabled = activo;
        if (activo)
        {

            if (m_A_B_Manager.isOverlapPJ(otherState))
            {
                print("is overlap  "+transform.parent.name);
                return false;
            }
            //print($"{transform.name}");

            //activo = false;
            m_A_B_Manager.updateEstado(otherState);
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool overlapPJ = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent != null && collision.transform.parent.CompareTag("Player")) overlapPJ = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent != null && collision.transform.parent.CompareTag("Player")) overlapPJ = false;
    }
    internal bool isOverlapPJ()
    {
        return overlapPJ;
    }
}
