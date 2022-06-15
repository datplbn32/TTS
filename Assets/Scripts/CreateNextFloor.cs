using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreateNextFloor : MonoBehaviour
{
    private const int m_IndexRight = 7; //See in ScriptTableObject in prefabs
    private const int m_IndexLeft = 6;

    private int m_CountRight = 0; // Right++; Left--
    private int m_Count; //Map length, -- for next floor
    private bool isFirst = true; //This is first so random map length

    [SerializeField] private Transform m_Pivot; //The child object named NextFloor
    [SerializeField] private NextFloors m_NextFloors; //ScriptsTableObject save Floors

    private void Start()
    {
        //This is first? so random map length 30 to 80
        if (isFirst)
            m_Count = Random.Range(30, 81);

        //map length so good, instance Finish line
        if (m_Count == 0)
        {
            Instantiate(m_NextFloors.nextFloors[m_NextFloors.nextFloors.Length-1], m_Pivot.position, m_Pivot.rotation);
            return;
        }

        InstantiateNextFloor();
    }

    private void InstantiateNextFloor()
    {
        //Create index
        int index = GetRanDom();

        //Not turn right 3x time so the floor can cut other EG: -1 -> 0 -> 1
        while (index == m_IndexRight && !CanInsRight())
        {
            index = GetRanDom();
        }

        //Same with left
        while (index == m_IndexLeft && !CanInsLeft())
        {
            index = GetRanDom();
        }

        //If ins turn left m_IndexRight --
        //If ins turn right m_IndexRight ++
        if (index == m_IndexLeft)
        {
            m_CountRight--;
        }
        else if (index == m_IndexRight)
        {
            m_CountRight++;
        }

        //Give properties for next floor
        GameObject nextFloor = Instantiate(m_NextFloors.nextFloors[index], m_Pivot.position, m_Pivot.rotation);
        CreateNextFloor next = nextFloor.GetComponent<CreateNextFloor>();
        next.transform.parent = transform.parent;
        next.m_Count = m_Count - 1;
        next.isFirst = false;
        next.m_CountRight = m_CountRight;
    }

    private bool CanInsRight()
    {
        return m_CountRight < 1;
    }

    private bool CanInsLeft()
    {
        return m_CountRight > -1;
    }

    private int GetRanDom()
    {
        return Random.Range(0, m_NextFloors.nextFloors.Length - 1);
    }
}