using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float firstPoint;
    public float secondPoint;

    private float curStPoint;
    private float curNdPoint;
    private Vector3 originalScale;
    public GameObject ScoreBG;

    [Header("GameOverText")]
    public TextMeshProUGUI ScoreGuide;
    public TextMeshProUGUI ScoreST;
    public TextMeshProUGUI ScoreND;
    // Start is called before the first frame update
    void Start()
    {
        TextDisabled();
        originalScale = ScoreBG.transform.localScale;
        curStPoint = firstPoint;
        curNdPoint = secondPoint;

    }

    // Update is called once per frame
    void Update()
    {
        Scored();
    }

    async Task Scored()
    {
        if (curStPoint != firstPoint || curNdPoint != secondPoint)
        {
            
            curStPoint = firstPoint;
            curNdPoint = secondPoint;

            ScoreBG.transform.DOKill();

            Sequence seq = DOTween.Sequence();
            seq.Append(ScoreBG.transform.DOScaleY(4.5f, 1.5f));
            seq.Join(ScoreBG.transform.DOScaleX(15f, 1.5f));
            seq.AppendCallback(() => {
                TextEnabled();
                TextInputScored();
                 });
            seq.AppendInterval(2f); // 원하는 유지 시간

            seq.AppendCallback(() => {
                  TextDisabled();
                } );
           
            seq.Append(ScoreBG.transform.DOScale(originalScale, 1.5f));
           
        }
        
    }

    void TextEnabled()
    {
        ScoreGuide.enabled = true;
        ScoreST.enabled = true;
        ScoreND.enabled = true;
    }
    void TextDisabled()
    {
        ScoreGuide.enabled = false;
        ScoreST.enabled = false;
        ScoreND.enabled = false;
    }

    void TextInputScored()
    {
        ScoreST.text =  firstPoint.ToString();
        ScoreND.text = secondPoint.ToString();
    }
}
