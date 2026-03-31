using UnityEngine;

public class MapStairs : MonoBehaviour
{
    public GameObject groundFloor;
    public GameObject firstFloor;
    public GameObject basement;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        basement.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GroundFloorStairs"))
        {
            playerTransform.position = new Vector3(117, -12, playerTransform.position.z);
        }
        if (collision.gameObject.CompareTag("FirstFloorStairs"))
        {
            playerTransform.position = new Vector3(9, -7, playerTransform.position.z);
        }
        if(collision.gameObject.CompareTag("BasementStairs"))
        {
            basement.SetActive(true);
            playerTransform.position = new Vector3(19, 42, playerTransform.position.z);
        }
        if(collision.gameObject.CompareTag("BasementLadder"))
        {
            playerTransform.position = new Vector3(20, -11, playerTransform.position.z);
            basement.SetActive(false);
        }
    }
}
