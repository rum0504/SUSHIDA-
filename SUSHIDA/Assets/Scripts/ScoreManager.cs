using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0; // �X�R�A
    public static ScoreManager instance;

    public void AddCorrectScore()
    {
        // �����ԈႦ���ɑł����ꍇ�̃X�R�A�����Z
        score += 200;
    }

    public void AddPartialCorrectScore()
    {
        // �����ԈႦ�����Ō�܂őł��I�����ꍇ�̃X�R�A�����Z
        score += 100;
    }

    public int GetScore()
    {
        // ���݂̃X�R�A���擾
        return score;
    }

    void Awake()
    {
        // ScoreManager�̃C���X�^���X�����݂��Ȃ��ꍇ
        if (instance == null)
        {
            // ���̃C���X�^���X��ScoreManager�̃C���X�^���X�ɐݒ肷��
            instance = this;
        }
        else
        {
            // ����ScoreManager�̃C���X�^���X������ꍇ�́A���̃C���X�^���X��j������
            Destroy(gameObject);
        }
    }

    // �X�R�A�����������郁�\�b�h
    public void ResetScore()
    {
        score = 0;
    }

    // �X�R�A�����Z���郁�\�b�h
    public void AddScore(int amount)
    {
        score += amount;
    }


}
