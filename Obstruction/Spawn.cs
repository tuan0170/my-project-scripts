using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    [SerializeField]private GameObject obstacle;

    [SerializeField]private Vector3 positionStartSpwan = new Vector3(-3.5f,8f,35f);
    [SerializeField]private Vector3 positionEndSpwan = new Vector3 (3.2f,8f,35f );
    [SerializeField]private bool takingAway = false;
    public int spawnIndex = 2;
    private void Update()
    {
        if(!takingAway)
        {
            StartCoroutine(SpawnObstacleInSeconds());
        }
        
    }

    IEnumerator SpawnObstacleInSeconds()
    {
        takingAway = true;
        yield return new WaitForSeconds(spawnIndex);
        SpawnObstacle();
        takingAway = false;
    }
    private void SpawnObstacle()
    {
        Vector3 position = new Vector3(Random.Range(positionStartSpwan.x,positionEndSpwan.x),
                                        Random.Range(positionStartSpwan.y,positionEndSpwan.y),
                                        Random.Range(positionStartSpwan.z,positionEndSpwan.z));
        Instantiate(obstacle, position, Quaternion.identity);
    }

    
}
