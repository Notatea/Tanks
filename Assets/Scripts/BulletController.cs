using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float DestroyDelay = 0.1f;
    public float Damage = 1.0f;
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Blinking>().GetsDamage = true;


        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHPController>().HP -= Damage;
            DestroyProperly();
        }
    }

    void DestroyProperly()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().detectCollisions = false;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        Destroy(gameObject, DestroyDelay);
    }
}

