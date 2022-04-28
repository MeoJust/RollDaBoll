using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    Rigidbody _rb;
    Button _btn;
    ParticleSystem _particles;

    void Start()
    {
        _particles = GetComponentInChildren<ParticleSystem>();
        _particles.gameObject.SetActive(false);

        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;

        _btn = FindObjectOfType<Button>();
        _btn.onClick.AddListener(MakeMagicHapen);
    }

    void MakeMagicHapen()
    {
        _rb.isKinematic = false;
        _btn.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        _particles.gameObject.SetActive(true);
    }
}
