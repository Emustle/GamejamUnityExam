using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{
    public void LoadHub()
    {
        PlayerStats.Vies = PlayerStats.DEBUT_VIE;
        PlayerStats.Points = PlayerStats.DEBUT_POINTS;
        SceneManager.LoadScene("Hub");
    }
}
