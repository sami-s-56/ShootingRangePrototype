using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    List<GameObject> bullets;
    
    int c = 0;

   

    public void SetBullets(int cap)
    {
        print(cap);
        for(int i=0; i<cap; i++)
        {
            GameObject b = GameObject.Instantiate(bulletPrefab);
            b.transform.SetParent(transform);
        }

        bullets = new List<GameObject>(GameObject.FindGameObjectsWithTag("Bullet"));
        print(bullets.Count);

        foreach (var item in bullets)
        {
            item.GetComponent<MeshRenderer>().enabled = false;
        }

    }

    public void Reload()
    {
        c = 0;
        foreach (var item in bullets)
        {
            item.GetComponent<MeshRenderer>().enabled = false;
            item.GetComponent<Rigidbody>().isKinematic = true;
        }
        
    }

    public GameObject GetBullet()
    { 
        if (c==30)
        {
            return null;
        }
        else
        {
            GameObject bullet = bullets[c++];
            //StartCoroutine(ResetBullet(c++));
            return bullet;
        }
        
    }

    //IEnumerator ResetBullet(int x)
    //{
        
    //}

}
