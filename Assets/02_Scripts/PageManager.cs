using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{

    public Button p1On;
    public Button p2On;

    public GameObject p1;
    public GameObject p2;

    private void Start()
    {
        p1On.onClick.AddListener(() =>
        {
            p1.SetActive(true);
            p2.SetActive(false);
        });

        p2On.onClick.AddListener(() =>
        {
            p2.SetActive(true);
            p1.SetActive(false);
        });
    }
}
