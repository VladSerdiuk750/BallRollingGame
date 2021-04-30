using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Field : MonoBehaviour
{
    [SerializeField] private int numberOfObstacle;

    [SerializeField] private int numberOfBonuses;

    [SerializeField] private int width;

    [SerializeField] private GameObject obstacle;

    [SerializeField] private GameObject bonusPrefab;
    
    public void GenerateObstacle(int numberOfFields)
    {
        for (int i = 0; i < numberOfObstacle; i++)
        {
            int size = Random.Range(1, 4) * 2;
            int xPosition;
            if (numberOfFields == 0)
            {
                xPosition = Random.Range(size + 2, (12 + ((numberOfFields + 1) * width) - size));
            }
            else
            {
                xPosition = Random.Range(12 + (numberOfFields * width) + size + 2, (12 + ((numberOfFields + 1) * width) - size));
            }
            int zPosition = Random.Range(0, 4);
            if (zPosition == 0)
                zPosition = -4;
            if (zPosition == 1)
                zPosition = -2;
            if (zPosition == 2)
                zPosition = 0;
            if (zPosition == 3)
                zPosition = 2;
            var newObstacle = Instantiate(obstacle, gameObject.transform);
            newObstacle.transform.position = new Vector3(xPosition, 1, zPosition);
            newObstacle.transform.rotation = Quaternion.identity;
            var newObstacleScale =
                new Vector3(size, newObstacle.transform.localScale.y, newObstacle.transform.localScale.z / 2);
            newObstacle.transform.localScale = newObstacleScale;
        }
    }

    public void GenerateBonus(int numberOfFields)
    {
        for (int i = 0; i < numberOfBonuses; i++)
        {
            int xPosition;
            if (numberOfFields == 0)
            {
                xPosition = Random.Range(3, (12 + ((numberOfFields + 1) * width) - 1));
            }
            else
            {
                xPosition = Random.Range(12 + (numberOfFields * width) + 3, (12 + ((numberOfFields + 1) * width) - 1));
            }
            int zPosition = Random.Range(0, 4);
            if (zPosition == 0)
                zPosition = -4;
            if (zPosition == 1)
                zPosition = -2;
            if (zPosition == 2)
                zPosition = 0;
            if (zPosition == 3)
                zPosition = 2;

            var newBonus = Instantiate(bonusPrefab, gameObject.transform);
            newBonus.transform.position = new Vector3(xPosition, 1.5f, zPosition);
            newBonus.transform.rotation = Quaternion.identity;
            newBonus.transform.localScale = new Vector3(1, 1, 0.5f);
        }
    }
}
