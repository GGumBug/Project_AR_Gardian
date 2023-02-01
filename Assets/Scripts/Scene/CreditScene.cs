using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class CreditScene : MonoBehaviour
{
    Sequence endingSequence = DOTween.Sequence();

    public Image blkBG;
    public Image creditImg;
    public Image ttlImg;
    public Image creditDrwImg;
    public Image creditDrwTcImg;
    
    public Image jhImg;
    public Image jhToolImg;
    public Image jhToolImg2;
    public TMP_Text jhTxt;
    public TMP_Text jhWrksTxt;
    
    public Image sjImg;
    public Image sjToolImg;
    public Image sjToolImg2;
    public TMP_Text sjTxt;
    public TMP_Text sjWrksTxt;
   
    public Image yhImg;
    public Image yhToolImg;
    public Image yhToolImg2;
    public Image yhToolImg3;
    public TMP_Text yhTxt;
    public TMP_Text yhWrksTxt;
    
    public Image mkImg;
    public Image mkToolImg;
    public Image mkToolImg2;
    public TMP_Text mkTxt;
    public TMP_Text mkWrksTxt;


    void Start()
    {
        CreditTween();              
    }

    void CreditTween()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(blkBG.DOFade(1, 2f));
        seq.Append(creditImg.DOFade(1, 1f));
        //seq.Append(jhTxt.DoTe);
        seq.AppendInterval(0.5f);
        seq.Append(creditImg.DOFade(0, 0.5f));
        seq.Append(ttlImg.DOFade(1, 1.5f));
        seq.AppendInterval(1f);
        seq.Append(ttlImg.DOFade(0, 0.5f)); 
        seq.Append(creditDrwImg.DOFade(1, 1.5f));
        seq.Join(creditDrwTcImg.DOFade(1, 1.5f));
        seq.Append(jhImg.DOFade(1, 2f));
        seq.Join(jhToolImg.DOFade(1, 2f));
        seq.Join(jhToolImg2.DOFade(1, 2f));
        //seq.Append(jhTxt.DoText(string to, ));
    }
}
