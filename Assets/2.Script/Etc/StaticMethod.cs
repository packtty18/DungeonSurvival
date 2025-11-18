using UnityEngine;

public class StaticMethod : MonoBehaviour
{
    public static T WeightedRandom<T>(T[] targets, float[] weights)
    {
        float totalWeight = 0f;
        foreach (float w in weights)
        {
            totalWeight += w;
        }


        float randomValue = Random.Range(0f, totalWeight);

        float cumulateSum = 0f;
        int selectedIndex = 0;

        for (int i = 0; i < weights.Length; i++)
        {
            cumulateSum += weights[i];
            if (randomValue <= cumulateSum)
            {
                selectedIndex = i;
                break;
            }
        }

        return targets[selectedIndex];
    }
}
