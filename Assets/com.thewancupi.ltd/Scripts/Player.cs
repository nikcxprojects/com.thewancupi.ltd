using UnityEngine;

public class Player : MonoBehaviour
{
    private AudioSource SfxSource { get; set; }
    private Rigidbody2D Rigidbody { get; set; }

    private void Awake()
    {
        SfxSource = GameObject.Find("SFXSource").GetComponent<AudioSource>();
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDrag()
    {
        var mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Rigidbody.position = new Vector2(mPos.x, Rigidbody.position.y);
    }

    private void OnMouseUp()
    {
        Rigidbody.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.collider.CompareTag("ball"))
        {
            return;
        }

        if(SettingsManager.VibraEnbled)
        {
            Handheld.Vibrate();
        }

        SfxSource.Play();
        collision.rigidbody.AddForce(collision.transform.up * 2.0f, ForceMode2D.Impulse);
    }
}
