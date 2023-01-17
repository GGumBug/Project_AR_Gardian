using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    #region instance

    private static ObjectManager instance = null;

    public static ObjectManager GetInstance()
    {
        if(instance == null)
        {
            GameObject go = new GameObject("@ObjectManager");
            instance = go.AddComponent<ObjectManager>();

            DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion

    public Dictionary<string, GameObject> showCaseList = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> RelicsList = new Dictionary<string, GameObject>();
    List<GameObject> SymbolList = new List<GameObject>();
    Dictionary<string, GameObject> SumacsaeList = new Dictionary<string, GameObject>();

    Camera mainCa;
    Camera secondCa;
    public void CreateQuest()
    {
        QuestObject[] questObjectList = QuestManager.GetInstance().questObjectList;

        for (int i = 0; i < questObjectList.Length; i++)
        {
            string showCaseName = questObjectList[i].showCaseName;
            string reliceName = questObjectList[i].reliceName;

            CreateObject(showCaseName, i, questObjectList[i].isDone);
            InPutRelics(reliceName, showCaseName, i);
            CreateSymbol(reliceName);
        }
    }
    //public GameObject CreateQuizOj(string quizojName)
    //{
    //    Object createQuizOj = Resources.Load("Resources/" + quizojName);
    //    GameObject quizOj = (GameObject)Instantiate(createQuizOj);

    //    return quizOj;
    //}


    public void CreateObject(string objectName, int num, bool isDone)
    {
        if (showCaseList.ContainsKey(objectName) == false)
        {
            Object Obj = Resources.Load("Object/" + objectName);
            GameObject go = (GameObject)Instantiate(Obj);
            ShowCase goShowCase = go.GetComponent<ShowCase>();

            goShowCase.isDone = isDone;

            int index = go.name.IndexOf("(Clone)");
            if (index > 0) 
            go.name = go.name.Substring(0, index);

            showCaseList.Add(objectName, go);
        }
        else
        showCaseList[objectName].SetActive(true);
    }

    public void MoveShowcase(int questNumber ,Vector3 positon)
    {
        QuestObject[] questObjectList = QuestManager.GetInstance().questObjectList;
        string showCaseName = questObjectList[questNumber].showCaseName;
        string reliceName = questObjectList[questNumber].reliceName;

        showCaseList[showCaseName].transform.position += positon;
        RelicsList[reliceName].transform.position += positon;
        SymbolList[questNumber].transform.position += positon;
    }

    public void MoveSymboll(int questNumber ,Vector3 positon)
    {
        SymbolList[questNumber].transform.position += positon;
    }

    public void MoveSumacsae(int questNumber ,Vector3 positon)
    {
        if (SumacsaeList.ContainsKey(QuestManager.GetInstance().sumacsaesList[questNumber].name) == false)
        {
            return;
        }
        SumacsaeList[QuestManager.GetInstance().sumacsaesList[questNumber].name].transform.position = positon;

    }


    public void InPutRelics(string relicsName,string objectName, int num)
    {
        if (RelicsList.ContainsKey(relicsName) == false)
        {
            Object Obj = Resources.Load("Object/" + relicsName);
            GameObject go = (GameObject)Instantiate(Obj);

            MeshRenderer relicsPoint = showCaseList[objectName].GetComponentInChildren<MeshRenderer>();

            go.transform.position = relicsPoint.transform.position;

            if (QuestManager.GetInstance().questObjectList[num].isDone == false)
            {
                go.SetActive(false);
            }

            RelicsList.Add(relicsName, go);
        }
        else
        RelicsList[relicsName].SetActive(true);
    }

    public void CreateSymbol(string reliceName)
    {
        Object Obj = Resources.Load("Object/" + "Symbol");
        GameObject go = (GameObject)Instantiate(Obj);
        go.transform.position = RelicsList[reliceName].gameObject.transform.position;
        go.transform.position += new Vector3(0,1.5f,0); 

        SymbolList.Add(go);
        
        if (RelicsList[reliceName].gameObject.activeSelf == true)
        {
            go.SetActive(false);
        }
    }

    public void CreateSumacsae()
    {
        GameObject mainCame = GameObject.FindGameObjectWithTag("MainCamera");
        mainCa = mainCame.GetComponent<Camera>();
        GameObject secondCame = GameObject.FindGameObjectWithTag("SecondCamera");
        secondCa = secondCame.GetComponent<Camera>();

        for (int i = 0; i < QuestManager.GetInstance().sumacsaesList.Length; i++)
        {
            if (QuestManager.GetInstance().sumacsaesList[0].isClear && QuestManager.GetInstance().sumacsaesList[1].isClear && QuestManager.GetInstance().sumacsaesList[2].isClear == true)
            {

                Down();
                Invoke("Up", 7f);
            }

            if (QuestManager.GetInstance().sumacsaesList[i].isClear != false)
            {

                Object Obj = Resources.Load("Object/" + QuestManager.GetInstance().sumacsaesList[i].name);
                GameObject go = (GameObject)Instantiate(Obj);

                AudioManager.instance.sfxAudioSource.clip = AudioManager.instance.sfxList[0];
                AudioManager.instance.sfxAudioSource.volume = 1f;
                AudioManager.instance.sfxAudioSource.Play();

                SumacsaeList.Add(QuestManager.GetInstance().sumacsaesList[i].name, go);
                if (QuestManager.GetInstance().sumacsaesList[0].isClear || QuestManager.GetInstance().sumacsaesList[1].isClear || QuestManager.GetInstance().sumacsaesList[2].isClear != true)
                {
                    mainCa.depth -= 2;
                    Invoke("Up", 4f);
                }
            }
        }



    }
    public void CreateEndingPotar()
    {
        Object poTarObj = Resources.Load("Object/" + "EndingPotar");
        GameObject poTar = (GameObject)Instantiate(poTarObj);

    }

    public GameObject GetObject(string objectName)
    {
        if (showCaseList.ContainsKey(objectName))
            return showCaseList[objectName];

        return null;

    }

    public void ClearList()
    {
        showCaseList.Clear();
        RelicsList.Clear();
        SymbolList.Clear();
        SumacsaeList.Clear();
    }

    public void Down()
    {
        mainCa.depth -= 2;
    }

    public void Up()
    {
        mainCa.depth += 2;
    }
}
