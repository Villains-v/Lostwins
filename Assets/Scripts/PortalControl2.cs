using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControl2 : MonoBehaviour
{
    public static PortalControl2 _instance;

    public Transform player;
    public Collider2D orangePortal, bluePortal;

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
    }

    public IEnumerator TeleportToOrange()
    {
        yield return new WaitForSeconds(0.5f);
        player.position = orangePortal.transform.position;
        orangePortal.GetComponent<Portal2>().obstruct = true;
    }

    public IEnumerator TeleportToBlue()
    {
        yield return new WaitForSeconds(0.5f);
        player.position = bluePortal.transform.position;
        bluePortal.GetComponent<Portal2>().obstruct = true;
    }

    public void OrangeTriggerOn()
    {
        orangePortal.GetComponent<Portal2>().obstruct = false;
    }

    public void BlueTriggerOn()
    {
        bluePortal.GetComponent<Portal2>().obstruct = false;
    }
}
