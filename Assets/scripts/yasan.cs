using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yasan : MonoBehaviour
{
    int rang = 0; // Номер выбранного цвета (индекс)

    public GameObject[] lablar, qovoqlar, yanoqlar;
    // Массивы с вариантами макияжа для: губ (lablar), век (qovoqlar), щек (yanoqlar)

    bool labni, qovoqni, yanoqni;
    // Флаги — какой элемент сейчас активен для покраски (только один из них может быть true)

    // 📌 Вызывается при выборе цвета (устанавливает индекс цвета)
    public void r1(int i)
    {
        rang = i;
    }

    // 📌 Активирует нужный макияж (один из массивов) в зависимости от выбранной части лица и цвета
    public void set()
    {
        if (labni)
        {
            for (int i = 0; i < lablar.Length; i++)
            {
                lablar[i].SetActive(i == rang);
            }
        }

        if (qovoqni)
        {
            for (int i = 0; i < qovoqlar.Length; i++)
            {
                qovoqlar[i].SetActive(i == rang);
            }
        }

        if (yanoqni)
        {
            for (int i = 0; i < yanoqlar.Length; i++)
            {
                yanoqlar[i].SetActive(i == rang);
            }
        }
    }

    // 📌 Активируем режим покраски губ
    public void setLab()
    {
        labni = true; qovoqni = false; yanoqni = false;
    }

    // 📌 Активируем режим покраски век
    public void setQovoq()
    {
        labni = false; qovoqni = true; yanoqni = false;
    }

    // 📌 Активируем режим покраски щек
    public void setYanoq()
    {
        labni = false; qovoqni = false; yanoqni = true;
    }
}