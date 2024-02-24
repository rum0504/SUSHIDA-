// GameOverSceneScoreDisplay.cs
using UnityEngine;
using UnityEngine.UI;

public class GameOverSceneScoreDisplay : MonoBehaviour
{
    public Text scoreText; // スコアを表示するテキスト

    void Start()
    {
        // TypeControllerから最終スコアを取得して表示
        int score = FindObjectOfType<TypeController>().GetFinalScore();
        scoreText.text = "Score: " + score.ToString();
    }
}
