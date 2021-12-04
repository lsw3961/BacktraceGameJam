using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerInfo ObjectInformation;
    [SerializeField] LayerMask notHitableLayers;
    GameObject currentObject;
    [SerializeField]
    GameObject prefabParent;
    [SerializeField]
    GameObject stringPrefab;
    [SerializeField]
    GameObject intPrefab;
    [SerializeField]
    GameObject boolPrefab;

    bool createPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        createPrefabs = false;
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
               // Debug.Log("has info");
                ObjectInformation = currentObject.GetComponent<InfoHolder>().Information;
                //Debug.Log("Create Prefabs outside of if "+createPrefabs);
                if (createPrefabs) 
                {
                    //Debug.Log("fire Once");
                    CreatePrefabs();
                    createPrefabs = false;
                    //Debug.Log("Create Prefabs inside of if "+createPrefabs);
                }

                //instatiate a new prefab for each name we have
            }
            //else
                //Debug.Log("no Info");
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
                //Debug.Log(hit.collider.gameObject);
                currentObject = hit.collider.gameObject;
                createPrefabs = true;
                return;
            }
        }
    }

    public void CreatePrefabs() 
    {
        //Debug.Log(ObjectInformation.values.Count);
        int nameCounter = 0;
            for (int i = 0; i < ObjectInformation.values.Count; i++)
            {
                if (ObjectInformation.values[i].ToUpper() == "TRUE" || ObjectInformation.values[i].ToUpper() == "FALSE")
                {
                    GameObject child = Instantiate(boolPrefab, prefabParent.transform);
                    child.transform.parent = prefabParent.transform;
                    //set the name of the boolean
                    child.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = ObjectInformation.names[nameCounter];
                    //set the toggle according to the cases
                    if (ObjectInformation.values[i].ToUpper() == "TRUE")
                    {
                        child.transform.GetChild(1).gameObject.GetComponent<Toggle>().isOn = true;
                    }
                    else
                    {
                        child.transform.GetChild(1).gameObject.GetComponent<Toggle>().isOn = false;
                    }

                }
                else if (int.TryParse(ObjectInformation.values[i], out int result))
                {
                    //instantiates the UI prfab
                    GameObject child = Instantiate(intPrefab, prefabParent.transform);
                    child.transform.parent = prefabParent.transform;
                    //set the text for the prefab
                    //Debug.Log(i);
                    child.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = ObjectInformation.names[nameCounter];
                    //set the min, max, and current for the prefab
                    child.GetComponentInChildren<Slider>().value = result;
                    child.GetComponentInChildren<Slider>().maxValue = int.Parse(ObjectInformation.values[i + 1]);
                    child.GetComponentInChildren<Slider>().minValue = 0;
                    //bounce i up an additional space to account for the double values
                    i++;
                }
                else
                {
                    GameObject child = Instantiate(stringPrefab, prefabParent.transform);
                    child.transform.parent = prefabParent.transform;
                    //set the name of the prefab
                    child.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = ObjectInformation.names[nameCounter];
                    //gets the child of the child of child, and sets the placeholder text for that equal to the current value
                    child.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.GetComponent<TMP_Text>().text = ObjectInformation.values[i];
                }
            nameCounter++;

            }
        
       // Debug.Log("outside of for loop");
            
    }
}
