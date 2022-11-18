using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlManager : MonoBehaviour
{
    public enum PERFIL
    {
        keyboard, gamepad
    }
    private PERFIL m_perfil;
    private void Awake()
    {
        //m_perfil = PERFIL.keyboard;
        
        //InputSystem.DisableDevice(InputSystem.disconnectedDevices(), false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(m_ControlPJ.GAMEPADScheme.deviceRequirements.Count);
        //print(InputSystem.GetDevice<Gamepad>().IsActuated());

    }
}
