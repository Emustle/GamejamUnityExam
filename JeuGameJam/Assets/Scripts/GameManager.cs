using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public BoardManager boardScript;
    public GameObject astar;
    public GameObject hero;

    private Vector3 m_SpawnTile = new Vector3(7.5f, 21.5f, -1f);

    private List<GameObject> m_WarpLists;
    private GameObject m_AstarInstance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);

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

    private void Start()
    {
        //Instantiate(hero, GameObject.Find("Spawn").transform.position, Quaternion.identity);
        Instantiate(astar, transform.position, Quaternion.identity);
    }

    public void LoadLevel(GameObject warpTriggered)
    {
        switch (warpTriggered.name)
        {
            case "Grotte":
                SceneManager.LoadScene("FirstLevel", LoadSceneMode.Single);
                break;
            case "Lava":
                SceneManager.LoadScene("SecondLevel", LoadSceneMode.Single);
                break;
            case "Water":
                SceneManager.LoadScene("ThirdLevel", LoadSceneMode.Single);
                break;
            case "Random":
                SceneManager.LoadScene("RandomLevel", LoadSceneMode.Single);
                break;
            default:
                break;
        }

        GameObject.Find("sword_man").transform.position = m_SpawnTile;

    }
}
