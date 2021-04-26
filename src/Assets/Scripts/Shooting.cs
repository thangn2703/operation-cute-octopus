using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float bulletSpeed = 50;
    public int reloadTime = 5;
    private bool isReloading = false;

    Vector3 lookDirection;
    float lookAngle;

    public int maxInk;
    public int currentInk;

    public Text inkText;

    void Start()
    {
        currentInk = 3;
    }


    void Update()
    {
        lookDirection = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.eulerAngles = new Vector3(0, 0, lookAngle);

        if (isReloading)
        {
            return;
        }

        if (currentInk <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetMouseButtonDown(0) && currentInk > 0)
        {
            Shoot();
            UpdateInk(-1);
        }
    }

    void Shoot()
    {
            GameObject bulletClone = Instantiate(bullet);
            bulletClone.transform.position = firePoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
    }

    void UpdateInk(int ink)
    {
        currentInk += ink;
        if (currentInk > maxInk)
        {
            currentInk = maxInk;
        }
        inkText.text = currentInk.ToString();
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentInk = maxInk;
        inkText.text = currentInk.ToString();
        isReloading = false;
    }
}