using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float gameDuration = 30f; // ゲームの制限時間（秒）
    public Text timerText; // 制限時間を表示するテキスト
    public GameObject gameOverPanel; // ゲームオーバー時に表示するパネル
    public Text finalScoreText; // 最終スコアを表示するテキスト

    private float remainingTime; // 残り時間
    private int finalScore; // 最終スコア
    private bool isGameRunning = false; // ゲームが実行中かどうか

    public static GameManager instance;

    void Start()
    {
        // ゲームを開始
        StartGame();
    }

    void Update()
    {
        // ゲームが実行中であれば時間を減らす
        if (isGameRunning)
        {
            remainingTime -= Time.deltaTime;

            // タイマーテキストを更新
            timerText.text = "残り " + remainingTime.ToString("F0") + " 秒";

            // ゲームの残り時間が0以下になったらゲームオーバー
            if (remainingTime <= 0f)
            {
                GameOver();
            }
        }
    }

    void Awake()
    {
        // GameManagerのインスタンスが存在しない場合
        if (instance == null)
        {
            // このインスタンスをGameManagerのインスタンスに設定する
            instance = this;
        }
        else
        {
            // 既にGameManagerのインスタンスがある場合は、このインスタンスを破棄する
            Destroy(gameObject);
        }
    }

    // ゲームを開始する
    void StartGame()
    {
        // 制限時間を設定
        remainingTime = gameDuration;
        isGameRunning = true;
    }

    // ゲームオーバー処理
    void GameOver()
    {
        // 最終スコアを設定
        finalScore = ScoreManager.instance.GetScore();
        Debug.Log("Final Score: " + finalScore);

        // ゲームオーバーパネルを表示し、最終スコアを表示する
        gameOverPanel.SetActive(true);
        finalScoreText.text = "食べた金額: " + finalScore.ToString() + "円";
    }
}
