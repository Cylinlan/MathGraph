using UnityEngine;
using static UnityEngine.Mathf;

public class FunctionLibrary : MonoBehaviour
{
 public static Vector3 Wave(float u, float v, float t)
 {
  Vector3 p;
  p.x = u;
  p.y = Sin(PI * (u + v + t));
  p.z = v;
  return p;
 }

 public static Vector3 MultiWave(float u, float v, float t)
 {
  //两个正弦波的总和
  Vector3 p;
  p.x = u;
  p.y = Sin(PI * (u + 0.5f * t));
  p.y += 0.5f * Sin(2f * PI * (v + t));
  p.y += Sin(PI * (u + v + 0.25f * t));
  p.y *= 1f / 2.5f;
  p.z = v;
  return p;
 }

 //涟漪
 public static Vector3 Ripple(float u, float v, float t)
 {
  float d = Sqrt(u * u + v * v);
  Vector3 p;
  p.x = u;
  p.y = Sin(PI * (4f * d - t));
  p.y /= 1f + 10f * d;
  p.z = v;
  return p;
 }

 public static Vector3 Sphere1(float u, float v, float t)
 {
  float r = Cos(0.5f * PI * v);
  Vector3 p;
  p.x = r * Sin(PI * u);
  //p.y = v;
  p.y = Sin(PI * 0.5f * v);
  p.z = r * Cos(PI * u);
  return p;
 }
 /// <summary>
 /// 缩放球
 /// </summary>
 /// <param name="u"></param>
 /// <param name="v"></param>
 /// <param name="t"></param>
 /// <returns></returns>
 public static Vector3 Sphere2(float u, float v, float t)
 {
  float r = 0.5f + 0.5f * Sin(PI * t);
  float s = r * Cos(0.5f * PI * v);
  Vector3 p;
  p.x = s * Sin(PI * u);
  p.y = r * Sin(0.5f * PI * v);
  p.z = s * Cos(PI * u);
  return p;
 }
 /// <summary>
 /// 垂直带球
 /// </summary>
 /// <param name="u"></param>
 /// <param name="v"></param>
 /// <param name="t"></param>
 /// <returns></returns>
 public static Vector3 Sphere3(float u, float v, float t)
 {
  float r = 0.9f + 0.1f * Sin(8f * PI * u);

  float s = r * Cos(0.5f * PI * v);
  Vector3 p;
  p.x = s * Sin(PI * u);
  p.y = r * Sin(0.5f * PI * v);
  p.z = s * Cos(PI * u);
  return p;
 }
 public static Vector3 Sphere4(float u, float v, float t)
 {
  float r = 0.9f + 0.1f * Sin(8f * PI * v);

  float s = r * Cos(0.5f * PI * v);
  Vector3 p;
  p.x = s * Sin(PI * u);
  p.y = r * Sin(0.5f * PI * v);
  p.z = s * Cos(PI * u);
  return p;
 }
 public static Vector3 Sphere5(float u, float v, float t)
 {
  float r = 0.9f + 0.1f * Sin(PI * (6f * u + 4f * v + t));

  float s = r * Cos(0.5f * PI * v);
  Vector3 p;
  p.x = s * Sin(PI * u);
  p.y = r * Sin(0.5f * PI * v);
  p.z = s * Cos(PI * u);
  return p;
 }

 /// <summary>
 /// 环形曲面
 /// </summary>
 /// <param name="u"></param>
 /// <param name="v"></param>
 /// <param name="t"></param>
 /// <returns></returns>
 public static Vector3 Torus(float u, float v, float t)
 {
  float r = 1f;
  float s = 0.5f + r * Cos(0.5f * PI * v);
  Vector3 p;
  p.x = s * Sin(PI * u);
  p.y = r * Sin(0.5f * PI * v);
  p.z = s * Cos(PI * u);
  return p;
 }

 public static Vector3 Torus2(float u, float v, float t)
 {
  float r = 1f;
  float s = 0.5f + r * Cos(PI * v);
  Vector3 p;
  p.x = s * Sin(PI * u);
  p.y = r * Sin(PI * v);
  p.z = s * Cos(PI * u);
  return p;
 }

 public static Vector3 Torus3(float u, float v, float t)
 {
  float r1 = 1f;
  float r2 = 0.25f;
  float s = r1 + r2 * Cos(PI * v);
  Vector3 p;
  p.x = s * Sin(PI * u);
  p.y = r2 * Sin(PI * v);
  p.z = s * Cos(PI * u);
  return p;
 }

 public static Vector3 Torus4(float u, float v, float t)
 {
  float r1 = 0.7f + 0.1f * Sin(PI * (6f * u + 0.5f * t));
  float r2 = 0.15f + 0.05f * Sin(PI * (8f * u + 4f * v + 2f * t));
  float s = r1 + r2 * Cos(PI * v);
  Vector3 p;
  p.x = s * Sin(PI * u);
  p.y = r2 * Sin(PI * v);
  p.z = s * Cos(PI * u);
  return p;
 }
 //委托获取引用
 public delegate Vector3 Function(float u, float v, float t);
 //[枚举]
 public enum FunctionName
 {
  Wave, MultiWave, Ripple,
  球, 收缩球, 垂直带球, 水平带球, 扭曲球,
  Torus, Torus2, 圆环, 扭曲圆环
 }
 //[数组]
 static Function[] functions =
 {
    Wave, MultiWave, Ripple,
 Sphere1, Sphere2, Sphere3, Sphere4, Sphere5,
 Torus,Torus2,Torus3,Torus4
 };

 public static Function GetFunction(FunctionName name)
 {
  //return functions[index];
  return functions[(int)name];

 }
}


