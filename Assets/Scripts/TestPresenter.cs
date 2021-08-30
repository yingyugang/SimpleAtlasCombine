using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BlueNoah.SimpleAtlas { 
    public class TestPresenter : MonoBehaviour
    {
        public GameObject itemPrefab;
        public Texture2D texture;
        public int subTextureSize = 64;
        public Texture2D[] textures;
        public Sprite[] sprites;
        public List<Image> items;

        void Start()
        {
            texture = new Texture2D(subTextureSize * 8, subTextureSize * 8);
            items = new List<Image>();
            for (int i = 0; i < textures.Length; i++)
            {
                var item = Instantiate(itemPrefab, transform, false);
                item.GetComponent<Image>().sprite = Sprite.Create(textures[i],new Rect(0,0, textures[i].width, textures[i].height),new Vector2(0.5f,0.5f));
                items.Add(item.GetComponent<Image>());
            }
        }

        void Replace()
        {
            for (int i = 0; i < items.Count; i++)
            {
                int y = i / 8 * subTextureSize;
                int x = i % 8 * subTextureSize;
                Color[] colors = items[i].sprite.texture.GetPixels();
                texture.SetPixels(x, y, subTextureSize, subTextureSize, colors);
                items[i].sprite = Sprite.Create(texture, new Rect(x, y, subTextureSize, subTextureSize), new Vector2(0.5f, 0.5f));
            }
            texture.Apply();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                Replace();
            }
        }
    }
}