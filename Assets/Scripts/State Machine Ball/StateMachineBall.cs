﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineBall : MonoBehaviour
{
    public MonoBehaviour setState;
    public MonoBehaviour atackState;
    public MonoBehaviour hitState;
    public MonoBehaviour reboundState;
    public MonoBehaviour defenseState;
    public MonoBehaviour initialState;
    private MonoBehaviour actualState;

    // Start is called before the first frame update
    void Start()
    {
        actualState = initialState;
        ActivateState(initialState);
    }
    public void ActivateState(MonoBehaviour newState)
    {
        if (actualState != null) 
        {
            actualState.enabled = false;
            actualState = newState;
            actualState.enabled = true; 
        }
    }
}
