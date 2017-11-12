using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTarget : MonoBehaviour {

    [SerializeField] private int priority = 0;

    // Use this for initialization
    void Start () {

    }

    public int getPriority()
    {
        return priority;
    }

    public Transform getPosition()
    {
        return transform;
    }
}
