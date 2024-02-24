// GameOverSceneScoreDisplay.cs
using UnityEngine;
using UnityEngine.UI;

public class GameOverSceneScoreDisplay : MonoBehaviour
{
    public Text scoreText; // �X�R�A��\������e�L�X�g

    void Start()
    {
        // TypeController����ŏI�X�R�A���擾���ĕ\��
        int score = FindObjectOfType<TypeController>().GetFinalScore();
        scoreText.text = "Score: " + score.ToString();
    }
}
