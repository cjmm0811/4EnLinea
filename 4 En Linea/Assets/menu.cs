﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void Grid2D()
    {
        SceneManager.LoadScene(1);
    }
    public  void inicio()
    {
        SceneManager.LoadScene(0);
    }
    public  void terminarverde()
    {
        SceneManager.LoadScene(2);
    }
    public  void terminarazul()
    {
        SceneManager.LoadScene(3);
    }

    public void salir()
    {
        Application.Quit();
    }
  
 
    
}
