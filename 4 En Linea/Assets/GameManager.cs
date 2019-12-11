using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject[,] grid;

    [SerializeField]
    private int height = 10;
    private float y;
    [SerializeField]
    private int width = 10;
    private float x;
    private bool turn;
    private int _x;
    private int _y;
    bool ganador;
    
    // Start is called before the first frame update
    private void Start()
    {
        Setup();
    }
    private void Setup()
    {
        grid = new GameObject[width, height];
        for (var y = 0; y < height; y++)
        {
            for(var x =0; x <width; x++)
            {
                var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Vector3 position = new Vector3(x, y, 0);
                go.transform.position = position;
                grid[x, y] = go;
                
            }
        }
    }
   
    // Update is called once per frame
    private void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (!(mousePosition.x >= -0.5f) || (mousePosition.x < width - 0.5f) || !(mousePosition.y >= -0.5f) || (mousePosition.y < height - 0.5f)) ;
        var x = (int)(mousePosition.x + 0.5f);
        var y = (int)(mousePosition.y + 0.5f);
        

        Debug.DrawLine(Vector3.zero, mousePosition);

        //Recorre toda la matriz de las esferas y pregunta si es rojo, si es así, la pinta en blanco.
        for (int _x = 0; _x<width; _x++)
        {
            for (int _y = 0; _y < height; _y++)
            {
                if (grid[_x, _y].GetComponent<Renderer>().material.color == Color.red)

                {
                    grid[_x, _y].GetComponent<Renderer>().material.color = Color.white;
                }
            }
        }
        if(x>=0 && y>=0 && x<width && y<height)//Permite que la posición del mouse se encuentre dentro de los parametros de la matriz, y no seleccione o pregunte por un valor fuera de esta.
        {
            GameObject go = grid[x, y];//Es la esfera que se está seleccionando 

            if (go.GetComponent<Renderer>().material.color == Color.white)//La esfera blanca que estoy seleccionando
            {
                go.GetComponent<Renderer>().material.color = Color.red;//La esfera que estoy seleccionando me pinte a rojo
            }

            if(Input.GetMouseButtonDown(0))//Si presiono el botón izquierdo del mouse
            {
               if (go.GetComponent<Renderer>().material.color == Color.red)
                {
                    

                    turn = !turn;//Turnos para pintar las esferas
                    if (turn)
                    {
                        grid[x, y].GetComponent<Renderer>().material.color = Color.green;

                        VerificadorX(x, y, Color.green);
                        VerificadorY(x, y, Color.green);
                        DiagoPositiva(x, y, Color.green);
                        DiagoNegativa(x, y, Color.green);
                    }
                    else
                    {
                        grid[x, y].GetComponent<Renderer>().material.color = Color.blue;

                        VerificadorX(x, y, Color.blue);
                        VerificadorY(x, y, Color.blue);
                        DiagoPositiva(x, y, Color.blue);
                        DiagoNegativa(x, y, Color.blue);

                       
                    }


                }
              

            }
           
        }

        if (Input.GetMouseButtonDown(0) && ganador == false)
        {
           
        }


    }
    private void PickAPiece(int x, int y)
    {
        
    }
    
    public void VerificadorX(int x, int y, Color colorVerificar)
    {
        int contador = 0;
        for (int i = x-3; i<=x+3;i++)
        {
            if(i<0 || i>=width)
            {
                continue;
            }

            GameObject go = grid[i, y];

            if (go.GetComponent<Renderer>().material.color == colorVerificar)
            {
                contador++;
                if (contador == 4 && colorVerificar == Color.green)
                {
                    Debug.Log("felicitaciones, ha ganado el jugador verde");
                    ganador = true;

                    
                }

                else if (contador == 4 && colorVerificar == Color.blue)
                {
                    Debug.Log("felicitaciones, ha ganado el jugador azul");
                    ganador = true;
                }
            }
            else
                contador = 0;
        }
    }

    public void VerificadorY(int x, int y, Color colorVerificar)
    {
        int contador = 0;
        for(int j = y-3; j<=y+3; j++)
        {
            if (j<0 || j>=height)
            {
                continue;
            }

            GameObject go = grid[x, j];

            if (go.GetComponent<Renderer>().material.color == colorVerificar)
            {
                contador++;
                if (contador == 4 && colorVerificar == Color.green)
                {
                    Debug.Log("felicitaciones, ha ganado el jugador verde");
                    ganador = true;
                }
                else if (contador == 4 && colorVerificar == Color.blue)
                {
                    Debug.Log("felicitaciones, ha ganado el jugador azul");
                    ganador = true;
                }
            }
            else
                contador = 0;
        }
    }
    public void DiagoPositiva(int x, int y, Color colorVerificar)
    {
        int contador = 0;
        int j = y - 4;

        for (int i = x - 3; i <= x + 3; i++)
        {
            j++;
            if (j < 0 || j >= height || i < 0 || i >= width)
            {
                continue;
            }

            GameObject go = grid[i, j];

            if (go.GetComponent<Renderer>().material.color == colorVerificar)
            {
                contador++;

                if (contador == 4 && colorVerificar == Color.green)
                {
                    Debug.Log("felicitaciones, ha ganado el jugador verde");
                    ganador = true;
                }

                else if (contador == 4 && colorVerificar == Color.blue)
                {
                    Debug.Log("felicitaciones, ha ganado el jugador azul");
                    ganador = true;

                }
            }
            else
            contador = 0;
        }
        
    }
    public void DiagoNegativa (int x, int y, Color colorVerificar)
    {
        int contador = 0;
        int j = y + 4;

        for(int i = x - 3; i<= x + 3; i++)
        {
            j--;

            if(j < 0 || j >=height || i < 0 || i >= width)
            {
                continue;
            }

            GameObject go = grid[i, j];

            if (go.GetComponent<Renderer>().material.color == colorVerificar)
            {
                contador++;

                if (contador == 4 && colorVerificar == Color.green)
                {
                    Debug.Log("felicitaciones, ha ganado el jugador verde");
                    ganador = true;
                }

                else if (contador == 4 && colorVerificar == Color.blue)
                {
                    Debug.Log("felicitaciones, ha ganado el jugador azul");
                    ganador = true;
                }
            }
            else
            contador = 0;
        }
    }

    

}
