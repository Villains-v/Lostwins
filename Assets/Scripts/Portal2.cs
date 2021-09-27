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
            if (gameObject == PortalControl2._instance.bluePortal.gameObject)
            {
                StartCoroutine(PortalControl2._instance.TeleportToOrange());
            }
            else if (gameObject == PortalControl2._instance.orangePortal.gameObject)
            {
                StartCoroutine(PortalControl2._instance.TeleportToBlue());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (obstruct)
        {
            if (gameObject.name == "BluePortal")
            {
                PortalControl2._instance.BlueTriggerOn();
            }
            else if (gameObject.name == "OrangePortal")
            {
                PortalControl2._instance.OrangeTriggerOn();
            }
        }
    }
}
