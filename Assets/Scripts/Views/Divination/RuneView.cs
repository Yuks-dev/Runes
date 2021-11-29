using UnityEngine;

public class RuneView : Element
{
    public RuneAnimationComponent animationComponent;
    private Vector3 screenPoint;
    private Rigidbody rb;
    private MeshCollider mc;

    private void Start()
    {
        screenPoint = gameObject.transform.localPosition;
        rb = GetComponent<Rigidbody>();
        mc = GetComponent<MeshCollider>();
    }

    private void OnMouseDrag()
    {
        if (app.controller.canTake)
        {
            Vector3 down = new Vector3(transform.position.x, 3f, transform.position.z);
            Vector3 drag = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            screenPoint = Camera.main.WorldToScreenPoint(down);
            transform.position = Camera.main.ScreenToWorldPoint(drag);
        }  
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("RunePlace") && !app.controller.runeLaunch)
        {
            app.aux.PortalSound();
            app.controller.canTake = false;
            app.controller.runeLaunch = true;

            GameObject runeSign = app.controller.runesOnScene[app.controller.runeCount].RunePrefab;
            animationComponent.RuneAnimation(runeSign);
            app.controller.MakeAvailable();
            Freezer();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        animationComponent.blow.GetComponent<ParticleSystem>().Play();
        app.aux.RuneSound();
    }

    private void Freezer()
    {
        rb.isKinematic = true;
        rb.freezeRotation = true;
        mc.enabled = false;
    }
}
