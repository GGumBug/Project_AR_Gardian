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
    public Text jhTxt;
    public Text jhWrksTxt;
    
    public Image sjImg;
    public Image sjToolImg;
    public Image sjToolImg2;
    public Text sjTxt;
    public Text sjWrksTxt;
   
    public Image yhImg;
    public Image yhToolImg;
    public Image yhToolImg2;
    public Image yhToolImg3;
    public Text yhTxt;
    public Text yhWrksTxt;
    
    public Image mkImg;
    public Image mkToolImg;
    public Image mkToolImg2;
    public Text mkTxt;
    public Text mkWrksTxt;

    public Image copyrightImg;

    void Start()
    {
        CreditTween();              
    }

    void CreditTween()
    {
        Sequence seq = DOTween.Sequence();        
       
        seq.Append(blkBG.DOFade(1, 2f));
        seq.Append(creditImg.DOFade(1, 1f));
        seq.AppendInterval(0.5f);
        seq.Append(creditImg.DOFade(0, 0.5f));
        seq.Append(ttlImg.DOFade(1, 1.5f));
        seq.AppendInterval(1f);
        seq.Append(ttlImg.DOFade(0, 0.5f)); 
        seq.Append(creditDrwImg.DOFade(1, 1.5f));
        seq.Join(creditDrwTcImg.DOFade(1, 1.5f));
        
        //주현
        seq.Append(jhImg.DOFade(1, 0.5f));
        seq.Append(jhToolImg.DOFade(1, 0.5f));
        seq.Append(jhToolImg2.DOFade(1, 0.5f));
        
        seq.Append(jhTxt.DOText("이주현", 2, true, ScrambleMode.All));
        seq.Join(jhWrksTxt.DOText("모델링, 애니메이션", 2, true, ScrambleMode.All));

        //성진
        seq.Append(sjImg.DOFade(1, 0.5f));
        seq.Append(sjToolImg.DOFade(1, 0.5f));
        seq.Append(sjToolImg2.DOFade(1, 0.5f));

        seq.Append(sjTxt.DOText("김성진", 2, true, ScrambleMode.All));
        seq.Join(sjWrksTxt.DOText("개발, 유니티", 2, true, ScrambleMode.All));

        //유한
        seq.Append(yhImg.DOFade(1, 0.5f));
        seq.Append(yhToolImg.DOFade(1, 0.5f));
        seq.Append(yhToolImg2.DOFade(1, 0.5f));
        seq.Append(yhToolImg3.DOFade(1, 0.5f));
        
        seq.Append(yhTxt.DOText("유 한", 2, true, ScrambleMode.All));
        seq.Join(yhWrksTxt.DOText("디자인, 개발, 유니티", 2, true, ScrambleMode.All));

        //민기
        seq.Append(mkImg.DOFade(1, 0.5f));
        seq.Append(mkToolImg.DOFade(1, 0.5f));
        seq.Append(mkToolImg2.DOFade(1, 0.5f));

        seq.Append(mkTxt.DOText("민 기", 2, true, ScrambleMode.All));
        seq.Join(mkWrksTxt.DOText("개발, 유니티", 2, true, ScrambleMode.All));

        seq.Append(copyrightImg.DOFade(0.9f, 1f));
    }

}
