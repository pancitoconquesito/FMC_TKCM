using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cargarPoder : MonoBehaviour
{
    private ISpecial m_Poder;
    void Start()
    {
        TIPO_arma.ArmaTipo tipoArma_TIPO = Data_Singleton.instancia.getArmaSeleccionada();
        string tipoArmas_s=TIPO_arma.getParse_TipoArma_STRING(tipoArma_TIPO);
        GameObject poder = Resources.Load<GameObject>("Poderes/PODER_"+ tipoArmas_s);
        Instantiate(poder, transform.position, Quaternion.identity, transform);
        m_Poder = poder.GetComponent<ISpecial>();
    }

}
