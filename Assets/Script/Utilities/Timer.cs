using UnityEngine;
public class Timer : MonoBehaviour
{
    public enum MODO_INICIO
    {
        igualATiempo, cero
    }
    [SerializeField] private float tiempo;
    [SerializeField] private MODO_INICIO m_modoInicio;
    //public UnityEvent alTerminar;
    private ISpecial m_ISpecial;
    private float currenttime;
    private bool activo = false;
    void Start()
    {
        switch (m_modoInicio)
        {
            case MODO_INICIO.cero:
                {
                    currenttime = 0;
                    break;
                }
            case MODO_INICIO.igualATiempo:
                {
                    currenttime = tiempo;
                    break;
                }
        }
        currenttime = tiempo;
        m_ISpecial = GetComponent<ISpecial>();
    }
    void Update()
    {
        if (currenttime < 0)
        {
            if (activo)
            {activo = false;
                m_ISpecial.disablePower();
            }
        }
        else
            currenttime -= Time.deltaTime;
    }
    public void restart()
    {
        currenttime = tiempo;
        activo = true;
    }
    public float getCurrentTime() => currenttime;
    public float getTime() => tiempo;
}
