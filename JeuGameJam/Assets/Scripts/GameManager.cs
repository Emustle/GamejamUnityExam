using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public BoardManager boardScript;

    private List<GameObject> m_WarpLists;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        boardScript = GetComponent<BoardManager>();
        if(boardScript != null)
            InitGame();

        if(SceneManager.GetActiveScene().name == "Hub")
        {
            m_WarpLists = new List<GameObject>();
            GameObject[] t_AllWarps = GameObject.FindGameObjectsWithTag("Warp");
            foreach(GameObject item in t_AllWarps)
            {
                m_WarpLists.Add(item);
            }
        }
    }

    private void InitGame()
    {
        boardScript.SetupScene();
    }

    public void LoadLevel(GameObject warpTriggered)
    {
        switch(warpTriggered.name)
        {
            case "Grotte":
                SceneManager.LoadScene("FirstLevel");
                break;
            case "Lava":
                SceneManager.LoadScene("SecondLevel");
                break;
            case "Water":
                Debug.LogError("SCENE NOT AVAILABLE YET !");
                //SceneManager.LoadScene("FirstLevel");
                break;
            case "Random":
                SceneManager.LoadScene("RandomLevel");
                break;
            default:
                break;
        }
    }
}
