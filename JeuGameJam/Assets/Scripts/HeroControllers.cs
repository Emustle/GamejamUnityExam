using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControllers : MonoBehaviour
{
    public float MaxSpeed = 3f;
    public float CdDash = 5f;

    private float m_MoveX;
    private float m_MoveY;
    private bool EnCd = false;
    private Rigidbody2D m_Rb;
    private Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        m_Rb = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        float t_InputX = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.A))
            Flip(true);

        float t_InputY = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.D))
            Flip(false);

        m_MoveX = t_InputX * MaxSpeed;
        m_MoveY = t_InputY * MaxSpeed;

        if (Mathf.Abs(t_InputX) >= Mathf.Abs(t_InputY))
        {
            m_Animator.SetFloat("Speed", Mathf.Abs(m_MoveX));
        }
        else
        {
            m_Animator.SetFloat("Speed", Mathf.Abs(m_MoveY));
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            m_Animator.Play("Attack");
        }

        if (Input.GetKey(KeyCode.Mouse1) && !EnCd)
        {
            Boost();
            Invoke("StopBoost", 0.3f);
            GestionCd();
        }
    }

    private void FixedUpdate()
    {
        m_Rb.velocity = new Vector2(m_MoveX, m_MoveY);
    }

    private void Flip(bool bLeft)
    {
        transform.localScale = new Vector3(bLeft ? 1 : -1, 1, 1);
    }

    private void Boost()
    {
        MaxSpeed = 15;
    }

    private void StopBoost()
    {
        MaxSpeed = 3;
    }

    private void GestionCd()
    {
        EnCd = true;
        Invoke("CdDispo", 3f);
    }

    private void CdDispo()
    {
        EnCd = false;
    }
}
