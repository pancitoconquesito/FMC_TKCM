using UnityEngine;
using UnityEngine.UI;
public class UpdateRecargaPoder : MonoBehaviour
{
    [SerializeField] private Image m_image;
    [SerializeField]private float _tiempoRecarga;
    private float m_currentValue;
    private float m_percentage;
    private bool activoPoder=false;
    private bool canStartPower = true;

    void Update()
    {
        if (activoPoder)
        {
            m_image.fillAmount = 0;
            canStartPower = false;
            return;
        }
        updateFill();
    }
    private void updateFill()
    {
        if (m_currentValue < _tiempoRecarga)
        {
            m_currentValue += Time.deltaTime;
            canStartPower = false;
        }
        else
        {
            m_currentValue = _tiempoRecarga;
            canStartPower = true;
        }
        m_percentage = m_currentValue / _tiempoRecarga;
        //if (m_percentage > 1) m_percentage = 1;
        m_image.fillAmount = m_percentage;
    }
    public void setActive(bool value)
    {
        activoPoder = value;
        if (value)
        {
            m_image.fillAmount = 0;
            m_currentValue = 0;
        }
    }
    /*
    public void setCurrentValue(float value)
    {
        m_currentValue = value;
        updateFill();
    }*/
    public void setParameters(float tiempoRecarga_)
    {
        _tiempoRecarga = tiempoRecarga_;
        m_currentValue = _tiempoRecarga;
        m_image.fillAmount = 1;
    }
    public bool CanStartPower() => canStartPower;
}
