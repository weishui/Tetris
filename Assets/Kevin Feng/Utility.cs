using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace KevinFeng
{
    public class Utility
    {
        //Create a gameobject with sprite renderer in designated place
        public static GameObject CreateWorldSprite(string name, Transform parent, Sprite sprite, Vector3 localPosition, Vector3 localScale, int sortingOrder, Color color)
        {
            GameObject gameObject = new GameObject(name, typeof(SpriteRenderer));
            Transform transform = gameObject.transform;
            transform.SetParent(parent, false);
            transform.localPosition = localPosition;
            transform.localScale = localScale;
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
            spriteRenderer.sortingOrder = sortingOrder;
            spriteRenderer.color = color;
            return gameObject;
        }

        /// <summary>
        /// Given width and height, generate a blank sprite.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Sprite CreateBlankSprite(int width, int height)
        {
            Sprite sprite;
            Texture2D texture;
            
            texture = new Texture2D(width, width, TextureFormat.ARGB32, false);
            sprite = Sprite.Create(texture, new Rect(Vector2.zero, new Vector2(texture.width, texture.height)), new Vector2(0.5f, 0.5f));
            return sprite;
        }

        /// <summary>
        /// A small tool to convert RGB color to Color;
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Color Color(float r, float g, float b)
        {
            if (r > 255)
                r = 255f;

            if (g > 255)
                g = 255f;

            if (b > 255)
                b = 255f;

            r /= 255f;
            g /= 255f;
            b /= 255f;

            return new Color(r, g, b);
        }

        public static Color Color(string hex)
        {
            float r = Convert.ToInt32(hex.Substring(0, 2), 16);
            float g = Convert.ToInt32(hex.Substring(2, 2), 16);
            float b = Convert.ToInt32(hex.Substring(4, 2), 16);

            return Utility.Color(r, g, b);
        }

        /// <summary>
        /// Change a Button's color to designated colors.
        /// </summary>
        /// <param name="button"></param>
        /// <param name="normal"></param>
        /// <param name="highlighted"></param>
        /// <param name="pressed"></param>
        /// <param name="selected"></param>
        /// <param name="disabled"></param>
        public static void ChangeSelectableColor(Selectable selectable, Color normal, Color highlighted, Color pressed, Color selected, Color disabled)
        {
            ColorBlock cb = selectable.colors;
            cb.normalColor = normal;
            cb.highlightedColor = highlighted;
            cb.pressedColor = pressed;
            cb.selectedColor = selected;
            cb.disabledColor = disabled;
            selectable.colors = cb;
        }
    }
}

