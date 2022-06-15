using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/NextFloors", order = 1)]
public class NextFloors : ScriptableObject
{
    public GameObject[] nextFloors;
}
