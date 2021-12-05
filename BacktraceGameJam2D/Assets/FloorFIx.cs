using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFIx : MonoBehaviour
{
    [SerializeField] PlayerInfo info;
    void Start()
    {
        info.values[0] = "TRUE";
    }

}
