using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBack : MonoBehaviour
{
    public void LoadDefault()
    {
        SceneManager.LoadScene("InterfaceDefault");
    }
}
