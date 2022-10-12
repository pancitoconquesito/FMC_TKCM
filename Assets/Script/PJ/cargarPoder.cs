using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cargarPoder : MonoBehaviour
{
    [SerializeField] private movementPJ m_movementPJ;
    [SerializeField] private UpdateCirclePower m_UpdateCirclePower;
    private ISpecial m_Poder;
    void Start()
    {
        TIPO_arma.ArmaTipo tipoArma_TIPO = Data_Singleton.instancia.getArmaSeleccionada();
        if (tipoArma_TIPO == TIPO_arma.ArmaTipo.none) return;
        string tipoArmas_s=TIPO_arma.getParse_TipoArma_STRING(tipoArma_TIPO);
        GameObject poder = Resources.Load<GameObject>("Poderes/PODER_"+ tipoArmas_s);
        print($"Cargar prefab poder en direccion : Poderes/PODER_{tipoArmas_s}");
        Instantiate(poder, transform.position, Quaternion.identity, transform);

        Invoke("enviarReferencia",0.1f);
    }
    private void enviarReferencia()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Poder").transform.GetChild(0).gameObject;
        m_Poder = obj.transform.GetComponent<ISpecial>();
        m_movementPJ.setPoder(m_Poder);
        Timer timer = obj.transform.GetComponent<Timer>();
        m_UpdateCirclePower.setParameters(timer);
    }
}
