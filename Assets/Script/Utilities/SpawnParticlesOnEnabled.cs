using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticlesOnEnabled : MonoBehaviour
{
    [SerializeField] private ObjectPooling m_ObjectPooling;
    [SerializeField] private float tiempo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private bool firstEnable = false;
    private void OnEnable()
    {
        if (firstEnable)
        {
            //print("emitir");
            m_ObjectPooling.emitirObj(tiempo, false);
        }
        firstEnable = true;
    }
}
