using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Gestor_UI_nekoEsfera : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI texto;
    //[SerializeField]private 
    // Start is called before the first frame update
    void Start()
    {
        texto.text = "= "+DATA.instance.getCantidadNekoEsfera();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
