using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text LivesText;
    public Text ScoreText;
    public int livesToSetAtStart;
    public int Score;
    public int Lives;

    public static GameManager Instance = null;
    
    private void Awake(){
        if(Instance==null){
            Instance = this;
        }
    }
    private void Start(){
        setLives(livesToSetAtStart);
        setScore(0);
    }

    public void setLives(int lives){
        Lives = lives;
        LivesText.text = "Lives: "+Lives.ToString();
    }

    public void setScore(int score){
        Score = score;
        ScoreText.text = "Score: "+Score.ToString();
    }
}
