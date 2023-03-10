using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentFollowController : MonoBehaviour
{
    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;
        transform.position = new Vector3(0, 0, player.position.z);
    }
}
