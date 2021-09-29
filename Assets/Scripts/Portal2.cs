using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2 : MonoBehaviour
{
    [HideInInspector] public bool obstruct;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!obstruct)
        {
            PortalControl2._instance.fadeAnim.Play("FadeOut");
            if (gameObject == PortalControl2._instance.InteriorPortal.gameObject)
            {
                StartCoroutine(PortalControl2._instance.TeleportToOrange());
            }
            else if (gameObject == PortalControl2._instance.BuildingPortal.gameObject)
            {
                StartCoroutine(PortalControl2._instance.TeleportToBlue());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (obstruct)
        {
            
            if (gameObject.name == "BuildingPortal")
            {
                PortalControl2._instance.BuildingTriggerOn();
            }
            else if (gameObject.name == "InteriorPortal")
            {
                PortalControl2._instance.InteriorTriggerOn();
            }
        }
    }
}
