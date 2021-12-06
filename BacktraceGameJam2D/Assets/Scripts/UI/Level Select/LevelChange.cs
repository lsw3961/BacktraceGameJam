using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public int levelIndex;
    public void LevelSwitch()
    {
        SceneManager.LoadSceneAsync(levelIndex);
    }
}
