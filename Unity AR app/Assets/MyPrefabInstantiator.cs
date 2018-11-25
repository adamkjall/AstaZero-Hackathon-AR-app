using UnityEngine;
using Vuforia;
using System.Collections;
public class MyPrefabInstantiator : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    public GameObject myModelPrefab;

    public bool HasInit { get; private set; }

    // Use this for initialization
    void Start()
    {
        Debug.Log("######################### Prefab - Start");
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void OnTrackableStateChanged(

    TrackableBehaviour.Status previousStatus,
    TrackableBehaviour.Status newStatus)
    {
        Debug.Log("############### Prefab - On track state changed");
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
        newStatus == TrackableBehaviour.Status.TRACKED ||
        newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
    }

    
    private void OnTrackingFound()
    {
        if(HasInit)
        {
            return;
        }

        HasInit = true;

        if (myModelPrefab != null)
        {
            Debug.Log("############# Prefab - Tracking found");
            GameObject go = GameObject.Instantiate(myModelPrefab);
            Transform myModelTrf = go.transform;
            myModelTrf.parent = mTrackableBehaviour.transform;
            //myModelTrf.localPosition = new Vector3(0f, 0f, 0f);
            myModelTrf.localRotation = Quaternion.identity;
            //myModelTrf.localScale = new Vector3(0.0005f, 0.0005f, 0.0005f);
            myModelTrf.gameObject.SetActive(true);
            
        }
    }
}