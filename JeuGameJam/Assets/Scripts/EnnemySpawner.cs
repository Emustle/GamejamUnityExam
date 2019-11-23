using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{
    public GameObject PREFAB_Ennemy;
    public Tuile TargetTuile;


    private void Awake()
    {
        if(PREFAB_Ennemy.GetComponent<EnnemyController>() == null)
        {
            Debug.LogError("EnnemySpawner is spawning an object without an EnnemyController.");
            gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        InvokeRepeating("Spawn", 2f, 2f);
    }

    private void Spawn()
    {
        GameObject t_Ennemy = Instantiate(PREFAB_Ennemy);
        EnnemyController t_EnnemyController = t_Ennemy.GetComponent<EnnemyController>();

        //TODO Pour le moment, on a juste une grille, donc un Pathfinder, donc ça marche.
        Pathfinder t_Pf = FindObjectOfType<Pathfinder>();
        t_EnnemyController.Path = t_Pf.GetPath(this.transform, TargetTuile, false);
    }
}
