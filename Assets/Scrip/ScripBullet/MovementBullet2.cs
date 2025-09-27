using Interfaces;
using UnityEngine;

public class MovementBullet2 : MovementBullet
{
    public override void OnCollisionEnter(Collision collision)
    {
        IParalizable paralizable = collision.gameObject.GetComponent<IParalizable>();
        if (paralizable != null)
        {
            paralizable.Paralize();
            Destroy(gameObject);
        }
    }
}
