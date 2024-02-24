using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float gameDuration = 30f; // �Q�[���̐������ԁi�b�j
    public Text timerText; // �������Ԃ�\������e�L�X�g
    public GameObject gameOverPanel; // �Q�[���I�[�o�[���ɕ\������p�l��
    public Text finalScoreText; // �ŏI�X�R�A��\������e�L�X�g

    private float remainingTime; // �c�莞��
    private int finalScore; // �ŏI�X�R�A
    private bool isGameRunning = false; // �Q�[�������s�����ǂ���

    public static GameManager instance;

    void Start()
    {
        // �Q�[�����J�n
        StartGame();
    }

    void Update()
    {
        // �Q�[�������s���ł���Ύ��Ԃ����炷
        if (isGameRunning)
        {
            remainingTime -= Time.deltaTime;

            // �^�C�}�[�e�L�X�g���X�V
            timerText.text = "�c�� " + remainingTime.ToString("F0") + " �b";

            // �Q�[���̎c�莞�Ԃ�0�ȉ��ɂȂ�����Q�[���I�[�o�[
            if (remainingTime <= 0f)
            {
                GameOver();
            }
        }
    }

    void Awake()
    {
        // GameManager�̃C���X�^���X�����݂��Ȃ��ꍇ
        if (instance == null)
        {
            // ���̃C���X�^���X��GameManager�̃C���X�^���X�ɐݒ肷��
            instance = this;
        }
        else
        {
            // ����GameManager�̃C���X�^���X������ꍇ�́A���̃C���X�^���X��j������
            Destroy(gameObject);
        }
    }

    // �Q�[�����J�n����
    void StartGame()
    {
        // �������Ԃ�ݒ�
        remainingTime = gameDuration;
        isGameRunning = true;
    }

    // �Q�[���I�[�o�[����
    void GameOver()
    {
        // �ŏI�X�R�A��ݒ�
        finalScore = ScoreManager.instance.GetScore();
        Debug.Log("Final Score: " + finalScore);

        // �Q�[���I�[�o�[�p�l����\�����A�ŏI�X�R�A��\������
        gameOverPanel.SetActive(true);
        finalScoreText.text = "�H�ׂ����z: " + finalScore.ToString() + "�~";
    }
}
