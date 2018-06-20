using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    public ChessType chessColor = ChessType.Black;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if(chessColor == ChessBoard.Instance.turn && ChessBoard.Instance.timer > 0.3f)
        PlayChess();
    }

    public void PlayChess()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //print((int)(pos.x + 7.5f) + " " + (int)(pos.y + 7.5f));
            ChessBoard.Instance.PlayChess(new int[2] { (int)(pos.x + 7.5f), (int)(pos.y + 7.5f) });
            ChessBoard.Instance.timer = 0;
        }
    }
}
