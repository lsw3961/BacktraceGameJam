using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThemeMusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameMusic");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "TitleScreen" || SceneManager.GetActiveScene().name == "LosingScreen")
        {
            Destroy(this.gameObject);
        }
    }
}