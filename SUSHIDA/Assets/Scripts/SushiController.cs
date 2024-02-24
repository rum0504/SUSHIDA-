using UnityEngine;

public class SushiController : MonoBehaviour
{
    public Sprite[] sushiSprites; // インスペクターから設定するための寿司画像の配列

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

    // 寿司画像の移動
    void MoveSushi()
    {
        sushiRectTransform.localPosition += Vector3.right * sushiSpeed * Time.deltaTime;

        // 画面外に出たら次の寿司画像をセットして位置をリセットする
        if (sushiRectTransform.localPosition.x > sushiEndPosition)
        {
            SetRandomSushiSprite();
            ResetSushiPosition();
        }
    }

    // ランダムな寿司画像をセットする
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

    // 寿司画像の位置を初期位置にリセットする
    void ResetSushiPosition()
    {
        sushiRectTransform.localPosition = new Vector3(sushiStartPosition, 0f, 0f);
    }
}
