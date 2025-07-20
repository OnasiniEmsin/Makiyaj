using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brushes : MonoBehaviour
{
    public Camera mainCamera;
    public Transform[] myTargets; // Точки, куда можно наносить (губы, щеки, веки и т.д.)
    public Transform defTransf, myhead; // defTransf — позиция по умолчанию для кисти, myhead — кончик кисти или помады
    public yasan yasan; // Скрипт, который переключает нужные спрайты (накрасить)
    public float paintDistance; // Расстояние между целью и кистью, при котором считается, что мы накрасили
    public Canvas canvas;
    bool isbrushing; // Флаг: сейчас происходит движение кисти или нет

    void Update()
    {
        if (isbrushing)
        {
            Vector2 inputPos;

            // 💻 Управление мышкой (в редакторе или на ПК)
            if (Application.isEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                if (Input.GetMouseButton(0))
                {
                    inputPos = Input.mousePosition;
                }
                else
                {
                    // Если кнопка не нажата — вернуть кисть в центр экрана
                    inputPos = new Vector2(Screen.width / 2, Screen.height / 2);
                }
            }
            // 📱 Управление с помощью касания на мобильных устройствах
            else if (Input.touchCount > 0)
            {
                inputPos = Input.GetTouch(0).position;
            }
            else return; // Нет ввода — выходим из метода

            Vector2 localPos;
            // Преобразуем координаты экрана в локальные координаты канваса
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                inputPos,
                null, // Камера не нужна в режиме Screen Space - Overlay
                out localPos
            );

            // 🔁 Проверяем, достаточно ли близко кисть к какому-либо элементу (например, к губам)
            for (int i = 0; i < myTargets.Length; i++)
            {
                float distance = Vector3.Distance(myhead.position, myTargets[i].position);

                if (distance < paintDistance)
                {
                    yasan.set(); // Активируем нужный макияж (меняем спрайт и т.д.)
                    isbrushing = false; // Прекращаем процесс рисования
                    transform.localPosition = defTransf.localPosition; // Возвращаем кисть в исходное положение
                    return;
                }
            }

            // 🖌 Перемещаем кисть (UI элемент) в новую позицию
            transform.localPosition = localPos;
        }
    }

    // Вызывается при выборе цвета или включении кисти
    public void setBrush()
    {
        isbrushing = true;
    }
}
