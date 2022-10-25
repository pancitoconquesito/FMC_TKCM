using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TransicionMuerte : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_sp_pj;
    //[SerializeField] private Image m_transicion;
    [SerializeField] private float tiempo;
    [SerializeField] private float limite;
    [SerializeField] private float delayCircle;
    private Animator m_animacionTransicion;
    private float current_delayCircle=0;
    //private GameObject 
    private RectTransform m_RectTransform;
    private float currentValue = 0.0001f;
    private bool complete = false;
    // Start is called before the first frame update
    void Start()
    {
       // m_RectTransform = GetComponent<RectTransform>();
       //m_RectTransform.LeanScale(new Vector3(limite, limite, 1), tiempo);
        
        
        // m_sp_pj = referencesMASTER.instancia.m_movementPJ.
        referencesMASTER.instancia.m_GO_UI_CargadorPoder.SetActive(false);

        m_sp_pj.sortingLayerName = "muerte";
        m_sp_pj.sortingOrder = 1;

        referencesMASTER.instancia.m_Gestor_UI_Inventario.closeInventary();
        m_animacionTransicion = referencesMASTER.instancia.m_anim_UI_transicion;
        Invoke("transicionFinal",2f);
    }
    private void transicionFinal()
    {
        m_animacionTransicion.SetTrigger("start");
    }
    void Update()
    {
        if(current_delayCircle < delayCircle) current_delayCircle += Time.deltaTime;
        else
        {
            if (!complete)
            {
                complete = true;
                m_RectTransform = GetComponent<RectTransform>();
                m_RectTransform.LeanScale(new Vector3(limite, limite, 1), tiempo);
            }
        }
    }
    private void OnDestroy()
    {
        LeanTween.cancelAll();
    }
}
