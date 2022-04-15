using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDirt : MonoBehaviour
{
    private Transform m_dirtTransform;
    [SerializeField] float m_SpeedPerFrame = 0.01f;

    void Start()
    {
        m_dirtTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        m_dirtTransform.position = transform.position + new Vector3(m_SpeedPerFrame, 0, 0);
    }
}
