using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private int m_Timer;
    private int m_LastTimer;

    private void Start()
    {
        m_LastTimer = 0;
    }
    void Update()
    {
        m_Timer = (int)Time.timeSinceLevelLoad + m_LastTimer;
        GetComponent<Text>().text = m_Timer.ToString();
    }

    private void OnLevelWasLoaded(int level)
    {
        m_LastTimer = m_Timer;
    }
}
