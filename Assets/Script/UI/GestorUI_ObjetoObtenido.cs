using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GestorUI_ObjetoObtenido : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private TextMeshProUGUI m_texto;
    [SerializeField] private Image m_img;
    private testIdiomaSAVE_LOAD idioma_data;
    //private float currentTime = 0;
    //controlador
    void Start()
    {
        idioma_data= DATA.instance.transform.GetComponent<testIdiomaSAVE_LOAD>();
    }

    void Update()
    {
        
    }
    public void setValues(SO_ITEM _soItem, float delay)
    {
        //detener pj


        GLOBAL_TYPES.IDIOMA idioma_type = idioma_data.getIdioma();
        int idioma_int = GLOBAL_TYPES.parseIdioma(idioma_type);
        //currentTime = tiempoLimite;

        m_animator.SetTrigger("Start");

        m_texto.text = _soItem.info[idioma_int].descripcion;
        m_img.sprite = _soItem.info[idioma_int].sp_imagen;

        Invoke("TerminarUI", delay);
    }
    private void TerminarUI()
    {
        m_animator.SetTrigger("Exit");

        //mover pj
        print("ui terminado");
    }
}
