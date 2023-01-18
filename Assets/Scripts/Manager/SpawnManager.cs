using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnManager : MonoBehaviour
{
    #region instance

    private static SpawnManager instance = null;

    public static SpawnManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@SpawnManager");
            instance = go.AddComponent<SpawnManager>();

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

        monsterPref = ObjectManager.GetInstance().CreateWisp();

        if (arRaycast.Raycast(screenPoint, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
        {
            Pose planePos = hits[0].pose;

            monsterPref.transform.position = planePos.position;
            monsterPref.transform.rotation = planePos.rotation;

            monsterPref.SetActive(true);
        }
        else
        {
            monsterPref.SetActive(false);
        }
    }
}
