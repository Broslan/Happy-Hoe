using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private float m_CameraOfsetY = -10;
    [SerializeField] float m_CameraSpeed = 2f; 
    [SerializeField] public int cameraLevel = 0;
    private Transform m_CameraTransform;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        m_CameraTransform = Camera.main.transform;
        if(PlayerPrefs.GetInt("SoundSetting") == 1)
        {
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(m_CameraTransform.position.y > m_CameraOfsetY * cameraLevel)
        {
            m_CameraTransform.Translate(Vector3.down * Time.fixedDeltaTime * m_CameraSpeed);
        }
    }


}
