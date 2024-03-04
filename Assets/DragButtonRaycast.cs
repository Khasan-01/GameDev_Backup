using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableButtonRaycast : MonoBehaviour
{
    public RectTransform buttonRect; // Reference to the button's Rect Transform
    public Texture2D targetImage; // Reference to the single target image texture

    private Camera mainCamera; // Reference to the main camera
    private Vector2 imageDimensions; // Size of the target image in pixels

    private void Start()
    {
        mainCamera = Camera.main; // Assuming you have a main camera in the scene
        imageDimensions = new Vector2(targetImage.width, targetImage.height);
    }

    public void OnDrag(BaseEventData eventData)
    {
        Vector2 dragPosition = Input.mousePosition;
        Vector2 raycastOrigin = mainCamera.ScreenToWorldPoint(dragPosition); // Convert mouse position to world point

        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.zero); // Cast a ray towards camera

        if (hit.collider != null && hit.collider.gameObject.name == "TargetImage") // Check if hit the target image
        {
            Vector2 normalizedHit = hit.point / imageDimensions; // Get normalized hit position on image (0-1 range)

            // Define placement areas (boxes 1 and 2) based on normalized hit position (adjust conditions as needed)
            bool validPlacement1 = normalizedHit.x > 0.2f && normalizedHit.x < 0.5f && normalizedHit.y > 0.6f && normalizedHit.y < 0.8f;
            bool validPlacement2 = normalizedHit.x > 0.7f && normalizedHit.x < 0.9f && normalizedHit.y > 0.3f && normalizedHit.y < 0.5f;

            if (validPlacement1)
            {
                // Set button position to predefined location within placement area 1 (adjust as needed)
                buttonRect.anchoredPosition = new Vector2(100f, 150f);
            }
            else if (validPlacement2)
            {
                // Set button position to predefined location within placement area 2 (adjust as needed)
                buttonRect.anchoredPosition = new Vector2(300f, 200f);
            }
        }
    }
}
