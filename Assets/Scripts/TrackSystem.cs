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

    Vector3 targetPosition = new Vector3(0,0,60);

    List<GameObject> randomTracks = new List<GameObject>();

    public GameObject t0obstacle0;
    public GameObject t0obstacle1;

    public GameObject t1obstacle0;
    public GameObject t1obstacle1;

    public GameObject t2obstacle0;
    public GameObject t2obstacle1;

    public GameObject t3obstacle0;
    public GameObject t3obstacle1;
    public GameObject t3obstacle2;
    public GameObject t3obstacle3;

    public GameObject t4obstacle0;
    public GameObject t4obstacle1;
    public GameObject t4obstacle2;
    public GameObject t4obstacle3;

    public GameObject t5obstacle0;
    public GameObject t5obstacle1;
    public GameObject t5obstacle2;
    public GameObject t5obstacle3;

    public GameObject t6obstacle0;
    public GameObject t6obstacle1;
    public GameObject t6obstacle2;
    public GameObject t6obstacle3;

    public GameObject t7obstacle0;
    public GameObject t7obstacle1;
    public GameObject t7obstacle2;
    public GameObject t7obstacle3;

    public GameObject t8obstacle0;
    public GameObject t8obstacle1;
    public GameObject t8obstacle2;
    public GameObject t8obstacle3;

    List<List<GameObject>> obstaclesLists = new List<List<GameObject>>();

    void Start()
    {
        randomTracks.Add(track0);
        randomTracks.Add(track1);
        randomTracks.Add(track2);
        randomTracks.Add(track3);

        obstaclesLists.Add(new List<GameObject> { null, t0obstacle0, t0obstacle1});
        obstaclesLists.Add(new List<GameObject> { null, t1obstacle0, t1obstacle1 });
        obstaclesLists.Add(new List<GameObject> { null, t2obstacle0, t2obstacle1 });
        obstaclesLists.Add(new List<GameObject> { null, t3obstacle0, t3obstacle1, t3obstacle2, t3obstacle3 });
        obstaclesLists.Add(new List<GameObject> { null, t4obstacle0, t4obstacle1, t4obstacle2, t4obstacle3 });
        obstaclesLists.Add(new List<GameObject> { null, t5obstacle0, t5obstacle1, t5obstacle2, t5obstacle3 });
        obstaclesLists.Add(new List<GameObject> { null, t6obstacle0, t6obstacle1, t6obstacle2, t6obstacle3 });
        obstaclesLists.Add(new List<GameObject> { null, t7obstacle0, t7obstacle1, t7obstacle2, t7obstacle3 });
        obstaclesLists.Add(new List<GameObject> { null, t8obstacle0, t8obstacle1, t8obstacle2, t8obstacle3 });
    }

    void InstantiateTrack()
    {
        // Randomize one of the Tracks in randomTracks List to Instantiate.
        int randomNum = Random.Range(0, randomTracks.Count);
        GameObject selectedTrack = randomTracks[randomNum];
        GameObject trackInstance = Instantiate(selectedTrack, targetPosition, Quaternion.identity);

        // Pick randomly one of the tree rail tracks to Instantiate a random Obstacle.
        int rangeMin = 0;
        int rangeMax = 2;
        for (int i = 0;i < 2; i++)
        {
            randomNum = Random.Range(rangeMin, rangeMax);
            int randomNum2 = Random.Range(0, obstaclesLists[randomNum].Count);
            GameObject selectedObstacle = obstaclesLists[randomNum][randomNum2];
            if (obstaclesLists[randomNum][randomNum2] != null)
            {
                GameObject obstacleInstance = Instantiate(selectedObstacle, targetPosition, Quaternion.identity);
            }
            rangeMin += 3;
            rangeMax += 3;
        }

        targetPosition += new Vector3(0, 0, 30);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Track"))
        {
            InstantiateTrack();
        }
    }
}
