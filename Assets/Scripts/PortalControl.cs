using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControl : MonoBehaviour
{
    public static PortalControl portalControlInstance;
    public Transform player;
    public Transform bluePortalSpawnPoint, orangePortalSpawnPoint;
    public BoxCollider2D bluePortalCollider, orangePortalcollider;

    public GameObject clone;

    private void Start()
    {
        portalControlInstance = this;
    }

    public void CreateClone(string whereToCreate)
    {
        if (whereToCreate == "atblue")
        {
            var instantiatedClone = Instantiate(clone, bluePortalSpawnPoint.position, Quaternion.identity);
            instantiatedClone.gameObject.name = "Clone";
        }
        else if(whereToCreate == "atorange")
        {
            var instantiatedClone = Instantiate(clone, orangePortalSpawnPoint.position, Quaternion.identity);
            instantiatedClone.gameObject.name = "Clone";
        }
    }

    public void NewPos(string whereToCreate)
    {
        if (whereToCreate == "atblue")
        {
            player.position = bluePortalSpawnPoint.position;
        }
        else if (whereToCreate == "atorange")
        {
            player.position = orangePortalSpawnPoint.position;
        }
    }

    public void DisableCollider(string ColliderToDisable)
    {
        if(ColliderToDisable == "orange")
        {
            orangePortalcollider.enabled = false;
        }
        else if(ColliderToDisable == "blue")
        {
            bluePortalCollider.enabled = false;
        }
    }

    public void EnableColliders()
    {
        orangePortalcollider.enabled = true;
        bluePortalCollider.enabled = true;
    }
}
