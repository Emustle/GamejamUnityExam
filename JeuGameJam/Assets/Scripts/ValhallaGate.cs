using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ValhallaGate : MonoBehaviour
{
    private int m_MaxPoints = 2;
    [SerializeField] private GameObject m_Message;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HeroControllers>() != null && PlayerStats.Points >= m_MaxPoints)
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("CreditsFin");
        }
        else
        {
            Instantiate(m_Message);
        }
    }
}
