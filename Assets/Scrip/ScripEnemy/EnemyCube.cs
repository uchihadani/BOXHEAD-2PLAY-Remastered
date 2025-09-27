using UnityEngine;

public class EnemyCube : Enemy, IDamageable
{
    public override void Atacar(MovementPlayer player)
    {
        int DobleDaño = daño * 2;
        player.PlayerDied(DobleDaño);
    }

    public void GetDamage()
    {
        EnemyDie();
        if (vida <= 0)
        {
            ScoreManager.Instance.AddPoint(10);
        }
    }

}
