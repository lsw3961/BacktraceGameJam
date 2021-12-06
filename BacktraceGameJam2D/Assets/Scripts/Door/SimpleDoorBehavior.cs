using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SimpleDoorBehavior : MonoBehaviour
{
    [SerializeField]
    PlayerInfo doorInfo;
    [SerializeField]
    string isOpenVaraibleName = "isOpen";
    private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 0; i < doorInfo.names.Count; i++)
        {
            if (doorInfo.names[i] == isOpenVaraibleName) 
            {
                if (doorInfo.values[i] == "TRUE") 
                {
                    if (collision.gameObject.tag == "Player") 
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }

                }

            }
        }
    }
}
