using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class OnClickSoulButtonObject : MonoBehaviour
{
    [Header("アニメーション時間[s]")]
    [SerializeField] float waitTime = 0.4f;

    [Header("アニメーション移動距離X")]
    [SerializeField] float plusX = 60;

    [Header("アニメーション移動距離Y")]
    [SerializeField] float plusY = 80;

    Text text;
    public void Init(int soul)
    {
        text = GetComponent<Text>();

        if(text != null)
        {
            text.text = $"+{soul}ソウル";
            StartCoroutine(MoveCoroutine());
        }
    }

    IEnumerator MoveCoroutine()
    {
        float waitTime = this.waitTime * UnityEngine.Random.Range(0.9f, 1.1f);
        float plusX = this.plusX * UnityEngine.Random.Range(0.9f, 1.1f);
        float plusY = this.plusY * UnityEngine.Random.Range(0.9f, 1.1f);

        Color startColor = text.color;

        bool end = false;
        
        var sequence = DOTween.Sequence();

        Vector2 StartLocalPosition;

        StartLocalPosition = this.transform.localPosition;

        sequence
            .Append(this.transform.DOLocalMove(new Vector2(StartLocalPosition.x + plusX / 2f, StartLocalPosition.y + plusY), waitTime/2f))
            .AppendCallback(() => end = true);

        sequence.Play();

        yield return new WaitWhile(() => !end);
        end = false;

        yield return new WaitForSeconds(waitTime * 0.2f);

        StartLocalPosition = this.transform.localPosition;

        sequence = DOTween.Sequence();

        sequence
            .Append(this.transform.DOLocalMove(new Vector2(StartLocalPosition.x + plusX / 2f, StartLocalPosition.y - plusY), waitTime/2f))
            .Append(DOTween.To(() => text.color, (x) => text.color = x, new Color(startColor.r, startColor.g, startColor.b, 0), waitTime/2f).SetEase(Ease.OutCubic))
            .AppendCallback(() => end = true);

        sequence.Play();

        yield return new WaitWhile(() => !end);
        end = false;

        this.gameObject.SetActive(false);

        Destroy(this.gameObject);
    }
}
