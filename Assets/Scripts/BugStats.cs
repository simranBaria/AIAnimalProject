using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BugStats : MonoBehaviour
{
    public TextMeshProUGUI bugsEatenText, bugsInWorldText, totalBugsSpawnedText;
    static int bugsEaten = 0, bugsInWorld = 0, totalBugsSpawned = 0;

    // Update is called once per frame
    void Update()
    {
        bugsEatenText.text = $"Bugs Eaten: {bugsEaten}";
        bugsInWorldText.text = $"Bugs in World: {bugsInWorld}";
        totalBugsSpawnedText.text = $"Total Bugs Spawned: {totalBugsSpawned}";
        
    }

    public static void AteBug()
    {
        bugsEaten++;
        bugsInWorld--;
        
    }

    public static void SpawnedBug()
    {
        bugsInWorld++;
        totalBugsSpawned++;
    }
}
