using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [HideInInspector] public bool obstruct;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!obstruct)
        {
            PortalControl._instance.fadeAnim.Play("FadeOut");
            if (gameObject == PortalControl._instance.InteriorPortal.gameObject)
            {
                StartCoroutine(PortalControl._instance.TeleportToOrange());
            }
            else if (gameObject == PortalControl._instance.BuildingPortal.gameObject)
            {
                StartCoroutine(PortalControl._instance.TeleportToBlue());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (obstruct)
        {
            
            if (gameObject.name == "BuildingPortal")
            {
                PortalControl._instance.BuildingTriggerOn();
            }
            else if (gameObject.name == "InteriorPortal")
            {
                PortalControl._instance.InteriorTriggerOn();
            }
        }
    }
}
