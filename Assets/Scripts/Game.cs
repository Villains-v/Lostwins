using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject chesspiece;


    // Positions and team for each chesspiece
    private GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] playerBlack = new GameObject[16];
    private GameObject[] playerWhite = new GameObject[16];

    private string currentPlayer = "white";

    private bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        // Functions (parameter1, parameter2)
        Instantiate(chesspiece, new Vector3(0,0,-1),Quaternion.identity);  
    }
}
