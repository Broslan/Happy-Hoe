using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoeJumper : MonoBehaviour
{

    private Rigidbody2D m_HoeRiggedBoddy;
    [SerializeField] private float m_JumpForce = 850; //test_value look real in inspector
    bool  m_ButtonWasPushed = false;
    private float m_originalGravity;
    [SerializeField] private float m_FallSpeed = 10;
    [SerializeField] private ScoreManager m_ScoreManager;
    public Sprite[] Hoe;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource rewardSound;

    // Start is called before the first frame update
    void Start()
    {
        m_HoeRiggedBoddy = GetComponent<Rigidbody2D>();
        m_originalGravity = m_HoeRiggedBoddy.gravityScale;
        spriteRenderer.sprite = Hoe[PlayerPrefs.GetInt("isEquipped")];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            m_ButtonWasPushed = true;
        }

        if (m_ButtonWasPushed)
        {
            m_HoeRiggedBoddy.gravityScale = m_FallSpeed;
        }
        else
        {
            m_HoeRiggedBoddy.gravityScale = m_originalGravity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IGround ground = collision.collider.GetComponent<IGround>();
        //Debug.Log(collision.collider.name);
        //Debug.Log(groundCollision);
        if (ground != null)
        {
            if(ground.GetGroundType() != 3)
            {
                if (m_ButtonWasPushed)
                {
                    if (ground.GetGroundType() == 0)
                    {
                        m_HoeRiggedBoddy.velocity = Vector2.up * m_JumpForce;
                        m_ButtonWasPushed = false;
                        if (PlayerPrefs.GetInt("SoundSetting") == 1)
                        {
                            jumpSound.Play();
                        }
                    }
                    else
                    {
                        m_ScoreManager.AddItemToCombo(ground.GetGroundType());
                        ground.OnContact();
                        m_ButtonWasPushed = false;
                        if (PlayerPrefs.GetInt("SoundSetting") == 1)
                        {
                            rewardSound.Play();
                        }
                        Collider2D[] colliders = Physics2D.OverlapAreaAll(new Vector2(transform.position.x - 20f, transform.position.y - 5f), new Vector2(transform.position.x + 20f, transform.position.y + 1f));
                        foreach (var collider in colliders)
                        {
                            //BoxCollider2D box = collider.GetComponent<BoxCollider2D>();
                            if(collider.GetComponent<BoxCollider2D>() != null)
                            {
                                Destroy(collider.GetComponent<BoxCollider2D>().gameObject);
                            }
                        }
                    }
                }
                else
                {
                    m_HoeRiggedBoddy.velocity = Vector2.up * m_JumpForce;
                    m_ButtonWasPushed = false;
                    if (PlayerPrefs.GetInt("SoundSetting") == 1)
                    {
                        jumpSound.Play();
                    }
                }
            }
            else
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        m_ScoreManager.SetFinaleScore();




    }
}
