﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Invoke("InitialLogo", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame ()
    {
        SceneManager.LoadScene(1);
    }
    void InitialLogo()
    {

    } 
}
