using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{
    public GameObject PREFAB_Ennemy;
    public int NbEnnemy;
    public float CoolDown;
    public float Delay;
    private int i;
    private bool EnCD;
    private void Start()
    {
    }

    private void Update()
    {
         if (i < NbEnnemy && !EnCD)
         {
            Invoke("Spawn", CoolDown);
            i++;
            GestionCdSpawn();
         }
    }

    private void GestionCdSpawn()
    {
        EnCD = true;
        Invoke("CdDispoSpawn", CoolDown);
    }
    private void CdDispoSpawn()
    {
        EnCD = false;
    }

    private void Spawn()
    {
        GameObject t_Ennemy = Instantiate(PREFAB_Ennemy, transform.position, Quaternion.identity);
    }
}
