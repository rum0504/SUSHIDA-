// TypeController.cs
using UnityEngine;
using UnityEngine.UI;

public class TypeController : MonoBehaviour
{
    public Text romajiUIText; // ���̃��[�}���\���e�L�X�g
    public WordController wordController; // WordController�̎Q��
    public Text scoreText; // �X�R�A��\������e�L�X�g
    private ScoreManager scoreManager; // ScoreManager�̎Q��
    public int finalScore = 0; // �ŏI�X�R�A

    private string romajiText; // ���̃��[�}����
    public int indexOfString = 0; // ���̉������ڂ�

    void Start()
    {
        // �C���X�y�N�^�[�Őݒ肳�ꂽ���[�}���e�L�X�g���擾
        romajiText = romajiUIText.text;

        // ScoreManager�R���|�[�l���g���擾
        scoreManager = FindObjectOfType<ScoreManager>(); // �V�[������ScoreManager���������Ď擾����
    }

    void Update()
    {
        // �L�[�{�[�h����̓��͂��󂯕t����
        if (Input.anyKeyDown)
        {
            CheckInput();
        }
    }

    void CheckInput()
    {
        string inputKey = Input.inputString;

        // �L�[�{�[�h����ł����������������ǂ������m�F
        if (indexOfString < romajiText.Length && inputKey == romajiText[indexOfString].ToString())
        {
            // �������̏���
            Correct();
            indexOfString++;

            // ������͂��I�����玟�̖���\��
            if (indexOfString >= romajiText.Length)
            {
                wordController.GenerateNextQuestion();
                indexOfString = 0; // �C���f�b�N�X�����Z�b�g

                // �����ԈႦ���ɑł����ꍇ�̃X�R�A�����Z
                scoreManager.AddCorrectScore();

                // �X�R�A���X�V
                UpdateScoreText();
            }
        }
        else
        {
            // ���s���̏���
            Mistake(inputKey);
        }
    }

    void Correct()
    {
        // �������̏������L�q
        romajiUIText.text = ColorText(romajiText, indexOfString, Color.green);
    }

    void Mistake(string inputKey)
    {
        // ���s���̏������L�q
        romajiUIText.text = ColorText(romajiText, indexOfString, Color.red);

        // �����ԈႦ�����Ō�܂őł��I�����ꍇ�̃X�R�A�����Z
        scoreManager.AddPartialCorrectScore();

        // �X�R�A���X�V
        UpdateScoreText();
    }

    string ColorText(string text, int index, Color color)
    {
        // �w�肳�ꂽ�C���f�b�N�X�̕������w�肳�ꂽ�F�ɕύX���ĕԂ�
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
        indexOfString = 0; // �C���f�b�N�X�����Z�b�g
    }

    void UpdateScoreText()
    {
        // �X�R�A��\������e�L�X�g���X�V
        scoreText.text = "�X�R�A: " + scoreManager.GetScore().ToString() + "�~";
        finalScore = scoreManager.GetScore(); // �ŏI�I�ȃX�R�A���X�V
    }

    public int GetFinalScore()
    {
        return finalScore; // �ŏI�I�ȃX�R�A���擾
    }
}
