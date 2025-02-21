using UnityEngine;
using TMPro;


public class BugStats : MonoBehaviour
{
    static int bugsEaten = 0, bugsInWorld = 0, totalBugsSpawned = 0;

    public TextMeshProUGUI bugsEatenText, bugsInWorldText, totalBugsSpawnedText;

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
