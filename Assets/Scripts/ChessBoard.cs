using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChessType
{
    Watch,
    Black,
    White
}


public class ChessBoard : MonoBehaviour {

    private static ChessBoard _instance;
    public ChessType turn = ChessType.Black;
    public int[,] grid;
    public GameObject[] prefabs;
    public float timer = 0;
    public bool gameStart = true;
    Transform parent;

    public static ChessBoard Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if(Instance == null)
        {
            _instance = this;
        }
    }

    // Use this for initialization
    private void Start()
    {
        parent = GameObject.Find("Parent").transform;
        grid = new int[15, 15];
    }


    public bool PlayChess(int[] pos)
    {
        if (!gameStart) return false;

        pos[0] = Mathf.Clamp(pos[0],0,14);
        pos[1] = Mathf.Clamp(pos[1], 0, 14);

        if (grid[pos[0], pos[1]] != 0) return false;

        if(turn == ChessType.Black)
        {
            GameObject go = Instantiate(prefabs[0], new Vector3(pos[0] - 7, pos[1] - 7), Quaternion.identity);
            go.transform.SetParent(parent);
            grid[pos[0], pos[1]] = 1;
            //判断是否胜利
            if (CheckWinner(pos))
            {

            }

            turn = ChessType.White;

        }
        else if(turn == ChessType.White)
        {
            GameObject go = Instantiate(prefabs[1], new Vector3(pos[0] - 7, pos[1] - 7), Quaternion.identity);
            go.transform.SetParent(parent);
            grid[pos[0], pos[1]] = 2;
            //判断是否胜利
            if (CheckWinner(pos))
            {

            }

            turn = ChessType.Black;
        }

        return true;
    }

    public bool CheckWinner(int[] pos)
    {
        return false;
    }

	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
    }


}
