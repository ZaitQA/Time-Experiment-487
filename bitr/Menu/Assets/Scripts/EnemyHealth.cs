using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float startingHealth = 100;            // The amount of health the enemy starts the game with.
    public float currentHealth;                   // The current health the enemy has.
    public float sinkSpeed = 2.5f;
    private GameObject player;
    private float _playerAttack;
    public bool HaveaKey;
    public GameObject key;


    private bool isgun;
    BoxCollider boxCollider;            // Reference to the capsule collider.
    bool isDead;                                // Whether the enemy is dead.
    bool isSinking;                             // Whether the enemy has started sinking through the floor.
    //public AudioClip 
    public Slider health;


    void Start()
    {
        // Setting up the references.
        boxCollider = GetComponent <BoxCollider> ();

        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;

        
        
    }

    void Update ()
    {
        health.value = currentHealth / startingHealth;
        player =  player = GameObject.FindGameObjectWithTag ("Player");
        _playerAttack = player.GetComponent<PlayerStat>().attack;
        if(currentHealth <= 0)
        {
            StartSinking();
            Death ();
         
        }
    }
[PunRPC]
    public void TakeDamage ()
    {
        currentHealth -= _playerAttack + 40;

    }

    private void OnTriggerEnter(Collider other)
    {
     
        if (other.tag == "shot")
        {
            PhotonView.Get(this).RPC("TakeDamage", PhotonTargets.All);
            Destroy(other.gameObject);
        }
        
    }

    void Death ()
    {
        // The enemy is dead.
        if (HaveaKey)
        {
            key.SetActive(true);
            key.transform.parent = null;
            key.SetActive(true);

        }
        isDead = true;
        health.gameObject.SetActive(false);
        GetComponent<EnemyMovement>().anim.SetBool("walk", false);
        GetComponent<EnemyMovement>().anim.SetBool("die", true);

        // Turn the collider into a trigger so shots can pass through it.
        boxCollider.isTrigger = true;
    }


    public void StartSinking ()
    {
        // Find and disable the Nav Mesh Agent.
        GetComponent <NavMeshAgent> ().enabled = false;

        // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
        GetComponent <Rigidbody> ().isKinematic = true;

        // The enemy should no sink.
        isSinking = true;

        // After 2 seconds destory the enemy.
        Destroy (gameObject, 4f);
    }
}