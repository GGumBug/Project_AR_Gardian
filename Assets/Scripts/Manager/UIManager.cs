using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    #region instance

    private static UIManager instance = null;

    public static UIManager GetInstance()
    {
        if(instance == null)
        {
            GameObject go = new GameObject("@UIManager");
            instance = go.AddComponent<UIManager>();

            DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion
    
    #region UI Control

    public void SetEventSystem()
    {
       if(FindObjectOfType<EventSystem>() == null)
        {
            GameObject go = new GameObject("@EventSystem");
            go.AddComponent<EventSystem>();
            go.AddComponent<StandaloneInputModule>();
        }
    }
    public Dictionary<string, GameObject> uiList = new Dictionary<string, GameObject>();

    public void OpenUI(string uiName)
    {
        if (uiList.ContainsKey(uiName) == false)
        {
            Object uiObj = Resources.Load("UI/" + uiName);
            GameObject go = (GameObject)Instantiate(uiObj);

            uiList.Add(uiName, go);
        }
        else
            uiList[uiName].SetActive(true);

    }

    /// <summary>
    /// UI를 닫는 함수입니다.
    /// </summary>
    /// <param name="uiName">닫아야하는 ui의 string 입니다.</param>
    public void CloseUI(string uiName)
    {
        if (uiList.ContainsKey(uiName))
            uiList[uiName].SetActive(false);
    }

    public GameObject GetUI(string uiName)
    {
        if (uiList.ContainsKey(uiName))
            return uiList[uiName];

        return null;

    }

    public void ClearList() // 씬전환을 할때 리스트로 불러온것들이 안쪽 은 지워지고 껍데기만 남아서온다 그래서 막상 불러왔지만
    {                       // 있다고 생각해서 재생성을 하지않아 에러가 발생한다 그래ㅓ지워주는것
        uiList.Clear();
    }
    #endregion

}
