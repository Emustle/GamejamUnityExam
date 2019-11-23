﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControllers : MonoBehaviour
{
    public float DefaultSpeed = 3f;
    public float BoostSpeed = 15f;
    public float CdAttack = 1f;
    public float CdDash = 3f;

    private float ActualSpeed;
    private float m_MoveX;
    private float m_MoveY;
    private bool AttackEnCd = false;
    private bool DashEnCd = false;
    private Rigidbody2D m_Rb;
    private Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        ActualSpeed = DefaultSpeed;
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

        m_MoveX = t_InputX * ActualSpeed;
        m_MoveY = t_InputY * ActualSpeed;

        if (Mathf.Abs(t_InputX) >= Mathf.Abs(t_InputY))
        {
            m_Animator.SetFloat("Speed", Mathf.Abs(m_MoveX));
        }
        else
        {
            m_Animator.SetFloat("Speed", Mathf.Abs(m_MoveY));
        }

        if (Input.GetKey(KeyCode.Mouse0) && !AttackEnCd)
        {
            m_Animator.Play("Attack");
            GestionCdAttack();
        }

        if (Input.GetKey(KeyCode.Mouse1) && !DashEnCd)
        {
            Boost();
            Invoke("StopBoost", 0.3f);
            GestionCdDash();
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

    private void GestionCdAttack()
    {
        AttackEnCd = true;
        Invoke("CdDispoAttack", CdAttack);
    }
    private void CdDispoAttack()
    {
        AttackEnCd = false;
    }

    private void Boost()
    {
        ActualSpeed = BoostSpeed;
    }

    private void StopBoost()
    {
        ActualSpeed = DefaultSpeed;
    }

    private void GestionCdDash()
    {
        DashEnCd = true;
        Invoke("CdDispo", CdDash);
        Invoke("CdDispoDash", CdDash);
    }

    private void CdDispoDash()
    {
        DashEnCd = false;
    }
}
