using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    public Transform player;
    public LevelScript[] levels;
    LevelScript previousLevel;
    LevelScript currentLevel;
    LevelScript nextLevel;
    private Vector3 currentTop;
    private Vector3 currentBottom;
    private float distance = 30.0f;
    private float size;
    // Start is called before the first frame update
    void Start()
    {
        LevelScript newLevel = Instantiate(levels[0], Vector3.zero, Quaternion.identity);
        currentLevel = newLevel;
        currentTop = currentLevel.topProbe.transform.position;
        currentBottom = currentLevel.transform.position;
        size = currentBottom.y + currentTop.y;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnLevel();
    }
    private void SpawnLevel() 
    {
        if (Vector3.Distance(player.position, currentTop) < distance)
        {
            if (nextLevel == null)
            {
                LevelScript newLevel = Instantiate(levels[0], currentTop, Quaternion.identity);
                nextLevel = newLevel;

                if (previousLevel != null)
                {
                    Destroy(previousLevel.gameObject);
                }
            }

            if (player.position.y > currentTop.y & nextLevel != null)
            {
                previousLevel = currentLevel;
                currentLevel = nextLevel;
                nextLevel = null;
                currentTop = currentLevel.topProbe.transform.position;
                currentBottom = currentLevel.transform.position;
            }
        }
        if (Vector3.Distance(player.position, currentBottom) < distance)
        {
            if (previousLevel == null)
            {
                LevelScript newLevel = Instantiate(levels[0], currentBottom - Vector3.up * size, Quaternion.identity);
                previousLevel = newLevel;

                if (nextLevel != null)
                {
                    Destroy(nextLevel.gameObject);
                }
            }
            if (player.position.y < currentBottom.y & previousLevel != null)
            {
                nextLevel = currentLevel;
                currentLevel = previousLevel;
                previousLevel = null;
                currentTop = currentLevel.topProbe.transform.position;
                currentBottom = currentLevel.transform.position;
            }
        }
    }
}
