using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorekeeper : MonoBehaviour
{
    private int score;

    public int GetScore()
    {
        return score;
    }
    public void ChangeScore(int num)
    {
        score += num;
        Mathf.Clamp(score, 0, int.MaxValue);
    }
    public void ResetScore()
    {
        score = 0;
    }
}
