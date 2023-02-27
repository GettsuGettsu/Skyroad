using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollisionContoller : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            StatsController.CheckRecord();
            GameObjectsHelper.FindInactiveObjectByTag("GameOver").SetActive(true);
        }
    }
}
