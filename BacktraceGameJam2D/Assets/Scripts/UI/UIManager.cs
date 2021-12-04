using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerInfo ObjectInformation;
    [SerializeField] LayerMask notHitableLayers;
    GameObject currentObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //check what the player has selected as the current object
        ObjectSelect();
        if (currentObject != null) {
            //check if that object has an object information
            if (currentObject.GetComponent<InfoHolder>())
            {
                Debug.Log("has info");

                //instatiate a new prefab for each name we have
            }
            else
                Debug.Log("no Info");
            //parse the list of values over from the scriptable object
        }

    }
    public void ObjectSelect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null )
            {
                Debug.Log(hit.collider.gameObject);
                currentObject = hit.collider.gameObject;
            }
        }
    }

    public void CreatePrefabs() 
    {
        for (int i = 0;i<ObjectInformation.names.Count;i++) 
        {
        
        }
    }
}
