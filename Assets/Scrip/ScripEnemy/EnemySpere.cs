using Interfaces;
using UnityEngine;

public class EnemySpere : Enemy, IParalizable
{
    public void Paralize()
    {
        speed = 0;
        Invoke(nameof(Desparalizar), 5); 
    }

    public void Desparalizar()
    {
        speed = 3;
    }
    public void GetDamage()
    {
        EnemyDie();
        if (vida <= 0)
        {
            ScoreManager.Instance.AddPoint(20);
        }
    }
}
