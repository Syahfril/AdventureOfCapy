using UnityEngine;

public class ImageSlider : MonoBehaviour
{
    [SerializeField] private RectTransform img1RectTransform;
    [SerializeField] private RectTransform img2RectTransform;
    [SerializeField] private float slideSpeed = 500f;

    private bool isSliding;
    private Vector2 img1TargetPos;
    private Vector2 img2TargetPos;

    private void Start()
    {
        img1TargetPos = img1RectTransform.anchoredPosition;
        img2TargetPos = img2RectTransform.anchoredPosition;
    }

    private void Update()
    {
        if (!isSliding)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SlideToImage2();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                SlideToImage1();
            }
        }
    }

    private void FixedUpdate()
    {
        if (isSliding)
        {
            img1RectTransform.anchoredPosition = Vector2.MoveTowards(img1RectTransform.anchoredPosition, img1TargetPos, slideSpeed * Time.fixedDeltaTime);
            img2RectTransform.anchoredPosition = Vector2.MoveTowards(img2RectTransform.anchoredPosition, img1TargetPos, slideSpeed * Time.fixedDeltaTime);

            if (img1RectTransform.anchoredPosition == img1TargetPos)
            {
                isSliding = false;
            }
        }
    }

    private void SlideToImage2()
    {
        isSliding = true;
        img1RectTransform.anchoredPosition = img2RectTransform.anchoredPosition;
    }

    private void SlideToImage1()
    {
        isSliding = true;
        img2RectTransform.anchoredPosition = img1RectTransform.anchoredPosition;
    }


}
