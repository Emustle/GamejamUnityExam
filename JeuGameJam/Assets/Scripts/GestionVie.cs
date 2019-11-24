using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestionVie : MonoBehaviour
{
    public LayerMask HurtLayers;
    private float m_ImmuneTime = 1f;
    private float m_LastHitTime;

    public Text viesUI;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        m_LastHitTime = -m_ImmuneTime;

        viesUI.text = PlayerStats.Vies.ToString();

    }

    private void Update()
    {
        if (PlayerStats.Vies <= 0)
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
            PlayerStats.Vies--;
            viesUI.text = PlayerStats.Vies.ToString();

            m_LastHitTime = Time.time;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        PlayerStats.Vies = PlayerStats.DEBUT_VIE;
        PlayerStats.Points = PlayerStats.DEBUT_POINTS;
        SceneManager.LoadScene("InterfaceDie");
    }
}
