using UnityEngine;

public class SushiController : MonoBehaviour
{
    public Sprite[] sushiSprites; // �C���X�y�N�^�[����ݒ肷�邽�߂̎��i�摜�̔z��

    private RectTransform sushiRectTransform;
    private int currentSpriteIndex = 0;
    private float sushiSpeed = 100f;
    private float sushiStartPosition = -300f;
    private float sushiEndPosition = 300f;

    void Start()
    {
        sushiRectTransform = GetComponent<RectTransform>();
        SetRandomSushiSprite();
        ResetSushiPosition();
    }

    void Update()
    {
        MoveSushi();
    }

    // ���i�摜�̈ړ�
    void MoveSushi()
    {
        sushiRectTransform.localPosition += Vector3.right * sushiSpeed * Time.deltaTime;

        // ��ʊO�ɏo���玟�̎��i�摜���Z�b�g���Ĉʒu�����Z�b�g����
        if (sushiRectTransform.localPosition.x > sushiEndPosition)
        {
            SetRandomSushiSprite();
            ResetSushiPosition();
        }
    }

    // �����_���Ȏ��i�摜���Z�b�g����
    void SetRandomSushiSprite()
    {
        if (sushiSprites.Length > 0)
        {
            currentSpriteIndex = Random.Range(0, sushiSprites.Length);
            GetComponent<UnityEngine.UI.Image>().sprite = sushiSprites[currentSpriteIndex];
        }
        else
        {
            Debug.LogError("Sushi sprites are not assigned!");
        }
    }

    // ���i�摜�̈ʒu�������ʒu�Ƀ��Z�b�g����
    void ResetSushiPosition()
    {
        sushiRectTransform.localPosition = new Vector3(sushiStartPosition, 0f, 0f);
    }
}
