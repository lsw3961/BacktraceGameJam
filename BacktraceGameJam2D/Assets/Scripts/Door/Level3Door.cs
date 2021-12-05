using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3Door : MonoBehaviour
{
    [SerializeField] string namePassword = "abcd";
    PlayerInfo info;
    // Start is called before the first frame update
    void Start()
    {
        info = this.GetComponent<InfoHolder>().Information;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.localScale != new Vector3(int.Parse(info.values[4]), int.Parse(info.values[4]), 1))
            this.transform.localScale = new Vector3(int.Parse(info.values[4]), int.Parse(info.values[4]), 1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.GetComponent<InfoHolder>().Information.values[0].Trim().ToLower().ToString().Equals(namePassword.Trim().ToString())) 
        {
            if (bool.Parse(info.values[1])) 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
