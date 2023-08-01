using UnityEngine;

public class ScrollLimitController : MonoBehaviour
{
    [SerializeField] private RectTransform contentRect;
    [SerializeField] private RectTransform[] imageRects;

    private void Awake()
    {
        contentRect = GetComponent<RectTransform>();
        imageRects = contentRect.GetComponentsInChildren<RectTransform>();
    }

    private void LateUpdate()
    {
        foreach (RectTransform imageRect in imageRects)
        {
            Vector3 position = imageRect.localPosition;
            Vector3 minPosition = contentRect.rect.min - imageRect.rect.min;
            Vector3 maxPosition = contentRect.rect.max - imageRect.rect.max;

            position.x = Mathf.Clamp(position.x, minPosition.x, maxPosition.x);
            position.y = Mathf.Clamp(position.y, minPosition.y, maxPosition.y);

            imageRect.localPosition = position;
        }
    }
}
