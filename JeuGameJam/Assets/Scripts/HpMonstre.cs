using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpMonstre : MonoBehaviour
{
    public int Hp = 1;
    public Animator animator;
    [SerializeField] private LayerMask KillLayers;

    private bool Died;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Died = false;
    }

    private void Update()
    {
        if (Hp == 0 && !Died)
        {
            Died = true;
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("sword"))
        //if (KillLayers == (KillLayers | 1 << collision.gameObject.layer))
        {
            collision.gameObject.GetComponent<GestionPts>().PtsKills += 1;

            Hp--;
        }
    }

    private void Die()
    {
        animator.SetTrigger("IsDead");
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void KillMonster()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
