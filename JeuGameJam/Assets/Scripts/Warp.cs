using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HeroControllers>() != null)
        {
            GameManager.instance.LoadLevel(gameObject);
        }
    }
}
