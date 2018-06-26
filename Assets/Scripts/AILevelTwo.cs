using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILevelTwo : AILevelOne
{
    protected override void Start()
    {

        toScore.Add("aa___", 100);// 眠二
        toScore.Add("a_a__", 100);
        toScore.Add("___aa", 100);
        toScore.Add("__a_a", 100);
        toScore.Add("a__a_", 100);
        toScore.Add("_a__a", 100);
        toScore.Add("a___a", 100);

        toScore.Add("__aa__", 500);//活二
        toScore.Add("_a_a_", 500);
        toScore.Add("_a__a_", 500);

        toScore.Add("_aa__", 500);
        toScore.Add("__aa_", 500);  

        toScore.Add("a_a_a", 1000);
        toScore.Add("aa__a", 1000);
        toScore.Add("_aa_a", 1000);
        toScore.Add("a_aa_", 1000);
        toScore.Add("_a_aa", 1000);
        toScore.Add("aa_a_", 1000);
        toScore.Add("aaa__", 1000); //活三

        toScore.Add("_aa_a_", 9000);
        toScore.Add("_a_aa_", 9000);//跳活三

        toScore.Add("_aaa_", 10000);//活三

        toScore.Add("a_aaa", 15000);//冲四
        toScore.Add("aaa_a", 15000);
        toScore.Add("_aaaa", 15000);
        toScore.Add("aaaa_", 15000);
        toScore.Add("aa_aa", 15000);

        toScore.Add("_aaaa_", 1000000);//活四


        toScore.Add("aaaaa", float.MaxValue);//连五

    }

    public override void CheckOneLine(int[] pos,int[]offset,int chess)
    {
        bool lfirst = true, lstop = false, rstop = false;
        int AllNum = 1;
        string str = "a";
        int ri = offset[0], rj = offset[1];
        int li = -offset[0], lj = -offset[1];
        while(AllNum < 7 && (!lstop || !rstop ))
        {
            if(lfirst)
            {
                //左边
                if((pos[0] + li >= 0 && pos[0] + li < 15) && 
                    (pos[1] +lj >= 0 && pos[1] + lj < 15) && !lstop && !rstop)
                {
                    if(chess == ChessBoard.Instance.grid[pos[0] + li,pos[1] + lj] )
                    {
                        AllNum++;
                        str = "a" + str;
                    }
                    else if(0 == ChessBoard.Instance.grid[pos[0] + li, pos[1] + lj])
                    {
                        AllNum++;
                        str = "_" + str;
                        if (!rstop) lfirst = false;
                    }
                    else
                    {
                        lstop = true;
                        if (!rstop) lfirst = false;
                    }

                    li -= offset[0];lj -= offset[1];
                }
                else
                {
                    lstop = true;
                    if (!rstop) lfirst = false;
                }
            }
            else
            {
                //右边
                if ((pos[0] + ri >= 0 && pos[0] + ri < 15) &&
                    (pos[1] + rj >= 0 && pos[1] + rj < 15) && !lstop && !rstop)
                {
                    if (chess == ChessBoard.Instance.grid[pos[0] + ri, pos[1] + rj])
                    {
                        AllNum++;
                        str += "a";
                    }
                    else if (0 == ChessBoard.Instance.grid[pos[0] + ri, pos[1] + rj])
                    {
                        AllNum++;
                        str += "_";
                        if (!lstop) lfirst = true;
                    }
                    else
                    {
                        rstop = true;
                        if (!lstop) lfirst = true;
                    }

                    ri += offset[0]; rj += offset[1];
                }
                else
                {
                    rstop = true;
                    if (!lstop) lfirst = true;
                }
            }
        }


        string cmpstr = "";
        foreach (var keyInfo in toScore)
        {
            if(str.Contains(keyInfo.Key))
            {
                if(cmpstr != "")
                {
                    if(toScore[keyInfo.Key] > toScore[cmpstr])
                    {
                        cmpstr = keyInfo.Key;
                    }
                }
                else
                {
                    cmpstr = keyInfo.Key;
                }
            }
        }

        if(cmpstr != "")
        {
            score[pos[0], pos[1]] += toScore[cmpstr];
        }
    }

}
