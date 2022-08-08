using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirEnXTiempo : MonoBehaviour
{
    public enum destruirA
    {
        selfDestroy, destroyParent
    }
    [SerializeField] private destruirA m_destruirA;
    [SerializeField] private float tiempo;
    private float currentTiempo = 0;
    private bool finish = false;
    void Update()
    {
        if (!finish)
        {
            currentTiempo += Time.deltaTime;
            if (currentTiempo > tiempo)
            {
                finish = true;
                destruir();
            }
        }
    }
    private void destruir()
    {
        switch (m_destruirA)
        {
            case destruirA.selfDestroy:
                {
                    Destroy(gameObject);
                    break;
                }
            case destruirA.destroyParent:
                {
                    Destroy(gameObject.transform.parent.gameObject);
                    break;
                }
        }
    }
}
