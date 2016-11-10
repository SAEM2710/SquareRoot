using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

enum MovementMode
{
    Rolling,
    Hopping
};

public class SPlayer : MonoBehaviour
{
    [SerializeField] private float m_fTranslationSpeed;
    [SerializeField] private float m_fRotationSpeed;
    [SerializeField] private float m_fForce;
    [SerializeField] private float m_fFrequence;
    [SerializeField] private Vector2 m_v2ForceVector; //Always set positive value
    [SerializeField] private MovementMode m_mmMovement;

    private float m_fTime;
    private bool m_bIsGrounded, m_bForceIsApplied;


    // Use this for initialization
    void Start()
    {
        m_mmMovement = MovementMode.Hopping;
        m_fTime = 0f;
        m_bIsGrounded = false;
        m_bForceIsApplied = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Deformation();
        switch(m_mmMovement)
        {
            case MovementMode.Hopping:
                Hop();
                break;
            case MovementMode.Rolling:
                Roll();
                break;
        }
    }

    private void Deformation()
    {
        if (m_fTime > m_fFrequence)
        {
            m_fTime = 0f;
            if (transform.localScale.y > 0.9f)
            {
                transform.localScale -= new Vector3(0f, 0.01f, 0f);
            }
            else
            {
                transform.localScale -= new Vector3(0f, -0.01f, 0f);
            }
        }
        m_fTime += Time.deltaTime;
    }

    private void ApplyForce(Vector2 _v2ForceVector)
    {
        if (m_bIsGrounded)
        {
            if (!m_bForceIsApplied)
            {
                GetComponent<Rigidbody2D>().AddForce(_v2ForceVector * m_fForce);
                m_bForceIsApplied = true;
            }
        }
    }

    private void Hop()
    {
        if(Input.GetAxis("Horizontal") > 0f)
        {
            ApplyForce(m_v2ForceVector);
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            Vector2 v2ForceVector = new Vector2();
            v2ForceVector = m_v2ForceVector;
            v2ForceVector.x = -m_v2ForceVector.x;
            ApplyForce(v2ForceVector);
        }
    }

    private void Roll()
    {
        float fTranslation = Input.GetAxis("Horizontal") * m_fTranslationSpeed;
        float fRotation = Input.GetAxis("Horizontal") * m_fRotationSpeed;
        fTranslation *= Time.deltaTime;
        fRotation *= Time.deltaTime;
        transform.Translate(fTranslation, 0, 0);
        transform.GetChild(0).Rotate(0, 0, -fRotation);
    }

    #region Triggers

    void OnTriggerEnter2D(Collider2D _c2dCollider)
    {
        if (_c2dCollider.gameObject.layer == 9)
        {
            string sTag;
            sTag = _c2dCollider.tag; 
            switch(sTag)
            {
                case "TV":
                    _c2dCollider.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                    break;
                case "Door":
                    SceneManager.LoadScene("T2");
                    break;
            }
        }
    }

    void OnTriggerExit2D(Collider2D _c2dCollider)
    {
        if (_c2dCollider.gameObject.layer == 9)
        {
            string sTag;
            sTag = _c2dCollider.tag;
            switch (sTag)
            {
                case "TV":
                    _c2dCollider.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                    break;
                /*case "Door":
                    SceneManager.LoadScene("T2");
                    break;*/
            }
        }
    }

    #endregion

    #region Collisions

    void OnCollisionEnter2D(Collision2D _c2dCollision)
    {
        if(_c2dCollision.gameObject.CompareTag("Floor"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            m_bIsGrounded = true;
            m_bForceIsApplied = false;
        }
    }

    void OnCollisionExit2D(Collision2D _c2dCollision)
    {
        if (_c2dCollision.gameObject.CompareTag("Floor"))
        {
            m_bIsGrounded = false;
        }
    }

    #endregion
}
