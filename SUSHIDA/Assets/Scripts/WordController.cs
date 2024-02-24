using UnityEngine;
using UnityEngine.UI;

public class WordController : MonoBehaviour
{
    // ���̓��{�ꕶ
    public string[] japaneseTexts;
    // ���̃��[�}����
    public string[] romajiTexts;
    // ���{��\���e�L�X�g
    public Text japaneseUIText;
    // ���[�}���\���e�L�X�g
    public Text romajiUIText;

    // TypeController�ւ̎Q��
    public TypeController typeController;

    private void Start()
    {
        GenerateNextQuestion();
    }

    // ���̖��𐶐����A�\������
    public void GenerateNextQuestion()
    {
        // ���{��e�L�X�g�ƃ��[�}���e�L�X�g�̔z�񂪋�łȂ����Ƃ��m�F
        if (japaneseTexts != null && romajiTexts != null && japaneseTexts.Length > 0 && romajiTexts.Length > 0)
        {
            // ��萔���Ń����_���ɑI��
            int numberOfQuestion = Random.Range(0, japaneseTexts.Length);

            // �I�����������e�L�X�gUI�ɃZ�b�g
            string selectedJapaneseText = japaneseTexts[numberOfQuestion];
            string selectedRomajiText = romajiTexts[numberOfQuestion];
            japaneseUIText.text = selectedJapaneseText;
            romajiUIText.text = selectedRomajiText;

            // TypeController�ɐV�������̃��[�}���e�L�X�g���Z�b�g
            typeController.romajiUIText.text = selectedRomajiText;
            typeController.indexOfString = 0; // �C���f�b�N�X�����Z�b�g

            // TypeController�ɐV�������̃��[�}���e�L�X�g��ݒ�
            typeController.SetRomajiText(selectedRomajiText);
        }
        else
        {
            // ���{��e�L�X�g�ƃ��[�}���e�L�X�g���ݒ肳��Ă��Ȃ��ꍇ�͌x����\��
            Debug.LogWarning("���{��e�L�X�g�ƃ��[�}���e�L�X�g���ݒ肳��Ă��܂���B");
        }
    }
}
