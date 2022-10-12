using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class cameraShake : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera m_CinemachineVirtualCamera;
    private CinemachineImpulseSource m_CinemachineImpulseSource;
    public static cameraShake instancia;
    private void Awake()
    {
        instancia = this;
    }
    private void Start()
    {
        m_CinemachineImpulseSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CinemachineImpulseSource>();
    }


    public void shake(float amount, float tiempo)
    {
        var noise = m_CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = amount;
        StartCoroutine(graduallyReduceShake(tiempo, noise));
    }
    private IEnumerator graduallyReduceShake(float tiempo, Cinemachine.CinemachineBasicMultiChannelPerlin noise)
    {
        float _time = tiempo;
        float reductionFactor = noise.m_AmplitudeGain / _time;
        while (_time > 0)
        {
            _time -= Time.deltaTime;
            noise.m_AmplitudeGain -= reductionFactor * Time.deltaTime;
            yield return null;
        }
        noise.m_AmplitudeGain = 0;
    }
    public void shake(float sustainTime, float decayTime, float intensity)
    {
        m_CinemachineImpulseSource.m_ImpulseDefinition.m_TimeEnvelope.m_SustainTime = sustainTime;
        m_CinemachineImpulseSource.m_ImpulseDefinition.m_TimeEnvelope.m_DecayTime = decayTime;
        m_CinemachineImpulseSource.m_ImpulseDefinition.m_AmplitudeGain = intensity;
        m_CinemachineImpulseSource.GenerateImpulse();
    }
    [ContextMenu("Ejecutar funcion A")]

    public void TEST()
    {
        shake(1,1);
    }
}
