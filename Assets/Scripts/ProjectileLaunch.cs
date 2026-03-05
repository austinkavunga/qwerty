using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileLaunch : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;

    public float shootTime;
    public float shootCounter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shootCounter = shootTime;
    }

    // Update is called once per frame
    void Update()
    {
        shootCounter -= Time.deltaTime;
        if(Keyboard.current.pKey.wasPressedThisFrame && ShootCoolDown())
        {
            Shoot();
        }
    }
    private bool ShootCoolDown()
    {
        if(shootCounter <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Shoot()
    {
        Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
        shootCounter = shootTime;
    }
}
