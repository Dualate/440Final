using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class Pistol : MonoBehaviour
{
    public GameObject BulletPrefab;
    public AudioClip gunshot;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => Shoot());
    }

    public void Shoot()
    {
        Instantiate(BulletPrefab, transform.position, transform.rotation);
        source.PlayOneShot(gunshot);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
