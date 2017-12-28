using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public float timeScale = 1.0f; // 1 = 1 day/sec, 4 = 4 day/sec

    // Use this for initalization
    void Start()
    {
        instance = this;
    }
}
