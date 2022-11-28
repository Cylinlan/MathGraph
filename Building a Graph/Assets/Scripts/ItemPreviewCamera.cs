using UnityEngine;
using static UnityEngine.GraphicsBuffer;

/// <summary>
/// 相机的运动形态
/// </summary>
public class ItemPreviewCamera : MonoBehaviour
{
 [SerializeField]
 GameObject Camera;
 [SerializeField]
 Transform car;

 [SerializeField,Range(1,10)]
 float Speed;

 private void Update()
 {
  Action();
 }

 void Action()
 {
  if (Input.GetKey(KeyCode.Space))
  {
   AotuRotate();
  }

  camerarotate();
  camerazoom();
 }


 private void AotuRotate()
 {
  Camera.transform.RotateAround(car.position, Vector3.up, Speed * Time.deltaTime); //摄像机围绕目标旋转
 }

 private void camerarotate() //摄像机围绕目标旋转操作
 {
  var mouse_x = Input.GetAxis("Mouse X");//获取鼠标X轴移动
  var mouse_y = -Input.GetAxis("Mouse Y");//获取鼠标Y轴移动


  if (Input.GetKey(KeyCode.Mouse1))
  {
   Camera.transform.Translate(Vector3.left * (mouse_x * 15f) * Time.deltaTime);
   Camera.transform.Translate(Vector3.up * (mouse_y * 15f) * Time.deltaTime);
  }

  if (Input.GetKey(KeyCode.Mouse0))
  {
   Camera.transform.RotateAround(car.position, Vector3.up, mouse_x * 5);
   Camera.transform.RotateAround(car.position, Camera.transform.right, mouse_y * 5);
  }
 }

 private void camerazoom() //摄像机滚轮缩放
 {
  if (Input.GetAxis("Mouse ScrollWheel") > 0)
   Camera.transform.Translate(Vector3.forward * 0.5f);


  if (Input.GetAxis("Mouse ScrollWheel") < 0)
   Camera.transform.Translate(Vector3.forward * -0.5f);
 }
}
