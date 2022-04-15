using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotEffect : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float m_JumpForce;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * m_JumpForce);
        Destroy(gameObject, 1.5f);
    }

}
