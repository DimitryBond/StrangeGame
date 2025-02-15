using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float minX, maxX, minY, maxY;

    private Vector2 currentTarget;
    public GameObject blood;

    private Animator camAnim;

    private void Start()
    {
        camAnim = Camera.main.GetComponent<Animator>();
        currentTarget = GetRandomPosition();
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, currentTarget) > 0.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }
        else
        {
            currentTarget = GetRandomPosition();
        }
    }

    Vector2 GetRandomPosition()
    {
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        return randomPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Altar")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.tag == "Trap")
        {
            camAnim.SetTrigger("shake");
            Destroy(collision.gameObject);
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}