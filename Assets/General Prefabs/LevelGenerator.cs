using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
 
public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 15f;

    [SerializeField]
    private Transform levelPart_Start;

    [SerializeField]
    private List <Transform> EasyLevelParts;
    [SerializeField]
    private List <Transform> MediumLevelParts;
    [SerializeField]
    private List <Transform> HardLevelParts;

    [SerializeField]
    private Transform player;

    private enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
    
    private Vector3 lastEndPosition;
    private int levelPartsSpawned;

    private void Awake()
    {

        lastEndPosition = levelPart_Start.Find("EndPosition").position;
  
        int startingSpawnLevelParts = 1;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
        //Transform lastLevelPartTransform;
        //lastLevelPartTransform = SpawnLevelPart(levelPart_Start.Find("EndPosition").position);
        //lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("EndPosition").position);
        //lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("EndPosition").position);
        //lastLevelPartTransform = SpawnLevelPart(lastLevelPartTransform.Find("EndPosition").position);
    }
    private void Update()
    {
        if (Vector3.Distance(player.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }

    }
    private void SpawnLevelPart()
    {
        List <Transform> difficultLevelPartList;

        switch (GetDifficulty())
        {
            default: 
            case Difficulty.Easy: difficultLevelPartList = EasyLevelParts; break;
            case Difficulty.Medium: difficultLevelPartList = MediumLevelParts; break;
            case Difficulty.Hard: difficultLevelPartList = HardLevelParts; break;
        }

        Transform chosenLevelPart = difficultLevelPartList[Random.Range(0, difficultLevelPartList.Count)];

        //if(levelPartsSpawned > 5) chosenLevelPart = MediumLevelParts[Random.Range(0, levelPartList.Count)];

        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        levelPartsSpawned++;

    }
    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
      
    }
    private Difficulty GetDifficulty()
    {
        if(levelPartsSpawned >= 60) return Difficulty.Hard;
        if (levelPartsSpawned >= 30) return Difficulty.Medium;
        return Difficulty.Easy;
    }
}
