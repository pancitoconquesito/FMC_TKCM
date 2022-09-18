using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class setValueWithSlider : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private Slider m_slider;
    public enum CANAL_AUDIO{background, fx, voces, MASTER}
    [SerializeField] private CANAL_AUDIO m_canalAudio;
    void Start()
    {
        
    }
    public void startValues()
    {
        m_slider.onValueChanged.AddListener(delegate { onSliderChange(); });
        switch (m_canalAudio)
        {
            case CANAL_AUDIO.MASTER:
                {
                    m_slider.value = testAudio.instancia.getVolumenSave_MASTER();
                    break;
                }
            case CANAL_AUDIO.background:
                {
                    m_slider.value = testAudio.instancia.getVolumenSave_background();
                    break;
                }
            case CANAL_AUDIO.fx:
                {
                    m_slider.value = testAudio.instancia.getVolumenSave_fx();
                    break;
                }
            case CANAL_AUDIO.voces:
                {
                    m_slider.value = testAudio.instancia.getVolumenSave_voces();
                    break;
                }
        }
    }
    private void onSliderChange()
    {
        //print("m_slider : "+ m_slider.value);//0-100
        m_slider.value = GLOBAL_TYPES.Round(m_slider.value,2);
        texto.text= (m_slider.value*100f) + " / 100";
        updateVolumen(m_canalAudio, m_slider.value);
    }
    public void updateWithMaster()
    {
        updateVolumen(m_canalAudio, m_slider.value);
    }
    private void updateVolumen(CANAL_AUDIO canal, float volumen)
    {
        switch (canal)
        {
            case CANAL_AUDIO.MASTER:
                {
                    testAudio.instancia.setVolumen_MASTER(volumen);
                    break;
                }
            case CANAL_AUDIO.background:
                {
                    testAudio.instancia.setVolumenBackground(volumen);
                    break;
                }
            case CANAL_AUDIO.fx:
                {
                    testAudio.instancia.setVolumen_FX(volumen);
                    break;
                }
            case CANAL_AUDIO.voces:
                {
                    testAudio.instancia.setVolumenVoces(volumen);// m_slider.value
                    break;
                }
        }
    }
}
