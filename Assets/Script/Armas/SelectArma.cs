using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectArma : MonoBehaviour
{

    private TIPO_arma.ArmaTipo armaSeleccionada;
    public void BTN_selectArma(int arma)
    {
        switch (arma)
        {
            case 0:
                {
                    armaSeleccionada = TIPO_arma.ArmaTipo.pistola;
                    break;
                }
            case 1:
                {
                    armaSeleccionada = TIPO_arma.ArmaTipo.bazuca;
                    break;
                }
            case 2:
                {
                    armaSeleccionada = TIPO_arma.ArmaTipo.ametralladora;
                    break;
                }
            case 3:
                {
                    armaSeleccionada = TIPO_arma.ArmaTipo.plasma;
                    break;
                }
        }
        Data_Singleton.instancia.setArmaSeleccionada(armaSeleccionada);
    }
}
