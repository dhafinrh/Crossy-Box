using UnityEngine;

public class Road : Terrain
{
    [SerializeField] CarMovement carPrefab;
    [SerializeField] float minInterval;
    [SerializeField] float maxInterval;
    [SerializeField, Range(0, 1)] float spawnProbability;


    float timer;
    Vector3 carSpawnPosition;
    Quaternion carRotation;

    private void Start()
    {
        if (Random.value > 0.5f)
        {
            carSpawnPosition = new Vector3(horizontalSize / 2 + 3, 0, this.transform.position.z);

            carRotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            carSpawnPosition = new Vector3(-(horizontalSize / 2 + 3), 0, this.transform.position.z);

            carRotation = Quaternion.Euler(0, 90, 0);
        }
    }

    private void Update()
    {
        if (timer <= 0 && Random.value < spawnProbability) // check if a car should be spawned based on the spawn probability
        {
            timer = Random.Range(minInterval, maxInterval);

            var car = Instantiate(carPrefab, carSpawnPosition, carRotation);

            car.setUpDistanceLimit(horizontalSize + 6);

            return;
        }

        timer -= Time.deltaTime;
    }
}
