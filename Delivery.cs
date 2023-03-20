using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);


    bool hasPackage = false;
    [SerializeField] float delay = 1f;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Thats hurt!");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Package picked up!");
            hasPackage = true;
            Destroy(collision.gameObject, delay);
            spriteRenderer.color = hasPackageColor;
        }

        if (collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Delivered package");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }


    }

}
