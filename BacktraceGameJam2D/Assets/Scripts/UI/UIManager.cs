using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerInfo ObjectInformation;
    GameObject currentObject;
    [SerializeField]
    GameObject panel;
    [SerializeField]
    GameObject prefabParent;
    [SerializeField]
    GameObject stringPrefab;
    [SerializeField]
    GameObject intPrefab;
    [SerializeField]
    GameObject boolPrefab;
    List<GameObject> prefabs = new List<GameObject>();


    [SerializeField]
    Vector3 prefabDistance;
    [SerializeField]
    Vector3 prefabScale;

    bool createPrefabs;
    bool updateInfo;
    // Start is called before the first frame update
    void Start()
    {
        createPrefabs = false;
        panel.SetActive(false);
        updateInfo = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (updateInfo)
        {
            UpdateInformation();
        }
        //check what the player has selected as the current object
        ObjectSelect();
        if (currentObject != null)
        {
            //check if that object has an object information
            if (currentObject.GetComponent<InfoHolder>())
            {
                // Debug.Log("has info");
                ObjectInformation = currentObject.GetComponent<InfoHolder>().Information;
                //Debug.Log("Create Prefabs outside of if "+createPrefabs);
                if (createPrefabs)
                {
                    //Debug.Log("fire Once");
                    //instatiate a new prefab for each name we have
                    CreatePrefabs();
                    createPrefabs = false;
                    //Debug.Log("Create Prefabs inside of if "+createPrefabs);
                }
                //update the information in the scriptable object
                updateInfo = true;

            }
            //else
            //Debug.Log("no Info");
            //parse the list of values over from the scriptable object
        }
        else 
        {
            CleanUp();

        }


    }
    public void ObjectSelect()
    {
        if (Input.GetMouseButtonDown(0) && !IsMouseOverUI())
        {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (currentObject != null)
            {
                CleanUp();

            }

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == currentObject)
                {
                    panel.SetActive(false);
                    currentObject = null;
                    createPrefabs = false;
                    return;
                }
                //Debug.Log(hit.collider.gameObject);
                panel.SetActive(true);
                currentObject = hit.collider.gameObject;
                createPrefabs = true;
                return;
            }
            else
            {
                panel.SetActive(false);
                currentObject = null;
            }
        }
    }
    private void CleanUp() 
    {
        updateInfo = false;
        if (prefabs != null)
        {
            if (prefabs.Count > 0)
            {
                for (int i = 0; i < prefabs.Count; i++)
                {
                    Destroy(prefabs[i]);
                    prefabs.RemoveAt(i);
                    ObjectInformation = null;
                    prefabParent.transform.DetachChildren();
                }
            }
        }
    }
    public void CreatePrefabs() 
    {
        //Debug.Log(ObjectInformation.values.Count);

        if (prefabs.Count >0) 
        {
            return;
        }

        int nameCounter = 0;
            for (int i = 0; i < ObjectInformation.values.Count; i++)
            {
                if (ObjectInformation.values[i].ToUpper() == "TRUE" || ObjectInformation.values[i].ToUpper() == "FALSE")
                {
                    GameObject child = Instantiate(boolPrefab, prefabParent.transform);
                    prefabs.Add(child);
                    child.transform.parent = prefabParent.transform;
                    child.transform.localScale = prefabScale;
                    child.transform.localPosition = new Vector3(0, prefabParent.transform.position.y + (nameCounter*prefabDistance.y),child.transform.position.z);
    
                    //set the tag of each type
                    child.tag = "Bool";
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
                    prefabs.Add(child);
                    //set the text for the prefab
                    child.transform.localScale = prefabScale;
                    child.transform.localPosition = new Vector3(0, prefabParent.transform.position.y + (nameCounter * prefabDistance.y), child.transform.position.z);
                    //set the tag
                    child.tag = "Int";
                    //Debug.Log(i);
                    child.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = ObjectInformation.names[nameCounter];
                    //set the min, max, and current for the prefab
                    child.GetComponentInChildren<Slider>().value = result;
                    child.GetComponentInChildren<Slider>().maxValue = int.Parse(ObjectInformation.values[i + 1]);
                    child.GetComponentInChildren<Slider>().minValue = -5;
                    //bounce i up an additional space to account for the double values
                    i++;
                }
                else
                {
                    GameObject child = Instantiate(stringPrefab, prefabParent.transform);
                    child.transform.parent = prefabParent.transform;
                    //set the tag
                    prefabs.Add(child);
                    child.transform.localScale = prefabScale;
                    child.transform.localPosition = new Vector3(0, prefabParent.transform.position.y + (nameCounter * prefabDistance.y), child.transform.position.z);
                    child.tag = "String";
                    //set the name of the prefab
                    child.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = ObjectInformation.names[nameCounter];
                    //gets the child of the child of child, and sets the placeholder text for that equal to the current value
                    child.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.GetComponent<TMP_Text>().text = ObjectInformation.values[i];
                child.transform.GetChild(1).GetChild(0).GetChild(2).gameObject.GetComponent<TMP_Text>().text = ObjectInformation.values[i];
            }
            nameCounter++;

            }

        // Debug.Log("outside of for loop");
        float height = Mathf.Abs((prefabs[0].transform.position.y) - (prefabs[prefabs.Count - 1].transform.position.y - prefabs.Count*prefabDistance.y));
        prefabParent.GetComponent<RectTransform>().sizeDelta = new Vector2(prefabParent.GetComponent<RectTransform>().sizeDelta.x,height*2); 

    }
    public void UpdateInformation() 
    {
        int valueCounter = 0;
        for (int i = 0; i < prefabParent.transform.childCount; i++)
        {
            GameObject child = prefabParent.transform.GetChild(i).gameObject;
            if (child.tag == "Bool")
            {
                //set the name of the boolean
                ObjectInformation.names[i] = child.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text;
                //read in toggle 
                //Debug.Log("Name: "+ ObjectInformation.names[i]);
                if (child.transform.GetChild(1).gameObject.GetComponent<Toggle>().isOn)
                {
                    ObjectInformation.values[valueCounter] = "TRUE";
                }
                else
                {
                    ObjectInformation.values[valueCounter] = "FALSE";
                }
            }
            else if (child.gameObject.tag == "Int")
            {
                 ObjectInformation.names[i] = child.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text;
                //set the max and the current for the prefab
                ObjectInformation.values[valueCounter] = child.GetComponentInChildren<Slider>().value.ToString();
                ObjectInformation.values[valueCounter+1] = child.GetComponentInChildren<Slider>().maxValue.ToString();
                //increase value counter to stay in line with name
                valueCounter++;


            }
            else if(child.tag == "String")
            {
                 ObjectInformation.names[i] = child.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text;

                //Debug.Log(child.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.GetComponent<TMP_Text>().text);
                if (child.transform.GetChild(1).GetChild(0).GetChild(2).gameObject.GetComponent<TMP_Text>().text == null)
                {
                    Debug.Log("Hit");
                    child.transform.GetChild(1).GetChild(0).GetChild(2).gameObject.GetComponent<TMP_Text>().text = child.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.GetComponent<TMP_Text>().text;
                }
                ObjectInformation.values[valueCounter] = child.transform.GetChild(1).GetChild(0).GetChild(2).gameObject.GetComponent<TMP_Text>().text;
            }
            valueCounter++;
        }
    }
    private bool IsMouseOverUI() 
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
