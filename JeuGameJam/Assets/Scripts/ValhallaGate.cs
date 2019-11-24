using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ValhallaGate : MonoBehaviour
{
    private int m_MaxPoints = 50;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HeroControllers>() != null && PlayerStats.Points >= m_MaxPoints)
        {
            collision.gameObject.GetComponent<GestionVie>().Die();
            SceneManager.LoadScene("Credits");
        }
    }
}
