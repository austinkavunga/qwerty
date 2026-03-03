using UnityEngine;

public class MapStairs : MonoBehaviour
{
    public GameObject GroundFloor;
    public GameObject TopFloor;
    public GameObject GroundFloorStairs;
    public GameObject TopFloorStairs;
    private Transform playerTransform;

    void Start()
    {
        GroundFloor.SetActive(true);
        GroundFloorStairs.SetActive(true);

        TopFloor.SetActive(false);
        TopFloorStairs.SetActive(false);

        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        var ahhh = GroundFloorStairs.GetComponent<EdgeCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GroundFloorStairs"))
        {
            GroundFloor.SetActive(false);
            GroundFloorStairs.SetActive(false);
            TopFloor.SetActive(true);
            TopFloorStairs.SetActive(true);
            playerTransform.position = new Vector3(9, -12, playerTransform.position.z);
        }
        if (collision.gameObject.CompareTag("FirstFloorStairs"))
        {
            TopFloor.SetActive(false);
            TopFloorStairs.SetActive(false);
            GroundFloor.SetActive(true);
            GroundFloorStairs.SetActive(true);
            playerTransform.position = new Vector3(9, -7, playerTransform.position.z);
        }
    }
}
