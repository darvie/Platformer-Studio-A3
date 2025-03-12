using UnityEngine;
using System.Collections;
using TMPro;
using DG.Tweening;

public class CoinCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private float duration;
    [SerializeField] private Transform coinTextContainer;
    [SerializeField] private Ease animationCurve;

    private float containerInitPosition;
    private float moveAmount;


    void Start()
    {
        current.SetText("0");
        toUpdate.SetText("0");
        containerInitPosition = coinTextContainer.localPosition.y;
        moveAmount = current.rectTransform.rect.height;

    }

    public void UpdateScore(int score)
    {
        toUpdate.SetText($"{score}");
        coinTextContainer.DOLocalMoveY(containerInitPosition + moveAmount, duration).SetEase(animationCurve);
        StartCoroutine(ResetCoinContainer(score));
    }

    private IEnumerator ResetCoinContainer(int score) {
        yield return new WaitForSeconds(duration);
        current.SetText($"{score}");
        Vector3 localPosition = coinTextContainer.localPosition;
        coinTextContainer.localPosition = new Vector3(localPosition.x, containerInitPosition, localPosition.z);



    }
}
