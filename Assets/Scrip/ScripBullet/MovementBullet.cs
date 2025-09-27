using Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementBullet : MonoBehaviour
{
    Rigidbody bulletRB;

    [SerializeField] float power = 10f;
    [SerializeField] float lifeTime = 4f;

    private float time = 0f;

    void Start()
    {
        bulletRB = GetComponent<Rigidbody>();
        bulletRB.AddForce(this.transform.forward * power, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time > lifeTime) 
        {
            Destroy(this.gameObject);
        }
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.GetDamage();
            Destroy(gameObject);
        }
    }

}
