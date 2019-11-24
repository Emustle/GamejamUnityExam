using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestionPoints : MonoBehaviour
{
    public Text pointsUI;

    private void Start()
    {
        pointsUI.text = PlayerStats.Points.ToString();

    }
}
