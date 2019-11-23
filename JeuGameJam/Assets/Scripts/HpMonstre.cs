using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpMonstre : MonoBehaviour
{
    public int Hp = 1;
    public Animator animator;

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

    private void Die()
    {
        animator.SetTrigger("IsDead");
        
    }

    private void KillMonster()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
