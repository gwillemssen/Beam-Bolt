using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamManager : MonoBehaviour
{
    private enum difficultyState
    {
        easy, medium, hard, expert
    }

    [SerializeField]
    [Tooltip("amount of time in between each spawn")]
    private float baseSpawnTime = 3;
    private float spawnTime;

    private float startingSpeed;
    private float timer;
    private float spawnHeight = -102;
    private float lastSpawnTime;

    [SerializeField]
    private float mediumTime = 20f, hardTime = 50f, expertTime = 75f;
    private difficultyState state;

    [SerializeField]
    private GameObject beamHorizontal, beamVertical;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        lastSpawnTime = 0;
        spawnTime = baseSpawnTime;
        startingSpeed = BeamMovement.speed; //bee movie . speed
        state = difficultyState.easy;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (BeamMovement.speed < BeamMovement.maxSpeed)
        {
            BeamMovement.speed += Time.deltaTime / 2;
        }
        spawnTime = baseSpawnTime / (BeamMovement.speed / startingSpeed);

        if (timer >= lastSpawnTime + spawnTime)
        {
            lastSpawnTime = timer;
            SpawnRandomBeamLayer();
        }

        if (timer >= mediumTime && timer < hardTime)
        {
            Debug.Log("Medium");
            state = difficultyState.medium;
        }
        else if (timer >= hardTime && timer < expertTime)
        {
            Debug.Log("hard");
            state = difficultyState.hard;
        }
        else if (timer >= expertTime)
        {
            Debug.Log("expert");
            state = difficultyState.expert;
        }
        else
        {
            Debug.Log("easy");
            state = difficultyState.easy;
        }

        
    }

    private GameObject PickBeam()
    {
        int randomNumber = Random.Range(0, 2);
        if (randomNumber == 0)
        {
            return beamHorizontal;
        }
        else if (randomNumber == 1) 
        {
            return beamVertical;
        }
        return null; //never should hit anything other than 1 or 0
    }

    private Vector3 SpawnPoint(GameObject beam)
    {
        if (beam.transform.rotation.eulerAngles.y == 90f) //vertical 5-19
        {
            Debug.Log("vertical");
            float vSpawn = Random.Range(5f, 19f);
            return new Vector3(vSpawn, spawnHeight, beam.transform.localPosition.z);
        }
        else if (beam.transform.rotation.eulerAngles.y == 0) //horizontal -5--19
        {
            Debug.Log("horizontal");
            float hSpawn = Random.Range(-19f, -5f);
            return new Vector3(beam.transform.localPosition.x, spawnHeight, hSpawn);
        }
        Debug.Log($"NONONONONOONO{beam.transform.rotation.eulerAngles.y}");
        return beam.transform.position; //never should hit anything other than 0 or 90
    }

    private void SpawnRandomBeam()
    {
        GameObject beam = PickBeam();
        Instantiate(beam, SpawnPoint(beam), beam.transform.rotation);
    }

    private void SpawnRandomBeamLayer()
    { 
        switch (state)
        {
            case difficultyState.easy:
                SpawnRandomBeam();
                break;
            case difficultyState.medium:
                SpawnRandomBeam();
                SpawnRandomBeam();
                break;
            case difficultyState.hard:
                SpawnRandomBeam();
                SpawnRandomBeam();
                SpawnRandomBeam();
                break;
            case difficultyState.expert:
                SpawnRandomBeam();
                SpawnRandomBeam();
                SpawnRandomBeam();
                SpawnRandomBeam();
                break;
            default:
                SpawnRandomBeam();
                break;
        }
    }
}
