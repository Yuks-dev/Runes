using UnityEngine;

public class RuneView : Element
{
    public RuneAnimationComponent animationComponent;
    private GameObject runeSign;
    private Vector3 screenPoint;
    private Rigidbody rb;
    private MeshCollider mc;

    private void Start()
    {
        screenPoint = gameObject.transform.localPosition;
        rb = GetComponent<Rigidbody>();
        mc = GetComponent<MeshCollider>();
    }

    private void OnMouseExit() => rb.freezeRotation = false;

    private void OnMouseDown()
    {
        app.aux.RuneSound();
        transform.rotation = Quaternion.identity;
        rb.freezeRotation = true;
    }

    private void OnMouseDrag()
    {
        if (!app.controller.runeActive)
        {
            Vector3 down = new Vector3(transform.position.x, 3f, transform.position.z);
            Vector3 drag = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            screenPoint = Camera.main.WorldToScreenPoint(down);
            transform.position = Camera.main.ScreenToWorldPoint(drag);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RunePlace"))
        {
            runeSign = app.controller.runesOnScene[app.controller.runeCount].RunePrefab;
            app.controller.runeCount++;
            app.aux.PortalSound();

            Freezer();
            animationComponent.RuneAnimation(runeSign);
 
            app.controller.ui.DescriptionText(app.controller.runeCount);
            app.controller.MakeAvailable();
        }
        else
            app.aux.RuneSound();
    }

    private void Freezer()
    {
        app.controller.runeActive = true;
        rb.useGravity = false;
        rb.freezeRotation = true;
        mc.enabled = false;
    }
}
