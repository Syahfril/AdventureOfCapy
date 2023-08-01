using UnityEngine;

public class HorizontalScroll : MonoBehaviour
{
    public float scrollSpeed = 5f; // Adjust this value to change the scroll speed
    private RectTransform contentRectTransform;

    private void Awake()
    {
        contentRectTransform = transform.Find("Content").GetComponent<RectTransform>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 contentPosition = contentRectTransform.anchoredPosition;
        contentPosition.x += horizontalInput * scrollSpeed * Time.deltaTime;
        contentRectTransform.anchoredPosition = contentPosition;
    }
}
