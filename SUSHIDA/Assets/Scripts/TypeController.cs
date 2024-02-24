// TypeController.cs
using UnityEngine;
using UnityEngine.UI;

public class TypeController : MonoBehaviour
{
    public Text romajiUIText; // 問題のローマ字表示テキスト
    public WordController wordController; // WordControllerの参照
    public Text scoreText; // スコアを表示するテキスト
    private ScoreManager scoreManager; // ScoreManagerの参照
    public int finalScore = 0; // 最終スコア

    private string romajiText; // 問題のローマ字文
    public int indexOfString = 0; // 問題の何文字目か

    void Start()
    {
        // インスペクターで設定されたローマ字テキストを取得
        romajiText = romajiUIText.text;

        // ScoreManagerコンポーネントを取得
        scoreManager = FindObjectOfType<ScoreManager>(); // シーン内のScoreManagerを検索して取得する
    }

    void Update()
    {
        // キーボードからの入力を受け付ける
        if (Input.anyKeyDown)
        {
            CheckInput();
        }
    }

    void CheckInput()
    {
        string inputKey = Input.inputString;

        // キーボードから打った文字が正解かどうかを確認
        if (indexOfString < romajiText.Length && inputKey == romajiText[indexOfString].ToString())
        {
            // 正解時の処理
            Correct();
            indexOfString++;

            // 問題を入力し終えたら次の問題を表示
            if (indexOfString >= romajiText.Length)
            {
                wordController.GenerateNextQuestion();
                indexOfString = 0; // インデックスをリセット

                // 問題を間違えずに打った場合のスコアを加算
                scoreManager.AddCorrectScore();

                // スコアを更新
                UpdateScoreText();
            }
        }
        else
        {
            // 失敗時の処理
            Mistake(inputKey);
        }
    }

    void Correct()
    {
        // 正解時の処理を記述
        romajiUIText.text = ColorText(romajiText, indexOfString, Color.green);
    }

    void Mistake(string inputKey)
    {
        // 失敗時の処理を記述
        romajiUIText.text = ColorText(romajiText, indexOfString, Color.red);

        // 問題を間違えたが最後まで打ち終えた場合のスコアを加算
        scoreManager.AddPartialCorrectScore();

        // スコアを更新
        UpdateScoreText();
    }

    string ColorText(string text, int index, Color color)
    {
        // 指定されたインデックスの文字を指定された色に変更して返す
        string coloredText = "";
        for (int i = 0; i < text.Length; i++)
        {
            if (i == index)
            {
                coloredText += "<color=#" + ColorUtility.ToHtmlStringRGB(color) + ">" + text[i] + "</color>";
            }
            else
            {
                coloredText += text[i];
            }
        }
        return coloredText;
    }

    public void SetRomajiText(string text)
    {
        romajiText = text;
        indexOfString = 0; // インデックスをリセット
    }

    void UpdateScoreText()
    {
        // スコアを表示するテキストを更新
        scoreText.text = "スコア: " + scoreManager.GetScore().ToString() + "円";
        finalScore = scoreManager.GetScore(); // 最終的なスコアを更新
    }

    public int GetFinalScore()
    {
        return finalScore; // 最終的なスコアを取得
    }
}
