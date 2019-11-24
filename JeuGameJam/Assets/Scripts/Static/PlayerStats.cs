using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    public static int DEBUT_VIE = 25;
    public static int DEBUT_POINTS = 0;

    private static int m_Vies = DEBUT_VIE, m_Points = DEBUT_POINTS;

    public static int Vies
    {
        get
        {
            return m_Vies;
        }
        set
        {
            m_Vies = value;
        }
    }

    public static int Points
    {
        get
        {
            return m_Points;
        }
        set
        {
            m_Points = value;
        }
    }
}
