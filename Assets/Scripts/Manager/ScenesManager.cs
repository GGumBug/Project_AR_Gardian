using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scene
{ 
    Title,
    Main,
    Battle,
    Ending,
}

public class ScenesManager : MonoBehaviour
{
    #region Singletone

    private static ScenesManager instance = null;

    public static ScenesManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@ScenesManager");
            instance = go.AddComponent<ScenesManager>();

            DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion

    #region Scene Control
    public Scene currentScene;
    public void ChangeScene(Scene scene)
    {

        UIManager.GetInstance().ClearList();
        ObjectManager.GetInstance().ClearObject();

        currentScene = scene;
        SceneManager.LoadScene(scene.ToString());
    }

    #endregion

    public void EndBattle()
    {
        StartCoroutine("EndBattleRoutine");
    }

    public IEnumerator EndBattleRoutine()
    {
        yield return new WaitForSeconds(2f);
        ChangeScene(Scene.Main);
    }
    public void DieTitle()
    {
        ChangeScene(Scene.Title);
        BattleManager.GetInstance().page = Page.page_0;
        GuardianManager.GetInstance().useUnblockableAttack = false;
        BattleManager.GetInstance().curGuardian = 0;
        GameManager.GetInstance().NewPlayer.hp = 100;
    }
    public void EndingSceneChange()
    {
        ChangeScene(Scene.Ending);
    }
    public void EndingSceneChangeInvoke()
    {
        Invoke("EndingSceneChange", 4f);
    }

}