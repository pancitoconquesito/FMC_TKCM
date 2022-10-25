using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class respawnPJ : MonoBehaviour
{
    [SerializeField] private float delayCambioScene;

    public void respawn()
    {
        //animacion de pivoteCam
        //transicion y cambio de layers
        Invoke("cambiarScene", delayCambioScene);
    }
    public void respawn(float delay)
    {
        //animacion de pivoteCam
        //transicion y cambio de layers
        Invoke("cambiarScene", delay);
    }
    private void cambiarScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
