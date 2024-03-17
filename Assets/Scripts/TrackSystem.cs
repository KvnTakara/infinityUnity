using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrackSystem : MonoBehaviour
{
    public GameObject track0;
    public GameObject track1;
    public GameObject track2;
    public GameObject track3;

    Vector3 targetPosition = new Vector3(0,0,30);

    List<GameObject> instantiatedTracks = new List<GameObject>();
    List<GameObject> randomTracks = new List<GameObject>();
    int index = 0;

    void Start()
    {
        randomTracks.Add(track0);
        randomTracks.Add(track1);
        randomTracks.Add(track2);
        randomTracks.Add(track3);

        instantiatedTracks.Add(null);
        instantiatedTracks.Add(null);

        for (int i = 0; i < 5; i++)
        {
            InstantiateTrack();
        }
    }

    void InstantiateTrack()
    {
        int randomNum = Random.Range(0, randomTracks.Count);
        GameObject selectedTrack = randomTracks[randomNum];
        GameObject trackInstance = Instantiate(selectedTrack, targetPosition, Quaternion.identity);
        instantiatedTracks.Add(trackInstance);
        targetPosition += new Vector3(0, 0, 30);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Track"))
        {
            Debug.Log(collider.name);
            InstantiateTrack();

            Destroy(instantiatedTracks[index]);
            index++;
        }
    }
}
