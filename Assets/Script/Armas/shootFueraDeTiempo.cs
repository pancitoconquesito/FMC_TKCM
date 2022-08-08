using UnityEngine;
public class shootFueraDeTiempo : MonoBehaviour
{
    private shootPJ m_shootPJ;
    void Start()
    {
        m_shootPJ=referencesMASTER.instancia.m_shootPJ;
    }
    public void shootDesfase()
    {
        m_shootPJ.spawnBullet_NoInstantaneo();
    }
}
