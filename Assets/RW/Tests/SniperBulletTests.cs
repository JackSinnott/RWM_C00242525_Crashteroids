using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SniperBulletTests
{
    private Game game;

    [SetUp]
    public void Setup()
    {
        GameObject gameGameObject =
          MonoBehaviour.Instantiate(
            Resources.Load<GameObject>("Prefabs/Game"));
        game = gameGameObject.GetComponent<Game>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(game.gameObject);
    }

    [UnityTest]
    public IEnumerator SurvivedAsteroid()
    {
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();

        while (asteroid.GetComponent<Asteroid>().GetHealth() != 2)
        {
            asteroid = game.GetSpawner().SpawnAsteroid();
        }

        asteroid.transform.position = Vector3.zero;
        GameObject laser = game.GetShip().SpawnLaser();
        laser.transform.position = Vector3.zero;
        yield return new WaitForSeconds(0.1f);
        UnityEngine.Assertions.Assert.IsNotNull(asteroid);

        laser = game.GetShip().SpawnLaser();
        laser.transform.position = Vector3.zero;
        yield return new WaitForSeconds(0.1f);
        UnityEngine.Assertions.Assert.IsNull(asteroid);
    }

    [UnityTest]
    public IEnumerator SniperBulletOneShot()
    {
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();

        while (asteroid.GetComponent<Asteroid>().GetHealth() != 2)
        {
            asteroid = game.GetSpawner().SpawnAsteroid();
        }

        asteroid.transform.position = Vector3.zero;
        GameObject laser = game.GetShip().SpawnSniper();
        laser.transform.position = Vector3.zero;
        yield return new WaitForSeconds(0.1f);
        UnityEngine.Assertions.Assert.IsNull(asteroid);
    }

}
