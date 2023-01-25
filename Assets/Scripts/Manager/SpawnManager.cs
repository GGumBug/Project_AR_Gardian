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

            //DontDestroyOnLoad(go);
        }
        return instance;

    }
    #endregion

    [Header("Object")]
    public ARRaycastManager arRaycast;
    public GameObject monsterPref = null;
    public Transform spawnPosition;

    [Header("Rate")]
    [SerializeField] float SpawnDelay = 0.5f;
    [SerializeField] int SpawnRate = 70;

    private void Start()
    {
        monsterPref = null;
        GameObject arSessionOrigin = GameObject.FindGameObjectWithTag("ARSessionOrigin");
        arRaycast = arSessionOrigin.GetComponent<ARRaycastManager>();
        GameObject spawnPositionGo = GameObject.FindGameObjectWithTag("SpawnPosition");
        spawnPosition = spawnPositionGo.transform;
    }

    private void Update()
    {
        //if (arRaycast == null)
        //{
        //    GameObject arSessionOrigin = GameObject.FindGameObjectWithTag("ARSessionOrigin");
        //    arRaycast = arSessionOrigin.GetComponent<ARRaycastManager>();
        //}

        if (BattleManager.GetInstance().page == Page.page_1)
        {
            return;
        }

        var screenPoint = Camera.current.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));

        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        if (arRaycast.Raycast(screenPoint, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
        {
            Debug.Log("arRaycast Hit");
            Debug.Log("monsterPref : " + monsterPref);
            if (monsterPref != null)
            {
                return;
            }

            Debug.Log("IsInvoking : " + IsInvoking());
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
            SpawnWisp();
        else
            Invoke("CheckTime", SpawnDelay);
    }

    void SpawnWisp()
    {
        monsterPref = ObjectManager.GetInstance().CreateWisp();
    }

}
