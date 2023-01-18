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

    GameObject monsterPref = null;

    public Transform spawnPosition;

    public float SpawnDelay = 2f;
    public int SpawnRate = 40;

    private void Awake()
    {
        GameObject arSessionOrigin = GameObject.FindGameObjectWithTag("ARSessionOrigin");
        arRaycast = arSessionOrigin.GetComponent<ARRaycastManager>();
        GameObject spawnPositionGo = GameObject.FindGameObjectWithTag("SpawnPosition");
        spawnPosition = spawnPositionGo.transform;
    }

    private void Update()
    {
        var screenPoint = Camera.current.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));

        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        if (arRaycast.Raycast(screenPoint, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
        {
            if (monsterPref != null)
            {
                return;
            }

            if (IsInvoking())
                return;

            Invoke("CheckTime", SpawnDelay);
        }
        else
        {
            CancelInvoke("CheckTime");

            if (monsterPref != null)
            {
                Destroy(monsterPref);
                monsterPref = null;
            }
        }
    }
    void CheckTime()
    {
        int rate = Random.Range(0, 100);

        if (rate <= SpawnRate)
            SpawnMonster();
        else
            Invoke("CheckTime", SpawnDelay);
    }

    void SpawnMonster()
    {
        monsterPref = ObjectManager.GetInstance().CreateWisp();
    }

}
