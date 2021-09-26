using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Rigidbody2D enterRigidbody;
    private float enterVelocity, exitVelocity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enterRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
        enterVelocity = enterRigidbody.velocity.y;

        if (gameObject.name == "BluePortal")
        {
            PortalControl.portalControlInstance.DisableCollider("orange");
            PortalControl.portalControlInstance.CreateClone("atorange");
        }
        else if (gameObject.name == "OrangePortal")
        {
            PortalControl.portalControlInstance.DisableCollider("blue");
            PortalControl.portalControlInstance.CreateClone("atblue");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        exitVelocity = enterRigidbody.velocity.y;

        if (enterVelocity != exitVelocity)
        {
            Destroy(GameObject.Find("Clone"));
        }
        else if(gameObject.name != "Clone")
        {
            Destroy(collision.gameObject);
            PortalControl.portalControlInstance.EnableColliders();
            GameObject.Find("Clone").name = "Character";
        }
    }
}
