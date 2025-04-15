using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameManager gameManager; // Reference to the GameManager
    public GameObject largeAsteroid; // Prefab for the large asteroid
    public int spawnPerDestroyedAsteroids = 4;// Number of asteroids to spawn per destroyed asteroid
    private int spawnedAsteroidsCount = 0;// Count of spawned asteroids

    public void CheckSpawnAsteroid(int score) // Check if we should spawn a new asteroid
    {
        int shouldBeSpawnedCount = score / spawnPerDestroyedAsteroids;// Calculate how many asteroids should be spawned based on score
        int diff = shouldBeSpawnedCount - spawnedAsteroidsCount;// Calculate the difference between the current and required number of spawned asteroids
        if (diff > 0)
        {
            spawnedAsteroidsCount++;// Increment the count of spawned asteroids

            float angle = Random.Range(0, Mathf.PI * 2);//random angle for the asteroid's position
            Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * 45;// Calculate the position of the new asteroid
            GameObject newAsteroid = Instantiate(largeAsteroid, pos, Quaternion.identity);// Instantiate the new asteroid   
            Asteroid asteroid = newAsteroid.GetComponent<Asteroid>();// Get the Asteroid component from the new asteroid
            asteroid.RandomizeStartVelocity = false;// Disable random velocity for the new asteroid
            asteroid.MoveTowardsCentre();// Move the new asteroid towards the center
        }
    }
}
