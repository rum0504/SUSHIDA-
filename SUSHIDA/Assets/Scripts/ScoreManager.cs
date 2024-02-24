using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0; // スコア
    public static ScoreManager instance;

    public void AddCorrectScore()
    {
        // 問題を間違えずに打った場合のスコアを加算
        score += 200;
    }

    public void AddPartialCorrectScore()
    {
        // 問題を間違えたが最後まで打ち終えた場合のスコアを加算
        score += 100;
    }

    public int GetScore()
    {
        // 現在のスコアを取得
        return score;
    }

    void Awake()
    {
        // ScoreManagerのインスタンスが存在しない場合
        if (instance == null)
        {
            // このインスタンスをScoreManagerのインスタンスに設定する
            instance = this;
        }
        else
        {
            // 既にScoreManagerのインスタンスがある場合は、このインスタンスを破棄する
            Destroy(gameObject);
        }
    }

    // スコアを初期化するメソッド
    public void ResetScore()
    {
        score = 0;
    }

    // スコアを加算するメソッド
    public void AddScore(int amount)
    {
        score += amount;
    }


}
