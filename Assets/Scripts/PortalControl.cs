using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalControl : MonoBehaviour
{
    public static PortalControl _instance;

    public Transform player;
    public Collider2D BuildingPortal, InteriorPortal;
    public Animator fadeAnim;

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
    }

    public IEnumerator TeleportToOrange()
    {
        yield return new WaitForSeconds(0.5f);
        player.position = BuildingPortal.transform.position;
        BuildingPortal.GetComponent<Portal>().obstruct = true;
        PortalControl._instance.fadeAnim.Play("FadeIn");
    }

    public IEnumerator TeleportToBlue()
    {
        yield return new WaitForSeconds(0.5f);
        player.position = InteriorPortal.transform.position;
        InteriorPortal.GetComponent<Portal>().obstruct = true;
        PortalControl._instance.fadeAnim.Play("FadeIn");
    }

    public void InteriorTriggerOn()
    {
        BuildingPortal.GetComponent<Portal>().obstruct = false;
    }

    public void BuildingTriggerOn()
    {
        InteriorPortal.GetComponent<Portal>().obstruct = false;
    }
}
