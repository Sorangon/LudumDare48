using CoreDev.Utility;
using UnityEngine;

public class DestroyOutOfView : MonoBehaviour {
    void LateUpdate() {
        Camera cam = MainCameraBuffer.Get();
        Vector2 screenPos = cam.WorldToScreenPoint(transform.position);
        //float tolerancePixelDistance = cam.WorldToScreenPoint(cam.transform.position + Vector3.right * toleranceDistance).x;
        //tolerancePixelDistance -= cam.pixelRect.width * 0.5f;
        if (!cam.pixelRect.Contains(screenPos)){
            Destroy(gameObject);
        }
    }

    //private bool RectContains(Vector2 screenPos, Rect rect, float tolerancePixelDistance) {
    //    if (screenPos.x + tolerancePixelDistance < rect.x || screenPos.y + tolerancePixelDistance < rect.y ||
    //        screenPos.x - tolerancePixelDistance > rect.x + rect.width || screenPos.y - tolerancePixelDistance < rect.y + rect.height) {
    //        return false;
    //    } else {
    //        return true;
    //    }
    //}
}
