using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderAmetralladora : PoderBase
{
    //[SerializeField]private S
    // Start is called before the first frame update
    void Start()
    {
        base.startParameterBase();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void activatePower()
    {
        if (base.comprobar()) base.activatePower();
        else return;
        //implementar explosion
        ejecutarPoder();
    }
    private void ejecutarPoder()
    {
        print("ametralladora!!!");
        Time.timeScale = 0.4f;
    }
    public override void disablePower()
    {
        base.disablePower();
        print("Poder desactivado");
        Time.timeScale = 1;
    }
}
