using UnityEngine;
using DG.Tweening;

public class ObjectView : Element
{
    public GameObject shining;
    public GameObject magicSmoke;

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

    private void OnMouseExit()
    {
        rb.freezeRotation = false;
    }

    private void OnMouseDown()
    {
        transform.rotation = Quaternion.identity;
        rb.freezeRotation = true;
    }

    private void OnMouseDrag()
    {
        if(!app.controller.runeActive)
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

            Freezer();
            Spawner(magicSmoke);
            RuneAnimation();
            app.controller.ui.DescriptionText(app.controller.runeCount);
            app.controller.MakeAvailable();
        }
    }

    private void Freezer()
    {
        app.controller.runeActive = true;
        rb.useGravity = false;
        rb.freezeRotation = true;
        mc.enabled = false;
    }

    private void RuneAnimation()
    {
        Sequence showRune = DOTween.Sequence();
        showRune.PrependInterval(0.5f);

        // Rune goes up
        showRune.Append(transform.DOMove(new Vector3(0, 4, -1), 1).SetEase(Ease.OutBounce)); 
        showRune.AppendCallback(() => { app.cameraController.RuneCameraView(); });

        // Rune rotate
        showRune.Join(transform.DORotate(new Vector3(0, 0, 180), 2).SetEase(Ease.InElastic)); 
        showRune.AppendCallback(() => { RuneExpalain(); });
        showRune.AppendInterval(3);

        // Rune fly away
        showRune.AppendCallback(() => { RuneAway(); });
        showRune.Append(transform.DOMove(new Vector3(3, 8, -7), 2));
        showRune.AppendCallback(() => { Destroy(gameObject); app.controller.ui.SetState(); });
    }

    // For RuneAnimation
    private void RuneExpalain()
    {
        Spawner(runeSign);
        Spawner(shining);
        app.controller.ui.ShowDescription();
        app.controller.ui.runeName.gameObject.SetActive(true);
    }

    private void RuneAway()
    {
        app.controller.ui.PrepareNextRune();
        app.cameraController.GameCameraView();
        app.controller.runeActive = false;
    }

    private void Spawner(GameObject obj) // Component
    {
        Instantiate(obj, transform.position, obj.transform.rotation, gameObject.transform);
    }
}
