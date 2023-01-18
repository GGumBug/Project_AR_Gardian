using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ObjectManager : MonoBehaviour
{
    #region instance

    private static ObjectManager instance = null;

    public static ObjectManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@ObjectManager");
            instance = go.AddComponent<ObjectManager>();

            DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion

    ARRaycastManager arRaycast;

    GameObject monsterPref;

    private void Awake()
    {
        GameObject arSessionOrigin = GameObject.FindGameObjectWithTag("ARSessionOrigin");
        arRaycast = arSessionOrigin.GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        var screenPoint = Camera.current.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));

        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        if (arRaycast.Raycast(screenPoint, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
        {
            Pose planePos = hits[0].pose;

            monsterPref = CreateWisp();

            monsterPref.transform.position = planePos.position;
            monsterPref.transform.rotation = planePos.rotation;

            monsterPref.SetActive(true);
        }
        else
        {
            monsterPref.SetActive(false);
        }
    }

    public GameObject CreateWisp()
    {
        Object characterWisp = Resources.Load($"Object/Wisp_{BattleManager.GetInstance().curGuardian}");
        GameObject wisp = (GameObject)Instantiate(characterWisp);
        return wisp;
    }
    public GameObject CreateGuardian(int i)
    {
        Object GuardianObj = Resources.Load($"Object/Guardian_{i}");
        GameObject Guardian = (GameObject)Instantiate(GuardianObj);
        return Guardian;
    }
}
