using UnityEngine;
using UnityEngine.UI;

public class WordController : MonoBehaviour
{
    // 問題の日本語文
    public string[] japaneseTexts;
    // 問題のローマ字文
    public string[] romajiTexts;
    // 日本語表示テキスト
    public Text japaneseUIText;
    // ローマ字表示テキスト
    public Text romajiUIText;

    // TypeControllerへの参照
    public TypeController typeController;

    private void Start()
    {
        GenerateNextQuestion();
    }

    // 次の問題を生成し、表示する
    public void GenerateNextQuestion()
    {
        // 日本語テキストとローマ字テキストの配列が空でないことを確認
        if (japaneseTexts != null && romajiTexts != null && japaneseTexts.Length > 0 && romajiTexts.Length > 0)
        {
            // 問題数内でランダムに選ぶ
            int numberOfQuestion = Random.Range(0, japaneseTexts.Length);

            // 選択した問題をテキストUIにセット
            string selectedJapaneseText = japaneseTexts[numberOfQuestion];
            string selectedRomajiText = romajiTexts[numberOfQuestion];
            japaneseUIText.text = selectedJapaneseText;
            romajiUIText.text = selectedRomajiText;

            // TypeControllerに新しい問題のローマ字テキストをセット
            typeController.romajiUIText.text = selectedRomajiText;
            typeController.indexOfString = 0; // インデックスをリセット

            // TypeControllerに新しい問題のローマ字テキストを設定
            typeController.SetRomajiText(selectedRomajiText);
        }
        else
        {
            // 日本語テキストとローマ字テキストが設定されていない場合は警告を表示
            Debug.LogWarning("日本語テキストとローマ字テキストが設定されていません。");
        }
    }
}
