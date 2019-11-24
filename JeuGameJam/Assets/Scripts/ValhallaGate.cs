using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ValhallaGate : MonoBehaviour
{
    private int m_MaxPoints = 100;
    [SerializeField] private GameObject m_Message;
    private GameObject m_MessageCanvas;
    private bool m_IsMessageDisplayed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HeroControllers>() != null && PlayerStats.Points >= m_MaxPoints)
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("CreditsFin");
        }
        else if (!m_IsMessageDisplayed)
        {
            m_IsMessageDisplayed = true;
            m_MessageCanvas = Instantiate(m_Message);
            StartCoroutine("MessageTimeout", 2f);
        }
    }

    private IEnumerator MessageTimeout(float a_Wait)
    {
        yield return new WaitForSeconds(a_Wait);
        Destroy(m_MessageCanvas);
        StopCoroutine("MessageTimeout");
        m_IsMessageDisplayed = false;
    }
}
