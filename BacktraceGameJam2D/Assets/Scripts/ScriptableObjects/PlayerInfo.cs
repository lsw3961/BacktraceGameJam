using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerInfo", menuName = "ScriptableObjects/Player", order = 1)]
public class PlayerInfo : ScriptableObject
{
    //list of names for each of the modifiable values
    public List<string> names;
    //list of the values for each of the modifiable values
    public List<string> values;
}
