using UnityEngine;
public class GestorCambioIdioma : MonoBehaviour
{
    public delegate void miDelegate();
    public event miDelegate CambioLenguaje;
    public void InvokeCambioIdioma(int valor)
    {
        DATA.instance.save_load_system.m_dataGame.m_DATA_CONFIG_GAME.IDIOMA = valor;
        DATA.instance.save_load_system.save_();
        CambioLenguaje?.Invoke();
    }
}
