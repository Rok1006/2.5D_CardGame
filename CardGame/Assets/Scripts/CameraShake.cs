using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    private CinemachineVirtualCamera cam;
    private float timer;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        cam = GetComponent<CinemachineVirtualCamera>();
        
    }
    private void Start()
    {
        EventHandler.Instance.onEnemyAttack.AddListener(ShakeCamera);
    }
    public void ShakeCamera(DamageFeedback feedback)
    {
        Debug.Log(feedback.intensity);
        CinemachineBasicMultiChannelPerlin perlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perlin.m_AmplitudeGain = feedback.intensity;
        timer = feedback.time;
    }

    private void Update()
    {
        if(timer > 0)
        {

            timer -= Time.deltaTime;
        }
        if(timer < 0)
        {
            CinemachineBasicMultiChannelPerlin perlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            perlin.m_AmplitudeGain = 0;
        }
    }
}
