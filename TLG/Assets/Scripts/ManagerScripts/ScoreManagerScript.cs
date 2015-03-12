using UnityEngine;
using System.Collections;

public class ScoreManagerScript : MonoBehaviour
{
    private float totalScore;
    private float roundsSurvived;
    private float enemiesVanquished;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void CalculateTotalScore(float enemyScore, float currentRoundNumber = 1)
    {
        totalScore += enemyScore * currentRoundNumber;
    }

    public void SurvivedRound(float roundNumber)
    {
        roundsSurvived = roundNumber;
    }

    public void EnemyIsVanquished()
    {
        enemiesVanquished++;
    }


    #region Accessors

    public float TotalScore
    {
        get { return totalScore; }
        set { totalScore = value; }
    }

    public float RoundsSurvived
    {
        get { return roundsSurvived; }
        set { roundsSurvived = value; }
    }

    public float EnemiesVanquished
    {
        get { return enemiesVanquished; }
        set { enemiesVanquished = value; }
    }

    #endregion
}
