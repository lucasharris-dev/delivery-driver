using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay = 0.1f;
    [SerializeField] Color32 noPackageColor = new Color32 (255,255,255,255);
    
    Color32 packageColor = new Color32 (255,255,255,255);
    bool bHasPackage = false;
    string packageTag = "";

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("ouch");
    }

    // I added the color changing to the color of the package (was a set color in tutorial),
      // the package only being delivered to the corresponding customer (checks via tags),
      // and made the if statements check the parents' tags (to determine if they are customers/packages)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Orange" || other.tag == "Blue" || other.tag == "Purple")
        {
            string colliderTag = other.GetComponentInParent<Canvas>().tag;
            SpriteRenderer colliderSpriteRenderer = other.GetComponent<SpriteRenderer>();
            if (colliderTag == "Package" && !bHasPackage)
            {
                Debug.Log("package picked up");
                packageColor = colliderSpriteRenderer.color;
                bHasPackage = true;
                packageTag = other.tag;
                Destroy(other.gameObject, destroyDelay);
                spriteRenderer.color = packageColor;
            }
            else if (colliderTag == "Customer" && bHasPackage && (packageTag == other.tag))
            {
                Debug.Log("package delivered");
                bHasPackage = false;
                spriteRenderer.color = noPackageColor;
            }
        }
    }
}
