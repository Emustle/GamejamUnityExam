using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOption : MonoBehaviour
{
    public void LoadOption()
    {
        SceneManager.LoadScene("InterfaceOption");
    }
}
