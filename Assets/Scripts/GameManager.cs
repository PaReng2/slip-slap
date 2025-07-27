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

    public bool isDathP1;
    public bool isDathP2;

    private float curStPoint;
    private float curNdPoint;
    private Vector3 originalScale;
    public GameObject ScoreBG;
    
    private Vector2 originalP1Position;
    private Vector2 originalP2Position;
    
    private bool isScoring = false;

    [Header("playerPrefab")]
    public GameObject p1;
    public GameObject p2;
     

    [Header("GameOverText")]
    public TextMeshProUGUI ScoreGuide;
    public TextMeshProUGUI ScoreST;
    public TextMeshProUGUI ScoreND;


    void Start()
    {
        originalP1Position = p1.transform.position;
        originalP2Position = p2.transform.position;
        
        TextDisabled();
        originalScale = ScoreBG.transform.localScale;
        curStPoint = firstPoint;
        curNdPoint = secondPoint;

        isDathP1 = false;
        isDathP2 = false;
        
    }

    void Update()
    {
        if (!isScoring && (curStPoint != firstPoint || curNdPoint != secondPoint))
        {
            StartCoroutine(Scored());
        }
    }

    IEnumerator Scored()
    {
        BulletSpawner spawner = FindObjectOfType<BulletSpawner>();
        if (isDathP1 || isDathP2)
        {
            p1.transform.position = new Vector2(1000, 1000);
            p2.transform.position = new Vector2(1000, 1000);
        }
        
        if (curStPoint != firstPoint || curNdPoint != secondPoint)
        {
            spawner.enabled = false;
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
            seq.AppendInterval(2f);  

            seq.AppendCallback(() => {
                  TextDisabled();
                } );
           
            seq.Append(ScoreBG.transform.DOScale(originalScale, 1.5f));
            
        }

        yield return new WaitForSeconds(5.5f);
        if (isDathP1 || isDathP2)
        {
            p1.transform.position = originalP1Position;
            p2.transform.position = originalP2Position;
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
