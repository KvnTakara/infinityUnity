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

    public GameObject obstacle0;
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;

    List<GameObject> obstaclesList = new List<GameObject>();
    List<Vector3> obstaclesPosition = new List<Vector3>();

    void Start()
    {
        randomTracks.Add(track0);
        randomTracks.Add(track1);
        randomTracks.Add(track2);
        randomTracks.Add(track3);

        obstaclesList.Add(null);
        obstaclesList.Add(obstacle0);
        obstaclesList.Add(obstacle1);
        obstaclesList.Add(obstacle2);
        obstaclesList.Add(obstacle3);

        obstaclesPosition.Add(new Vector3(-2, 0, 0));
        obstaclesPosition.Add(new Vector3(0, 0, 0));
        obstaclesPosition.Add(new Vector3(2, 0, 0));
        obstaclesPosition.Add(new Vector3(-2, 0, 10));
        obstaclesPosition.Add(new Vector3(0, 0, 10));
        obstaclesPosition.Add(new Vector3(2, 0, 10));
        obstaclesPosition.Add(new Vector3(-2, 0, 20));
        obstaclesPosition.Add(new Vector3(0, 0, 20));
        obstaclesPosition.Add(new Vector3(2, 0, 20));
    }

    void InstantiateTrack()
    {
        // Randomize one of the Tracks in randomTracks List to Instantiate.
        int randomIndex = Random.Range(0, randomTracks.Count);
        GameObject selectedTrack = randomTracks[randomIndex];
        GameObject trackInstance = Instantiate(selectedTrack, targetPosition, Quaternion.identity);

        int rangeMin = 0;
        int rangeMax = 2;
        for (int i = 0;i < 2; i++)
        {
            // Pick a random obstacle in the list and then a random position for it.
            if (i == 0) randomIndex = Random.Range(0, 2);
            else randomIndex = Random.Range(0, obstaclesList.Count);
            int randomPosition = Random.Range(rangeMin, rangeMax);

            // Instantiate the Obstacle.
            GameObject selectedObstacle = obstaclesList[randomIndex];
            if (obstaclesList[randomIndex] != null)
            {
                GameObject obstacleInstance = Instantiate(selectedObstacle, targetPosition + obstaclesPosition[randomPosition], Quaternion.identity);
            }

            // Change the Random.Range for the next obstacle position
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
