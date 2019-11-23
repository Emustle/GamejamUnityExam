using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionPts : MonoBehaviour
{
    public int PtsVies;
    public int PtsKills;
    public LayerMask HurtLayers;
    public LayerMask KillLayers;

    private void Update()
    {
        if (PtsVies == 0)
        {
            Die();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (HurtLayers == (HurtLayers | 1 << collision.gameObject.layer))
        {
            PtsVies--;
        }

        if (KillLayers == (KillLayers | 1 << collision.gameObject.layer))
        {
            PtsKills++;
            collision.collider.gameObject.GetComponent<HpMonstre>().Hp--;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
