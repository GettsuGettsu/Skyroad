using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
