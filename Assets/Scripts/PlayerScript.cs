using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    List<GameObject> weaponObject;
    Weapons playerWeapon;
    [SerializeField]
    WeaponsList wList;
    

    [SerializeField]
    private float movSpeed,rotSpeed,bulletForce;

    [SerializeField]
    private GameObject playerCamera;
    private float xRotation;

    [SerializeField]
    Transform bulletPosition;

    [SerializeField]
    GameObject BulletManager;
    GameObject bullet;

    GameObject actualPlayerWeapon;


    private void Start()
    {
        //Initialize Weapon Details
        //print(WeaponsList.selectedPos);
        actualPlayerWeapon = weaponObject[WeaponsList.selectedPos];
        actualPlayerWeapon.SetActive(true);
        playerWeapon = wList.weapons[WeaponsList.selectedPos];
        bulletPosition = actualPlayerWeapon.transform.Find("BulletPosition");
        BulletManager.GetComponent<BulletManager>().SetBullets(playerWeapon.capacity);
    }

    private void Update()
    {
        //PlayerMovements();
        if (Input.GetMouseButtonDown(0))
        {
            print("Firing");
            ProcessFire();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            FindObjectOfType<BulletManager>().Reload();
        }

        if (Input.GetMouseButtonDown(1))
        {
            actualPlayerWeapon.GetComponent<Animator>().SetBool("isAiming", true);
        }

        if (Input.GetMouseButtonUp(1))
        {
            actualPlayerWeapon.GetComponent<Animator>().SetBool("isAiming", false);
        }
    }

    private void ProcessFire()
    {
        SetBullet();
        if(bullet != null)
        {
            Vector3 randomVector = new Vector3(GetRecoil(), GetRecoil(), 0f);
            bullet.GetComponent<Rigidbody>().isKinematic = false;
            bullet.GetComponent<Rigidbody>().AddForce((transform.forward * bulletForce) + (transform.up * 75f));
            bullet.GetComponentInChildren<ParticleSystem>().Play();
            //playerCamera.transform.localEulerAngles = Vector3.up + randomVector;
            
        }
        else
        {
            print("NoBullet");
        }
    }

    float GetRecoil()
    {
        float rand;
        if (playerWeapon.recoil >= 10)
            rand = UnityEngine.Random.Range(-.075f, .075f);
        else if (playerWeapon.recoil >= 20)
            rand = UnityEngine.Random.Range(-.15f, .15f);
        else if (playerWeapon.recoil >= 20)
            rand = UnityEngine.Random.Range(-.2f, .2f);
        else 
            rand = 0;
        return rand;
    }

    private void SetBullet()
    {
        bullet = BulletManager.GetComponent<BulletManager>().GetBullet();
        if(bullet == null)
        {
            //Give Msg to reload
        }
        else
        {
            bullet.GetComponent<MeshRenderer>().enabled = true;
            bullet.transform.position = bulletPosition.position;
            //bullet.transform.rotation = bulletPosition.rotation;
            //bullet.transform.localEulerAngles += new Vector3(90, 0, 0);
        }
    }

    private void PlayerMovements()
    {
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * movSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * movSpeed * Time.deltaTime);

        xRotation -= Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -30, 50);
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime, 0));
    }
}
