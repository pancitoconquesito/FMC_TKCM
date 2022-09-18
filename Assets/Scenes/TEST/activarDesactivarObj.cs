using UnityEngine;
public class activarDesactivarObj : MonoBehaviour
{
    [SerializeField]private bool comienzaDesactivado = true;
    [SerializeField] private GameObject[] L_GO;
    private bool currentEstado;
    void Start()
    {
        currentEstado = !comienzaDesactivado;
    }
    public void turnActivo()
    {
        currentEstado = !currentEstado;
        foreach (var item in L_GO)
            item.SetActive(currentEstado);
    }
}
