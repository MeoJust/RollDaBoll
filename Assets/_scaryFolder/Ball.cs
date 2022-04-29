using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Ball : MonoBehaviour
{
    Rigidbody _rb;
    bool _isWin;

    [SerializeField] ParticleSystem _particles;

    [SerializeField] Button _rollBTN;
    [SerializeField] Button _upBTN;
    [SerializeField] Button _downBTN;
    [SerializeField] Button _quitBTN;
    [SerializeField] Button _karmaBTN;

    [SerializeField] TextMeshProUGUI _titleTXT;
    [SerializeField] TextMeshProUGUI _winTXT;
    [SerializeField] TextMeshProUGUI _loseTXT;

    void Start()
    {
        _particles.gameObject.SetActive(false);

        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;

        _rollBTN.onClick.AddListener(MakeMagicHapen);
        _quitBTN.onClick.AddListener(QutiGame);
        _upBTN.onClick.AddListener(() => MoveDaBall(1f));
        _downBTN.onClick.AddListener(() => MoveDaBall(-1f));

        _winTXT.gameObject.SetActive(false);
        _loseTXT.gameObject.SetActive(false);
    }

    void MakeMagicHapen()
    {
        _rb.isKinematic = false;
        _rollBTN.gameObject.SetActive(false);
        _upBTN.gameObject.SetActive(false);
        _downBTN.gameObject.SetActive(false);
        _titleTXT.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        _particles.gameObject.SetActive(true);
        _isWin = true;
        StartCoroutine(LevelRestart());
        _winTXT.gameObject.SetActive(true);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Finish" && !_isWin)
        {
            StartCoroutine(LevelRestart());
            _loseTXT.gameObject.SetActive(true);
        }
    }

    IEnumerator LevelRestart()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("_level01");
    }

    void MoveDaBall(float where)
    {
        transform.Translate(0f, where, 0f);
        _titleTXT.gameObject.SetActive(false);
    }

    void QutiGame()
    {
        Application.Quit();
    }
}
