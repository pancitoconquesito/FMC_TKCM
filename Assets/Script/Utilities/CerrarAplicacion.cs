
using UnityEngine;

public class CerrarAplicacion : MonoBehaviour
{
    [SerializeField] private float delay;
    public void cerrarAplicacionFunction()
    {
        Invoke("salir", delay);
    }
    private void salir()
    {
        print("saliendo");
        Application.Quit();
    }
}
