using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelImageClick : MonoBehaviour
{
    
    public void ImageClickRecieve(int associatedIndex)
    {
        GameObject startButton = GameObject.Find("StartButton");
        startButton.GetComponent<LevelChange>().levelIndex = associatedIndex;
    }
}
