using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataDanio : MonoBehaviour
{
    
    [SerializeField] public GLOBAL_TYPES.TIPO_DANIO tipo_danio;
    [SerializeField] public int danio;
    [SerializeField] private float impactoEmpuje;
    public Vector2 posicionDanio;
    public Transform m_transformAtacante;
    private GLOBAL_TYPES.ladoMirada m_lado;
    //public bool daniarAEnemigo;

    
    public GLOBAL_TYPES.AFECTA_A_ m_A_QuienDania;
    private void Start()
    {
        m_transformAtacante = transform;
    }
    public int getDanio()
    {
        return danio;
    }
    public GLOBAL_TYPES.ladoMirada getLado() { return m_lado; }
    public void setLado(GLOBAL_TYPES.ladoMirada valor) { m_lado = valor; }
    public float getImpactoEmpuje() { return impactoEmpuje; }
    public void setTransform(Transform valor) { m_transformAtacante = valor; }

    /*
    public void updateTransform()
    {
        m_transformAtacante = transform;
    }
    */
    /*
    public void updateTransform(Vector2 newTransform) {
        m_transformAtacante = transform;
    }*/

    /*
    public void setInfo(dataDanio _dataDanio)
    {
        so_ARMA m_so_ARMA = Resources.Load<so_ARMA>("ARMAS/" + TIPO_arma.getParse_TipoArma_STRING(Data_Singleton.instancia.getArmaSeleccionada()));

        tipo_danio = _dataDanio.tipo_danio;
        danio=_dataDanio.danio;
        impactoEmpuje=_dataDanio.impactoEmpuje;
        posicionDanio=_dataDanio.posicionDanio;
        //m_transformAtacante;
    }*/
}
