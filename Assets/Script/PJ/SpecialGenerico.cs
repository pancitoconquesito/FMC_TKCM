using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialGenerico : MonoBehaviour, ISpecial
{
    [SerializeField] private float m_cadenciaPoder;
    private float current_cadenciaPoder=0;
    [SerializeField] private float m_duracionPoder;
    private float current_duracionPoder=0;
    [SerializeField] private string _DIR;

    public void activatePower()
    {
        print("Poder!!!!!!!!!!!!!!");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
