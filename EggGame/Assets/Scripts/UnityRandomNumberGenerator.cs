using UnityEngine;

public class UnityRandomNumberGenerator : IRandomNumberGenerator
{
    public int Generate(int maxRange)
    {
        return Random.Range(0, maxRange);
    }
}


public interface IRandomNumberGenerator
{
    int Generate(int maxRange);
}
