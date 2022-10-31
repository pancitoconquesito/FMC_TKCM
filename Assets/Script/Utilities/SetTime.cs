using UnityEngine;
public class SetTime : MonoBehaviour
{
    [SerializeField] private float tiempo=1;
    void Update()
    {
        Time.timeScale = tiempo;
    }
}
