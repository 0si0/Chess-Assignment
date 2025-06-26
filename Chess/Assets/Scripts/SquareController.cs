using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Mal
{
    is_w_bishop, is_w_king, is_w_knight, is_w_pawn, is_w_queen, is_w_rook,
    is_b_bishop, is_b_king, is_b_knight, is_b_pawn, is_b_queen, is_b_rook,
    None
}

public class SquareController : MonoBehaviour
{
    [SerializeField] Sprite w_bishop;
    [SerializeField] Sprite w_king;
    [SerializeField] Sprite w_knight;
    [SerializeField] Sprite w_pawn;
    [SerializeField] Sprite w_queen;
    [SerializeField] Sprite w_rook;

    [SerializeField] Sprite b_bishop;
    [SerializeField] Sprite b_king;
    [SerializeField] Sprite b_knight;
    [SerializeField] Sprite b_pawn;
    [SerializeField] Sprite b_queen;
    [SerializeField] Sprite b_rook;




    Image image;
    [SerializeField] Move move;
    [SerializeField] public Mal mal;


    public bool exists = false;
    public bool isWhite = false;
    public bool isBlack = false;
    

    public int currentx = 0;
    public int currenty = 0;


    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        if (!exists) image.color = new Vector4(1, 1, 1, 0);
        move = FindAnyObjectByType<Move>();
    }

    public void Click()
    {
        move.CurrentSetting(currentx, currenty, mal);
    }

  
    // Update is called once per frame
    void Update()
    {
        if (exists)
        {
            if (mal == Mal.is_w_bishop)
            {
                image.sprite = w_bishop;
            }
            else if (mal == Mal.is_w_king)
            {
                image.sprite = w_king;
            }
            else if (mal == Mal.is_w_knight)
            {
                image.sprite = w_knight;
            }
            else if (mal == Mal.is_w_pawn)
            {
                image.sprite = w_pawn;
            }
            else if (mal == Mal.is_w_queen)
            {
                image.sprite = w_queen;
            }
            else if (mal == Mal.is_w_rook)
            {
                image.sprite = w_rook;
            }
            else if (mal == Mal.is_b_bishop)
            {
                image.sprite = b_bishop;
            }
            else if (mal == Mal.is_b_king)
            {
                image.sprite = b_king;
            }
            else if (mal == Mal.is_b_knight)
            {
                image.sprite = b_knight;
            }
            else if (mal == Mal.is_b_pawn)
            {
                image.sprite = b_pawn;
               
            }
            else if (mal == Mal.is_b_queen)
            {
                image.sprite = b_queen;
            }
            else if (mal == Mal.is_b_rook)
            {
                image.sprite = b_rook;
            }
            else if (mal == Mal.None)
            {
                image.sprite = null;
            }

        }

    }
}