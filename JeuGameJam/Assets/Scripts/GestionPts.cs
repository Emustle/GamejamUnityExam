using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionPts : MonoBehaviour
{
    public int PtsVies;
    public int PtsKills;
    public LayerMask HurtLayers;
    private float m_ImmuneTime = 1f;
    private float m_LastHitTime;

    private void Start()
    {
        m_LastHitTime = -m_ImmuneTime;
    }

    private void Update()
    {
        if (PtsVies <= 0)
        {
            Die();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (m_LastHitTime + m_ImmuneTime > Time.time)
        {
            return;
        }

        //Si on est touché par l'ennemi
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("enemy"))
        //if (HurtLayers == (HurtLayers | 1 << collision.gameObject.layer))
        {
            PtsVies--;
            m_LastHitTime = Time.time;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
