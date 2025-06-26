using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ChessArray
{
    public GameObject[] pan;
}

public class Move : MonoBehaviour
{
    public ChessArray[] chesspan;
    public bool nowWhite = true;
    string saveMal;
    Mal thismal;

    [SerializeField] Image w_winimage;
    [SerializeField] Image b_winimage;


    bool Clicked = false;
    int currentx, currenty = 0;
    int prev_x, prev_y = 0;
    int whiteking_x = 4;
    int whiteking_y = 7;

    int blackking_x = 4;
    int blackking_y = 0;

    bool wking_dangerous = false;
    bool bking_dangerous = false;

    [SerializeField] GameObject wPromotion;
    [SerializeField] GameObject bPromotion;
    
   

    public void CurrentSetting(int x, int y, Mal mal) //어떤 말이든 누르면 일단 이거 실행
    {
        currentx = x;
        currenty = y;
        thismal = mal;
        ChooseMove();
    }

    public void w_pushRook()
    {
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().mal = Mal.is_w_rook;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().exists = true;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isWhite = true;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isBlack = false;
        chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().mal = Mal.None;
        chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().exists = false;

        w_rookCheck(currentx, currenty);

        wPromotion.SetActive(false);

        Undo();
        nowWhite = !nowWhite;
        TurnChange();
    }
    public void w_pushBishop()
    {
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().mal = Mal.is_w_bishop;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().exists = true;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isWhite = true;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isBlack = false;
        chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().mal = Mal.None;
        chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().exists = false;



        w_bishopCheck(currentx, currenty);

        wPromotion.SetActive(false);

        Undo();
        nowWhite = !nowWhite;
        TurnChange();
        
    }
    public void w_pushQueen()
    {
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().mal = Mal.is_w_queen;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().exists = true;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isWhite = true;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isBlack = false;
        chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().mal = Mal.None;
        chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().exists = false;

        w_bishopCheck(currentx, currenty);
        w_rookCheck(currentx, currenty);
        wPromotion.SetActive(false);

        Undo();
        nowWhite = !nowWhite;
        TurnChange();
    }
    public void w_pushKnight()
    {
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().mal = Mal.is_w_knight;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().exists = true;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isWhite = true;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isBlack = false;
        chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().mal = Mal.None;
        chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().exists = false;

        w_knightCheck(currentx, currenty);

        wPromotion.SetActive(false);

        Undo();
        nowWhite = !nowWhite;
        TurnChange();
    }

    public void b_pushRook()
    {
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().mal = Mal.is_b_rook;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().exists = true;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isWhite = false;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isBlack = true;
        chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().mal = Mal.None;
        chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().exists = false;

        b_rookCheck(currentx, currenty);

        wPromotion.SetActive(false);

        Undo();
        nowWhite = !nowWhite;
        TurnChange();
    }
    public void b_pushBishop()
    {
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().mal = Mal.is_b_bishop;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().exists = true;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isWhite = false;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isBlack = true;
        chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().mal = Mal.None;
        chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().exists = false;



        b_bishopCheck(currentx, currenty);

        wPromotion.SetActive(false);

        Undo();
        nowWhite = !nowWhite;
        TurnChange();
        
    }
    public void b_pushQueen()
    {
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().mal = Mal.is_b_queen;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().exists = true;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isWhite = false;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isBlack = true;
        chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().mal = Mal.None;
        chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().exists = false;

        b_bishopCheck(currentx, currenty);
        b_rookCheck(currentx, currenty);
        wPromotion.SetActive(false);

        Undo();
        nowWhite = !nowWhite;
        TurnChange();
    }
    public void b_pushKnight()
    {
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().mal = Mal.is_b_knight;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().exists = true;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isWhite = false;
        chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isBlack = true;
        chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().mal = Mal.None;
        chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().exists = false;

        b_knightCheck(currentx, currenty);

        wPromotion.SetActive(false);

        Undo();
        nowWhite = !nowWhite;
        TurnChange();
    }

    public void ChooseMove()
    {
        if (!Clicked) // 첫번째 클릭
        {
            prev_x = currentx;
            prev_y = currenty;

            if (thismal == Mal.is_w_pawn)
            {
                w_pawnMove();
                saveMal = "w_pawn";
            }
            else if (thismal == Mal.is_b_pawn)
            {
                b_pawnMove();
                saveMal = "b_pawn";
            }
            else if (thismal == Mal.is_w_rook)
            {
                w_rookMove();
                saveMal = "w_rook";
            }
            else if (thismal == Mal.is_b_rook)
            {
                b_rookMove();
                saveMal = "b_rook";
            }
            else if (thismal == Mal.is_w_bishop)
            {
                w_bishopMove();
                saveMal = "w_bishop";
            }
            else if (thismal == Mal.is_b_bishop)
            {
                b_bishopMove();
                saveMal = "b_bishop";
            }
            else if (thismal == Mal.is_w_knight)
            {
                w_knightMove();
                saveMal = "w_knight";
            }
            else if (thismal == Mal.is_b_knight)
            {
                b_knightMove();
                saveMal = "b_knight";
            }
            else if (thismal == Mal.is_w_queen)
            {
                w_queenMove();
                saveMal = "w_queen";
            }
            else if (thismal == Mal.is_b_queen)
            {
                b_queenMove();
                saveMal = "b_queen";
            }
            else if (thismal == Mal.is_w_king)
            {
                w_kingMove();
                saveMal = "w_king";
            }
            else if (thismal == Mal.is_b_king)
            {
                b_kingMove();
                saveMal = "b_king";
            }


            Clicked = true;
        }
        else // 두번째 클릭
        {
            if (saveMal == "w_pawn")
            {
                if (currenty == 0)
                {
                    wPromotion.SetActive(true);
                    return;
                }
                else
                {
                    chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().mal = Mal.is_w_pawn;
                    chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().exists = true;
                    chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isWhite = true;
                    chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isBlack = false;
                    chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().mal = Mal.None;
                    chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().exists = false;

                    w_pawnCheck(currentx, currenty);
                }

            }
            else if (saveMal == "b_pawn")
            {
                if (currenty == 7)
                {
                    bPromotion.SetActive(true);
                    return;
                }
                else
                {
                    chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().mal = Mal.is_b_pawn;
                    chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().exists = true;
                    chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isWhite = false;
                    chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isBlack = true;
                    chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().mal = Mal.None;
                    chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().exists = false;

                    b_pawnCheck(currentx, currenty);
                }
            }

            else if (saveMal == "w_rook")
            {
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().mal = Mal.is_w_rook;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().exists = true;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isWhite = true;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isBlack = false;
                chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().mal = Mal.None;
                chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().exists = false;

                w_rookCheck(currentx, currenty);

            }
            else if (saveMal == "b_rook")
            {
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().mal = Mal.is_b_rook;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().exists = true;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isWhite = false;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isBlack = true;
                chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().mal = Mal.None;
                chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().exists = false;

                b_rookCheck(currentx, currenty);
            }
            else if (saveMal == "w_bishop")
            {
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().mal = Mal.is_w_bishop;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().exists = true;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isWhite = true;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isBlack = false;
                chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().mal = Mal.None;
                chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().exists = false;

                w_bishopCheck(currentx, currenty);
            }
            else if (saveMal == "b_bishop")
            {
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().mal = Mal.is_b_bishop;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().exists = true;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isWhite = false;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isBlack = true;
                chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().mal = Mal.None;
                chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().exists = false;

                b_bishopCheck(currentx, currenty);
            }
            else if (saveMal == "w_knight")
            {
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().mal = Mal.is_w_knight;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().exists = true;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isWhite = true;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isBlack = false;
                chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().mal = Mal.None;
                chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().exists = false;

                w_knightCheck(currentx, currenty);
            }
            else if (saveMal == "b_knight")
            {
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().mal = Mal.is_b_knight;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().exists = true;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isWhite = false;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isBlack = true;
                chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().mal = Mal.None;
                chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().exists = false;

                b_knightCheck(currentx, currenty);
            }
            else if (saveMal == "w_queen")
            {
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().mal = Mal.is_w_queen;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().exists = true;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isWhite = true;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isBlack = false;
                chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().mal = Mal.None;
                chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().exists = false;

                w_rookCheck(currentx, currenty);
                w_bishopCheck(currentx, currenty);
            }
            else if (saveMal == "b_queen")
            {
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().mal = Mal.is_b_queen;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().exists = true;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isWhite = false;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isBlack = true;
                chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().mal = Mal.None;
                chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().exists = false;

                b_rookCheck(currentx, currenty);
                b_bishopCheck(currentx, currenty);
            }
            else if (saveMal == "w_king")
            {
                whiteking_x = currentx;
                whiteking_y = currenty;

                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().mal = Mal.is_w_king;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().exists = true;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isWhite = true;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isBlack = false;
                chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().mal = Mal.None;
                chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().exists = false;

                wking_dangerous = false;
                w_kingCheck(currentx, currenty);
            }
            else if (saveMal == "b_king")
            {
                blackking_x = currentx;
                blackking_y = currenty;

                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().mal = Mal.is_b_king;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().exists = true;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isWhite = false;
                chesspan[currenty].pan[currentx].gameObject.GetComponent<SquareController>().isBlack = true;
                chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().mal = Mal.None;
                chesspan[prev_y].pan[prev_x].gameObject.GetComponent<SquareController>().exists = false;

                bking_dangerous = false;
                b_kingCheck(currentx, currenty);
            }



            Undo();
            nowWhite = !nowWhite;
            TurnChange();
        }

    }

    public void colorDraw(ref List<GameObject> colorStack)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                chesspan[i].pan[j].gameObject.GetComponentInChildren<Button>().interactable = false;
            }
        }

        for (int i = 0; i < colorStack.Count; i++)
        {
            colorStack[i].GetComponent<Image>().color = new Color(0, 1, 0, 1);
            colorStack[i].GetComponentInChildren<Button>().interactable = true;
        }
    }

    public void TurnChange() // 흰 백 턴 교체하기
    {
        
        if (nowWhite)
        {
            if (wking_dangerous)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        chesspan[i].pan[j].gameObject.GetComponentInChildren<Button>().interactable = false;
                    }
                }
                chesspan[whiteking_y].pan[whiteking_x].gameObject.GetComponentInChildren<Button>().interactable = true;
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (chesspan[i].pan[j].gameObject.GetComponent<SquareController>().isWhite && chesspan[i].pan[j].gameObject.GetComponent<SquareController>().exists)
                            chesspan[i].pan[j].gameObject.GetComponentInChildren<Button>().interactable = true;
                        else
                        {
                            chesspan[i].pan[j].gameObject.GetComponentInChildren<Button>().interactable = false;
                        }

                    }
                }
            }
        }
        else
        {
            if (bking_dangerous)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        chesspan[i].pan[j].gameObject.GetComponentInChildren<Button>().interactable = false;
                    }
                }
                chesspan[blackking_y].pan[blackking_x].gameObject.GetComponentInChildren<Button>().interactable = true;
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (!chesspan[i].pan[j].gameObject.GetComponent<SquareController>().isWhite && chesspan[i].pan[j].gameObject.GetComponent<SquareController>().exists)
                            chesspan[i].pan[j].gameObject.GetComponentInChildren<Button>().interactable = true;
                        else
                        {
                            chesspan[i].pan[j].gameObject.GetComponentInChildren<Button>().interactable = false;
                        }

                    }
                }
            }
        }


    }


    public void Undo() // 모든 클릭 세팅 초기화
    {
        if (nowWhite)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (chesspan[i].pan[j].gameObject.GetComponent<SquareController>().exists)
                    {
                        if (chesspan[i].pan[j].gameObject.GetComponent<SquareController>().isWhite)
                            chesspan[i].pan[j].gameObject.GetComponentInChildren<Button>().interactable = true;
                        else chesspan[i].pan[j].gameObject.GetComponentInChildren<Button>().interactable = false;
                    }
                    else
                    {
                        chesspan[i].pan[j].gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                        chesspan[i].pan[j].gameObject.GetComponent<Image>().sprite = null;
                        chesspan[i].pan[j].gameObject.GetComponentInChildren<Button>().interactable = false;
                    }

                }
            }
            Clicked = false;
        }
        else
        {

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (chesspan[i].pan[j].gameObject.GetComponent<SquareController>().exists)
                    {
                        if (chesspan[i].pan[j].gameObject.GetComponent<SquareController>().isBlack)
                            chesspan[i].pan[j].gameObject.GetComponentInChildren<Button>().interactable = true;
                        else chesspan[i].pan[j].gameObject.GetComponentInChildren<Button>().interactable = false;
                    }
                    else
                    {
                        chesspan[i].pan[j].gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                        chesspan[i].pan[j].gameObject.GetComponent<Image>().sprite = null;
                        chesspan[i].pan[j].gameObject.GetComponentInChildren<Button>().interactable = false;
                    }

                }
            }
            Clicked = false;
        }

    }


    // 말 이동 함수
    void w_pawnMove()
    {
        GameObject twomove = null, onemove = null;
        GameObject rightarrow = null, leftarrow = null;

        List<GameObject> colorStack = new List<GameObject>(); //이동 가능한 것들 다 담아놓기

        if (currenty == 6) // 폰이 처음 움직일 때
        {

            twomove = chesspan[currenty - 2].pan[currentx].gameObject; // 두칸 움직인 경우
            onemove = chesspan[currenty - 1].pan[currentx].gameObject; // 한칸 움직인 경우

            if (!twomove.GetComponent<SquareController>().exists && !onemove.GetComponent<SquareController>().exists)
            { // 두칸 앞까지 아무것도 없을 때
                colorStack.Add(twomove);
                colorStack.Add(onemove);
            }
            else if (twomove.GetComponent<SquareController>().exists && !onemove.GetComponent<SquareController>().exists) // 두칸 앞에 기물이 있을 때
            {
                colorStack.Add(onemove);
            }


        }
        else //이미 움직인 적 있을 때
        {
            if (currenty >= 1)
            {
                onemove = chesspan[currenty - 1].pan[currentx].gameObject;

                if (!onemove.GetComponent<SquareController>().exists) // 한칸앞에 기물이 없을 때
                {
                    colorStack.Add(onemove);
                }
            }
        }

        if (currentx > 0 && currenty > 0)
        {
            leftarrow = chesspan[currenty - 1].pan[currentx - 1].gameObject;
            if (leftarrow.GetComponent<SquareController>().exists == true && leftarrow.GetComponent<SquareController>().isBlack)
            {
                colorStack.Add(leftarrow);
            }
        }

        if (currentx < 7 && currenty > 0)
        {
            rightarrow = chesspan[currenty - 1].pan[currentx + 1].gameObject;
            if (rightarrow.GetComponent<SquareController>().exists == true && rightarrow.GetComponent<SquareController>().isBlack)
            {
                colorStack.Add(rightarrow);
            }
        }
        colorDraw(ref colorStack);
    }

    void w_pawnCheck(int x, int y)
    {

        GameObject rightarrow = null, leftarrow = null;

        if (x > 0 && y > 0)
        {
            leftarrow = chesspan[y - 1].pan[x - 1].gameObject;
            if (leftarrow.GetComponent<SquareController>().exists == true && leftarrow.GetComponent<SquareController>().mal == Mal.is_b_king)
            {
                b_kingCanMove();
            }
        }

        if (x < 7 && y > 0)
        {
            rightarrow = chesspan[y - 1].pan[x + 1].gameObject;
            if (rightarrow.GetComponent<SquareController>().exists == true && rightarrow.GetComponent<SquareController>().mal == Mal.is_b_king)
            {
                b_kingCanMove();
            }
        }

    }

    void b_pawnMove()
    {
        GameObject twomove = null, onemove = null;
        GameObject rightarrow = null, leftarrow = null;

        List<GameObject> colorStack = new List<GameObject>(); //이동 가능한 것들 다 담아놓기

        if (currenty == 1) // 폰이 처음 움직일 때
        {
            twomove = chesspan[currenty + 2].pan[currentx].gameObject; // 두칸 움직인 경우
            onemove = chesspan[currenty + 1].pan[currentx].gameObject; // 한칸 움직인 경우

            if (!twomove.GetComponent<SquareController>().exists && !onemove.GetComponent<SquareController>().exists)
            { // 두칸 앞까지 아무것도 없을 때
                colorStack.Add(twomove);
                colorStack.Add(onemove);
            }
            else if (twomove.GetComponent<SquareController>().exists && !onemove.GetComponent<SquareController>().exists) // 두칸 앞에 기물이 있을 때
            {
                colorStack.Add(onemove);
            }
        }
        else //이미 움직인 적 있을 때
        {
            if (currenty <= 6)
            {
                onemove = chesspan[currenty + 1].pan[currentx].gameObject;

                if (!onemove.GetComponent<SquareController>().exists) // 한칸앞에 기물이 없을 때
                {
                    colorStack.Add(onemove);
                }
            }
        }

        if (currentx > 0 && currenty < 7)
        {
            leftarrow = chesspan[currenty + 1].pan[currentx - 1].gameObject;
            if (leftarrow.GetComponent<SquareController>().exists == true && leftarrow.GetComponent<SquareController>().isWhite)
            {
                colorStack.Add(leftarrow);
            }
        }

        if (currentx < 7 && currenty < 7)
        {
            rightarrow = chesspan[currenty + 1].pan[currentx + 1].gameObject;
            if (rightarrow.GetComponent<SquareController>().exists == true && rightarrow.GetComponent<SquareController>().isWhite)
            {
                colorStack.Add(rightarrow);
            }
        }
        colorDraw(ref colorStack);
    }

    void b_pawnCheck(int x, int y)
    {

        GameObject rightarrow = null, leftarrow = null;

        if (x > 0 && y < 7)
        {
            leftarrow = chesspan[y + 1].pan[x - 1].gameObject;
            if (leftarrow.GetComponent<SquareController>().exists == true && leftarrow.GetComponent<SquareController>().mal == Mal.is_w_king)
            {
                w_kingCanMove();
            }
        }

        if (x < 7 && y < 7)
        {
            rightarrow = chesspan[y + 1].pan[x + 1].gameObject;
            if (rightarrow.GetComponent<SquareController>().exists == true && rightarrow.GetComponent<SquareController>().mal == Mal.is_w_king)
            {
                w_kingCanMove();
            }
        }

    }

    void w_rookMove()
    {
        List<GameObject> colorStack = new List<GameObject>(); //이동 가능한 것들 다 담아놓기

        for (int i = 1; i < 8; i++) // 위로 어디까지 갈수 있나 확인
        {
            if (currenty - i >= 0)
            {
                if (chesspan[currenty - i].pan[currentx].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty - i].pan[currentx].GetComponent<SquareController>().isBlack)
                    {
                        colorStack.Add(chesspan[currenty - i].pan[currentx].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    colorStack.Add(chesspan[currenty - i].pan[currentx].gameObject);
                }
            }
            else
            {
                break;
            }
        }

        for (int i = 1; i < 8; i++) // 아래로 어디까지 갈수 있나 확인
        {
            if (currenty + i <= 7)
            {
                if (chesspan[currenty + i].pan[currentx].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty + i].pan[currentx].GetComponent<SquareController>().isBlack)
                    {
                        colorStack.Add(chesspan[currenty + i].pan[currentx].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    colorStack.Add(chesspan[currenty + i].pan[currentx].gameObject);
                }
            }
            else
            {
                break;
            }
        }

        for (int i = 1; i < 8; i++) // 왼쪽으로 어디까지 갈수 있나 확인
        {
            if (currentx - i >= 0)
            {
                if (chesspan[currenty].pan[currentx - i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty].pan[currentx - i].GetComponent<SquareController>().isBlack)
                    {
                        colorStack.Add(chesspan[currenty].pan[currentx - i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    colorStack.Add(chesspan[currenty].pan[currentx - i].gameObject);
                }
            }
            else
            {
                break;
            }
        }
        for (int i = 1; i < 8; i++) // 오른쪽으로 어디까지 갈수 있나 확인
        {
            if (currentx + i <= 7)
            {
                if (chesspan[currenty].pan[currentx + i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty].pan[currentx + i].GetComponent<SquareController>().isBlack)
                    {
                        colorStack.Add(chesspan[currenty].pan[currentx + i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    colorStack.Add(chesspan[currenty].pan[currentx + i].gameObject);
                }
            }
            else
            {
                break;
            }
        }
        colorDraw(ref colorStack);
    }

    void w_rookCheck(int x, int y)
    {
        for (int i = 1; i < 8; i++) // 위로 어디까지 갈수 있나 확인
        {
            if (y - i >= 0)
            {
                if (chesspan[y - i].pan[x].GetComponent<SquareController>().exists)
                {
                    if (chesspan[y - i].pan[x].GetComponent<SquareController>().mal == Mal.is_b_king)
                    {
                        b_kingCanMove();
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                break;
            }
        }

        for (int i = 1; i < 8; i++) // 아래로 어디까지 갈수 있나 확인
        {
            if (y + i <= 7)
            {
                if (chesspan[y + i].pan[x].GetComponent<SquareController>().exists)
                {
                    if (chesspan[y + i].pan[x].GetComponent<SquareController>().mal == Mal.is_b_king)
                    {
                        b_kingCanMove();
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                break;
            }
        }

        for (int i = 1; i < 8; i++) // 왼쪽으로 어디까지 갈수 있나 확인
        {
            if (x - i >= 0)
            {
                if (chesspan[y].pan[x - i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[y].pan[x - i].GetComponent<SquareController>().mal == Mal.is_b_king)
                    {
                        b_kingCanMove();
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                break;
            }
        }
        for (int i = 1; i < 8; i++) // 오른쪽으로 어디까지 갈수 있나 확인
        {
            if (x + i <= 7)
            {
                if (chesspan[y].pan[x + i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[y].pan[currentx + i].GetComponent<SquareController>().mal == Mal.is_b_king)
                    {
                        b_kingCanMove();
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                break;
            }
        }
    }

    void b_rookMove()
    {
        List<GameObject> colorStack = new List<GameObject>(); //이동 가능한 것들 다 담아놓기

        for (int i = 1; i < 8; i++) // 위로 어디까지 갈수 있나 확인
        {
            if (currenty - i >= 0)
            {
                if (chesspan[currenty - i].pan[currentx].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty - i].pan[currentx].GetComponent<SquareController>().isWhite)
                    {
                        colorStack.Add(chesspan[currenty - i].pan[currentx].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    colorStack.Add(chesspan[currenty - i].pan[currentx].gameObject);
                }
            }
            else
            {
                break;
            }
        }

        for (int i = 1; i < 8; i++) // 아래로 어디까지 갈수 있나 확인
        {
            if (currenty + i <= 7)
            {
                if (chesspan[currenty + i].pan[currentx].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty + i].pan[currentx].GetComponent<SquareController>().isWhite)
                    {
                        colorStack.Add(chesspan[currenty + i].pan[currentx].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    colorStack.Add(chesspan[currenty + i].pan[currentx].gameObject);
                }
            }
            else
            {
                break;
            }
        }

        for (int i = 1; i < 8; i++) // 왼쪽으로 어디까지 갈수 있나 확인
        {
            if (currentx - i >= 0)
            {
                if (chesspan[currenty].pan[currentx - i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty].pan[currentx - i].GetComponent<SquareController>().isWhite)
                    {
                        colorStack.Add(chesspan[currenty].pan[currentx - i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    colorStack.Add(chesspan[currenty].pan[currentx - i].gameObject);
                }
            }
            else
            {
                break;
            }
        }
        for (int i = 1; i < 8; i++) // 오른쪽으로 어디까지 갈수 있나 확인
        {
            if (currentx + i <= 7)
            {
                if (chesspan[currenty].pan[currentx + i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty].pan[currentx + i].GetComponent<SquareController>().isWhite)
                    {
                        colorStack.Add(chesspan[currenty].pan[currentx + i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    colorStack.Add(chesspan[currenty].pan[currentx + i].gameObject);
                }
            }
            else
            {
                break;
            }
        }
        colorDraw(ref colorStack);
    }

    void b_rookCheck(int x, int y)
    {

        for (int i = 1; i < 8; i++) // 위로 어디까지 갈수 있나 확인
        {
            if (y - i >= 0)
            {
                if (chesspan[y - i].pan[x].GetComponent<SquareController>().exists)
                {
                    if (chesspan[y - i].pan[x].GetComponent<SquareController>().mal == Mal.is_w_king)
                    {
                        w_kingCanMove();
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                break;
            }
        }

        for (int i = 1; i < 8; i++) // 아래로 어디까지 갈수 있나 확인
        {
            if (y + i <= 7)
            {
                if (chesspan[y + i].pan[x].GetComponent<SquareController>().exists)
                {
                    if (chesspan[y + i].pan[x].GetComponent<SquareController>().mal == Mal.is_w_king)
                    {
                        w_kingCanMove();
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                break;
            }
        }

        for (int i = 1; i < 8; i++) // 왼쪽으로 어디까지 갈수 있나 확인
        {
            if (x - i >= 0)
            {
                if (chesspan[y].pan[x - i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[y].pan[x - i].GetComponent<SquareController>().mal == Mal.is_w_king)
                    {
                        w_kingCanMove();
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                break;
            }
        }
        for (int i = 1; i < 8; i++) // 오른쪽으로 어디까지 갈수 있나 확인
        {
            if (x + i <= 7)
            {
                if (chesspan[y].pan[x + i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[y].pan[currentx + i].GetComponent<SquareController>().mal == Mal.is_w_king)
                    {
                        w_kingCanMove();
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                break;
            }
        }
    }

    void w_bishopMove()
    {
        List<GameObject> colorStack = new List<GameObject>(); //이동 가능한 것들 다 담아놓기


        for (int i = 1; i < 8; i++)
        {
            if (currenty - i >= 0 && currentx + i <= 7) // 오른쪽 위 대각선
            {
                if (chesspan[currenty - i].pan[currentx + i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty - i].pan[currentx + i].GetComponent<SquareController>().isBlack)
                    {
                        colorStack.Add(chesspan[currenty - i].pan[currentx + i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
                else
                {
                    colorStack.Add(chesspan[currenty - i].pan[currentx + i].gameObject);
                }
            }
            else
            {
                break;
            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (currenty - i >= 0 && currentx - i >= 0) // 왼쪽 위 대각선
            {
                if (chesspan[currenty - i].pan[currentx - i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty - i].pan[currentx - i].GetComponent<SquareController>().isBlack)
                    {
                        colorStack.Add(chesspan[currenty - i].pan[currentx - i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
                else
                {
                    colorStack.Add(chesspan[currenty - i].pan[currentx - i].gameObject);
                }
            }
            else
            {
                break;
            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (currenty + i <= 7 && currentx + i <= 7) // 오른쪽 아래 대각선
            {
                if (chesspan[currenty + i].pan[currentx + i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty + i].pan[currentx + i].GetComponent<SquareController>().isBlack)
                    {
                        colorStack.Add(chesspan[currenty + i].pan[currentx + i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
                else
                {
                    colorStack.Add(chesspan[currenty + i].pan[currentx + i].gameObject);
                }
            }
            else
            {
                break;
            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (currenty + i <= 7 && currentx - i >= 0) // 왼쪽 아래 대각선
            {
                if (chesspan[currenty + i].pan[currentx - i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty + i].pan[currentx - i].GetComponent<SquareController>().isBlack)
                    {
                        colorStack.Add(chesspan[currenty + i].pan[currentx - i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
                else
                {
                    colorStack.Add(chesspan[currenty + i].pan[currentx - i].gameObject);
                }
            }
            else
            {
                break;
            }

        }

        colorDraw(ref colorStack);

    }

    void w_bishopCheck(int x, int y)
    {
        for (int i = 1; i < 8; i++)
        {
            if (y - i >= 0 && x + i <= 7) // 오른쪽 위 대각선
            {
                if (chesspan[y - i].pan[x + i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[y - i].pan[x + i].GetComponent<SquareController>().mal == Mal.is_b_king)
                    {
                        b_kingCanMove();
                        break;
                    }
                    else
                    {
                        break;
                    }


                }

            }
            else
            {
                break;
            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (y - i >= 0 && x - i >= 0) // 왼쪽 위 대각선
            {
                if (chesspan[y - i].pan[x - i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[y - i].pan[x - i].GetComponent<SquareController>().mal == Mal.is_b_king)
                    {
                        b_kingCanMove();
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
            }
            else
            {
                break;
            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (y + i <= 7 && x + i <= 7) // 오른쪽 아래 대각선
            {
                if (chesspan[y + i].pan[x + i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[y + i].pan[x + i].GetComponent<SquareController>().mal == Mal.is_b_king)
                    {
                        b_kingCanMove();
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
            }
            else
            {
                break;
            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (y + i <= 7 && x - i >= 0) // 왼쪽 아래 대각선
            {
                if (chesspan[y + i].pan[x - i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[y + i].pan[x - i].GetComponent<SquareController>().mal == Mal.is_b_king)
                    {
                        b_kingCanMove();
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
            }
            else
            {
                break;
            }

        }
    }

    void b_bishopMove()
    {
        List<GameObject> colorStack = new List<GameObject>(); //이동 가능한 것들 다 담아놓기


        for (int i = 1; i < 8; i++)
        {
            if (currenty - i >= 0 && currentx + i <= 7) // 오른쪽 위 대각선
            {
                if (chesspan[currenty - i].pan[currentx + i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty - i].pan[currentx + i].GetComponent<SquareController>().isWhite)
                    {
                        colorStack.Add(chesspan[currenty - i].pan[currentx + i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
                else
                {
                    colorStack.Add(chesspan[currenty - i].pan[currentx + i].gameObject);
                }
            }
            else
            {
                break;
            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (currenty - i >= 0 && currentx - i >= 0) // 왼쪽 위 대각선
            {
                if (chesspan[currenty - i].pan[currentx - i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty - i].pan[currentx - i].GetComponent<SquareController>().isWhite)
                    {
                        colorStack.Add(chesspan[currenty - i].pan[currentx - i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
                else
                {
                    colorStack.Add(chesspan[currenty - i].pan[currentx - i].gameObject);
                }
            }
            else
            {
                break;
            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (currenty + i <= 7 && currentx + i <= 7) // 오른쪽 아래 대각선
            {
                if (chesspan[currenty + i].pan[currentx + i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty + i].pan[currentx + i].GetComponent<SquareController>().isWhite)
                    {
                        colorStack.Add(chesspan[currenty + i].pan[currentx + i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
                else
                {
                    colorStack.Add(chesspan[currenty + i].pan[currentx + i].gameObject);
                }
            }
            else
            {
                break;
            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (currenty + i <= 7 && currentx - i >= 0) // 왼쪽 아래 대각선
            {
                if (chesspan[currenty + i].pan[currentx - i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty + i].pan[currentx - i].GetComponent<SquareController>().isWhite)
                    {
                        colorStack.Add(chesspan[currenty + i].pan[currentx - i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
                else
                {
                    colorStack.Add(chesspan[currenty + i].pan[currentx - i].gameObject);
                }
            }
            else
            {
                break;
            }

        }

        colorDraw(ref colorStack);
    }

    void b_bishopCheck(int x, int y)
    {
        for (int i = 1; i < 8; i++)
        {
            if (y - i >= 0 && x + i <= 7) // 오른쪽 위 대각선
            {
                if (chesspan[y - i].pan[x + i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[y - i].pan[x + i].GetComponent<SquareController>().mal == Mal.is_w_king)
                    {
                        w_kingCanMove();
                        break;
                    }
                    else
                    {
                        break;
                    }


                }

            }
            else
            {
                break;
            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (y - i >= 0 && x - i >= 0) // 왼쪽 위 대각선
            {
                if (chesspan[y - i].pan[x - i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[y - i].pan[x - i].GetComponent<SquareController>().mal == Mal.is_w_king)
                    {
                        w_kingCanMove();
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
            }
            else
            {
                break;
            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (y + i <= 7 && x + i <= 7) // 오른쪽 아래 대각선
            {
                if (chesspan[y + i].pan[x + i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[y + i].pan[x + i].GetComponent<SquareController>().mal == Mal.is_w_king)
                    {
                        w_kingCanMove();
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
            }
            else
            {
                break;
            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (y + i <= 7 && x - i >= 0) // 왼쪽 아래 대각선
            {
                if (chesspan[y + i].pan[x - i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[y + i].pan[x - i].GetComponent<SquareController>().mal == Mal.is_w_king)
                    {
                        w_kingCanMove();
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
            }
            else
            {
                break;
            }

        }
    }

    void w_knightMove()
    {
        List<GameObject> colorStack = new List<GameObject>(); //이동 가능한 것들 다 담아놓기

        // 8가지 경우의수로 나누어서 colorStack에 대입

        // (1)
        if (currenty - 2 >= 0 && currentx + 1 <= 7) // 오른쪽 2 x 3 위 칸
        {
            if (chesspan[currenty - 2].pan[currentx + 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[currenty - 2].pan[currentx + 1].GetComponent<SquareController>().isBlack)
                {
                    colorStack.Add(chesspan[currenty - 2].pan[currentx + 1].gameObject);
                }
            }
            else
            {
                colorStack.Add(chesspan[currenty - 2].pan[currentx + 1].gameObject);
            }
        }
        // (2)
        if (currenty - 1 >= 0 && currentx + 2 <= 7) // 오른쪽 3 x 2 위 칸
        {
            if (chesspan[currenty - 1].pan[currentx + 2].GetComponent<SquareController>().exists)
            {
                if (chesspan[currenty - 1].pan[currentx + 2].GetComponent<SquareController>().isBlack)
                {
                    colorStack.Add(chesspan[currenty - 1].pan[currentx + 2].gameObject);
                }
            }
            else
            {
                colorStack.Add(chesspan[currenty - 1].pan[currentx + 2].gameObject);
            }
        }
        // (3)
        if (currenty + 1 <= 7 && currentx + 2 <= 7) // 오른쪽 3 x 2 아래 칸
        {
            if (chesspan[currenty + 1].pan[currentx + 2].GetComponent<SquareController>().exists)
            {
                if (chesspan[currenty + 1].pan[currentx + 2].GetComponent<SquareController>().isBlack)
                {
                    colorStack.Add(chesspan[currenty + 1].pan[currentx + 2].gameObject);
                }
            }
            else
            {
                colorStack.Add(chesspan[currenty + 1].pan[currentx + 2].gameObject);
            }
        }
        // (4)
        if (currenty + 2 <= 7 && currentx + 1 <= 7) // 오른쪽 2 x 3 아래 칸
        {
            if (chesspan[currenty + 2].pan[currentx + 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[currenty + 2].pan[currentx + 1].GetComponent<SquareController>().isBlack)
                {
                    colorStack.Add(chesspan[currenty + 2].pan[currentx + 1].gameObject);
                }
            }
            else
            {
                colorStack.Add(chesspan[currenty + 2].pan[currentx + 1].gameObject);
            }
        }
        // (5)
        if (currenty - 2 >= 0 && currentx - 1 >= 0) // 왼쪽 2 x 3 위 칸
        {
            if (chesspan[currenty - 2].pan[currentx - 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[currenty - 2].pan[currentx - 1].GetComponent<SquareController>().isBlack)
                {
                    colorStack.Add(chesspan[currenty - 2].pan[currentx - 1].gameObject);
                }
            }
            else
            {
                colorStack.Add(chesspan[currenty - 2].pan[currentx - 1].gameObject);
            }
        }
        // (6)
        if (currenty - 1 >= 0 && currentx - 2 >= 0) // 왼쪽 3 x 2 위 칸
        {
            if (chesspan[currenty - 1].pan[currentx - 2].GetComponent<SquareController>().exists)
            {
                if (chesspan[currenty - 1].pan[currentx - 2].GetComponent<SquareController>().isBlack)
                {
                    colorStack.Add(chesspan[currenty - 1].pan[currentx - 2].gameObject);
                }
            }
            else
            {
                colorStack.Add(chesspan[currenty - 1].pan[currentx - 2].gameObject);
            }
        }
        // (7)
        if (currenty + 1 <= 7 && currentx - 2 >= 0) // 왼쪽 3 x 2 아래 칸
        {
            if (chesspan[currenty + 1].pan[currentx - 2].GetComponent<SquareController>().exists)
            {
                if (chesspan[currenty + 1].pan[currentx - 2].GetComponent<SquareController>().isBlack)
                {
                    colorStack.Add(chesspan[currenty + 1].pan[currentx - 2].gameObject);
                }
            }
            else
            {
                colorStack.Add(chesspan[currenty + 1].pan[currentx - 2].gameObject);
            }
        }
        // (8)
        if (currenty + 2 <= 7 && currentx - 1 >= 0) // 왼쪽 2 x 3 아래 칸
        {
            if (chesspan[currenty + 2].pan[currentx - 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[currenty + 2].pan[currentx - 1].GetComponent<SquareController>().isBlack)
                {
                    colorStack.Add(chesspan[currenty + 2].pan[currentx - 1].gameObject);
                }
            }
            else
            {
                colorStack.Add(chesspan[currenty + 2].pan[currentx - 1].gameObject);
            }
        }

        colorDraw(ref colorStack);
    }

    void w_knightCheck(int x, int y)
    {
        // (1)
        if (y - 2 >= 0 && x + 1 <= 7) // 오른쪽 2 x 3 위 칸
        {
            if (chesspan[y - 2].pan[x + 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[y - 2].pan[x + 1].GetComponent<SquareController>().mal == Mal.is_b_king)
                {
                    b_kingCanMove();
                }
            }
        }
        // (2)
        if (y - 1 >= 0 && x + 2 <= 7) // 오른쪽 3 x 2 위 칸
        {
            if (chesspan[y - 1].pan[x + 2].GetComponent<SquareController>().exists)
            {
                if (chesspan[y - 1].pan[x + 2].GetComponent<SquareController>().mal == Mal.is_b_king)
                {
                    b_kingCanMove();
                }
            }
        }
        // (3)
        if (y + 1 <= 7 && x + 2 <= 7) // 오른쪽 3 x 2 아래 칸
        {
            if (chesspan[y + 1].pan[x + 2].GetComponent<SquareController>().exists)
            {
                if (chesspan[y + 1].pan[x + 2].GetComponent<SquareController>().mal == Mal.is_b_king)
                {
                    b_kingCanMove();
                }
            }
        }
        // (4)
        if (y + 2 <= 7 && x + 1 <= 7) // 오른쪽 2 x 3 아래 칸
        {
            if (chesspan[y + 2].pan[x + 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[y + 2].pan[x + 1].GetComponent<SquareController>().mal == Mal.is_b_king)
                {
                    b_kingCanMove();
                }
            }
        }
        // (5)
        if (y - 2 >= 0 && x - 1 >= 0) // 왼쪽 2 x 3 위 칸
        {
            if (chesspan[y - 2].pan[x - 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[y - 2].pan[x - 1].GetComponent<SquareController>().mal == Mal.is_b_king)
                {
                    b_kingCanMove();
                }
            }
        }
        // (6)
        if (y - 1 >= 0 && x - 2 >= 0) // 왼쪽 3 x 2 위 칸
        {
            if (chesspan[y - 1].pan[x - 2].GetComponent<SquareController>().exists)
            {
                if (chesspan[y - 1].pan[x - 2].GetComponent<SquareController>().mal == Mal.is_b_king)
                {
                    b_kingCanMove();
                }
            }
        }
        // (7)
        if (y + 1 <= 7 && x - 2 >= 0) // 왼쪽 3 x 2 아래 칸
        {
            if (chesspan[y + 1].pan[x - 2].GetComponent<SquareController>().exists)
            {
                if (chesspan[y + 1].pan[x - 2].GetComponent<SquareController>().mal == Mal.is_b_king)
                {
                    b_kingCanMove();
                }
            }
        }
        // (8)
        if (y + 2 <= 7 && x - 1 >= 0) // 왼쪽 2 x 3 아래 칸
        {
            if (chesspan[y + 2].pan[x - 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[y + 2].pan[x - 1].GetComponent<SquareController>().mal == Mal.is_b_king)
                {
                    b_kingCanMove();
                }
            }
        }
    }

    void b_knightMove()
    {
        List<GameObject> colorStack = new List<GameObject>(); //이동 가능한 것들 다 담아놓기

        // 8가지 경우의수로 나누어서 colorStack에 대입

        // (1)
        if (currenty - 2 >= 0 && currentx + 1 <= 7) // 오른쪽 2 x 3 위 칸
        {
            if (chesspan[currenty - 2].pan[currentx + 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[currenty - 2].pan[currentx + 1].GetComponent<SquareController>().isWhite)
                {
                    colorStack.Add(chesspan[currenty - 2].pan[currentx + 1].gameObject);
                }
            }
            else
            {
                colorStack.Add(chesspan[currenty - 2].pan[currentx + 1].gameObject);
            }
        }
        // (2)
        if (currenty - 1 >= 0 && currentx + 2 <= 7) // 오른쪽 3 x 2 위 칸
        {
            if (chesspan[currenty - 1].pan[currentx + 2].GetComponent<SquareController>().exists)
            {
                if (chesspan[currenty - 1].pan[currentx + 2].GetComponent<SquareController>().isWhite)
                {
                    colorStack.Add(chesspan[currenty - 1].pan[currentx + 2].gameObject);
                }
            }
            else
            {
                colorStack.Add(chesspan[currenty - 1].pan[currentx + 2].gameObject);
            }
        }
        // (3)
        if (currenty + 1 <= 7 && currentx + 2 <= 7) // 오른쪽 3 x 2 아래 칸
        {
            if (chesspan[currenty + 1].pan[currentx + 2].GetComponent<SquareController>().exists)
            {
                if (chesspan[currenty + 1].pan[currentx + 2].GetComponent<SquareController>().isWhite)
                {
                    colorStack.Add(chesspan[currenty + 1].pan[currentx + 2].gameObject);
                }
            }
            else
            {
                colorStack.Add(chesspan[currenty + 1].pan[currentx + 2].gameObject);
            }
        }
        // (4)
        if (currenty + 2 <= 7 && currentx + 1 <= 7) // 오른쪽 2 x 3 아래 칸
        {
            if (chesspan[currenty + 2].pan[currentx + 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[currenty + 2].pan[currentx + 1].GetComponent<SquareController>().isWhite)
                {
                    colorStack.Add(chesspan[currenty + 2].pan[currentx + 1].gameObject);
                }
            }
            else
            {
                colorStack.Add(chesspan[currenty + 2].pan[currentx + 1].gameObject);
            }
        }
        // (5)
        if (currenty - 2 >= 0 && currentx - 1 >= 0) // 왼쪽 2 x 3 위 칸
        {
            if (chesspan[currenty - 2].pan[currentx - 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[currenty - 2].pan[currentx - 1].GetComponent<SquareController>().isWhite)
                {
                    colorStack.Add(chesspan[currenty - 2].pan[currentx - 1].gameObject);
                }
            }
            else
            {
                colorStack.Add(chesspan[currenty - 2].pan[currentx - 1].gameObject);
            }
        }
        // (6)
        if (currenty - 1 >= 0 && currentx - 2 >= 0) // 왼쪽 3 x 2 위 칸
        {
            if (chesspan[currenty - 1].pan[currentx - 2].GetComponent<SquareController>().exists)
            {
                if (chesspan[currenty - 1].pan[currentx - 2].GetComponent<SquareController>().isWhite)
                {
                    colorStack.Add(chesspan[currenty - 1].pan[currentx - 2].gameObject);
                }
            }
            else
            {
                colorStack.Add(chesspan[currenty - 1].pan[currentx - 2].gameObject);
            }
        }
        // (7)
        if (currenty + 1 <= 7 && currentx - 2 >= 0) // 왼쪽 3 x 2 아래 칸
        {
            if (chesspan[currenty + 1].pan[currentx - 2].GetComponent<SquareController>().exists)
            {
                if (chesspan[currenty + 1].pan[currentx - 2].GetComponent<SquareController>().isWhite)
                {
                    colorStack.Add(chesspan[currenty + 1].pan[currentx - 2].gameObject);
                }
            }
            else
            {
                colorStack.Add(chesspan[currenty + 1].pan[currentx - 2].gameObject);
            }
        }
        // (8)
        if (currenty + 2 <= 7 && currentx - 1 >= 0) // 왼쪽 2 x 3 아래 칸
        {
            if (chesspan[currenty + 2].pan[currentx - 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[currenty + 2].pan[currentx - 1].GetComponent<SquareController>().isWhite)
                {
                    colorStack.Add(chesspan[currenty + 2].pan[currentx - 1].gameObject);
                }
            }
            else
            {
                colorStack.Add(chesspan[currenty + 2].pan[currentx - 1].gameObject);
            }
        }

        colorDraw(ref colorStack);
    }

    void b_knightCheck(int x, int y)
    {
        // (1)
        if (y - 2 >= 0 && x + 1 <= 7) // 오른쪽 2 x 3 위 칸
        {
            if (chesspan[y - 2].pan[x + 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[y - 2].pan[x + 1].GetComponent<SquareController>().mal == Mal.is_w_king)
                {
                    w_kingCanMove();
                }
            }
        }
        // (2)
        if (y - 1 >= 0 && x + 2 <= 7) // 오른쪽 3 x 2 위 칸
        {
            if (chesspan[y - 1].pan[x + 2].GetComponent<SquareController>().exists)
            {
                if (chesspan[y - 1].pan[x + 2].GetComponent<SquareController>().mal == Mal.is_w_king)
                {
                    w_kingCanMove();
                }
            }
        }
        // (3)
        if (y + 1 <= 7 && x + 2 <= 7) // 오른쪽 3 x 2 아래 칸
        {
            if (chesspan[y + 1].pan[x + 2].GetComponent<SquareController>().exists)
            {
                if (chesspan[y + 1].pan[x + 2].GetComponent<SquareController>().mal == Mal.is_w_king)
                {
                    w_kingCanMove();
                }
            }
        }
        // (4)
        if (y + 2 <= 7 && x + 1 <= 7) // 오른쪽 2 x 3 아래 칸
        {
            if (chesspan[y + 2].pan[x + 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[y + 2].pan[x + 1].GetComponent<SquareController>().mal == Mal.is_w_king)
                {
                    w_kingCanMove();
                }
            }
        }
        // (5)
        if (y - 2 >= 0 && x - 1 >= 0) // 왼쪽 2 x 3 위 칸
        {
            if (chesspan[y - 2].pan[x - 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[y - 2].pan[x - 1].GetComponent<SquareController>().mal == Mal.is_w_king)
                {
                    w_kingCanMove();
                }
            }
        }
        // (6)
        if (y - 1 >= 0 && x - 2 >= 0) // 왼쪽 3 x 2 위 칸
        {
            if (chesspan[y - 1].pan[x - 2].GetComponent<SquareController>().exists)
            {
                if (chesspan[y - 1].pan[x - 2].GetComponent<SquareController>().mal == Mal.is_w_king)
                {
                    w_kingCanMove();
                }
            }
        }
        // (7)
        if (y + 1 <= 7 && x - 2 >= 0) // 왼쪽 3 x 2 아래 칸
        {
            if (chesspan[y + 1].pan[x - 2].GetComponent<SquareController>().exists)
            {
                if (chesspan[y + 1].pan[x - 2].GetComponent<SquareController>().mal == Mal.is_w_king)
                {
                    w_kingCanMove();
                }
            }
        }
        // (8)
        if (y + 2 <= 7 && x - 1 >= 0) // 왼쪽 2 x 3 아래 칸
        {
            if (chesspan[y + 2].pan[x - 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[y + 2].pan[x - 1].GetComponent<SquareController>().mal == Mal.is_w_king)
                {
                    w_kingCanMove();
                }
            }
        }
    }

    void w_queenMove()
    {
        List<GameObject> colorStack = new List<GameObject>(); //이동 가능한 것들 다 담아놓기


        for (int i = 1; i < 8; i++)
        {
            if (currenty - i >= 0 && currentx + i <= 7) // 오른쪽 위 대각선
            {
                if (chesspan[currenty - i].pan[currentx + i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty - i].pan[currentx + i].GetComponent<SquareController>().isBlack)
                    {
                        colorStack.Add(chesspan[currenty - i].pan[currentx + i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
                else
                {
                    colorStack.Add(chesspan[currenty - i].pan[currentx + i].gameObject);
                }
            }
            else
            {
                break;
            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (currenty - i >= 0 && currentx - i >= 0) // 왼쪽 위 대각선
            {
                if (chesspan[currenty - i].pan[currentx - i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty - i].pan[currentx - i].GetComponent<SquareController>().isBlack)
                    {
                        colorStack.Add(chesspan[currenty - i].pan[currentx - i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
                else
                {
                    colorStack.Add(chesspan[currenty - i].pan[currentx - i].gameObject);
                }
            }
            else
            {
                break;
            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (currenty + i <= 7 && currentx + i <= 7) // 오른쪽 아래 대각선
            {
                if (chesspan[currenty + i].pan[currentx + i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty + i].pan[currentx + i].GetComponent<SquareController>().isBlack)
                    {
                        colorStack.Add(chesspan[currenty + i].pan[currentx + i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
                else
                {
                    colorStack.Add(chesspan[currenty + i].pan[currentx + i].gameObject);
                }
            }
            else
            {
                break;
            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (currenty + i <= 7 && currentx - i >= 0) // 왼쪽 아래 대각선
            {
                if (chesspan[currenty + i].pan[currentx - i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty + i].pan[currentx - i].GetComponent<SquareController>().isBlack)
                    {
                        colorStack.Add(chesspan[currenty + i].pan[currentx - i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
                else
                {
                    colorStack.Add(chesspan[currenty + i].pan[currentx - i].gameObject);
                }
            }
            else
            {
                break;
            }

        }
        for (int i = 1; i < 8; i++) // 위로 어디까지 갈수 있나 확인
        {
            if (currenty - i >= 0)
            {
                if (chesspan[currenty - i].pan[currentx].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty - i].pan[currentx].GetComponent<SquareController>().isBlack)
                    {
                        colorStack.Add(chesspan[currenty - i].pan[currentx].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    colorStack.Add(chesspan[currenty - i].pan[currentx].gameObject);
                }
            }
            else
            {
                break;
            }
        }

        for (int i = 1; i < 8; i++) // 아래로 어디까지 갈수 있나 확인
        {
            if (currenty + i <= 7)
            {
                if (chesspan[currenty + i].pan[currentx].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty + i].pan[currentx].GetComponent<SquareController>().isBlack)
                    {
                        colorStack.Add(chesspan[currenty + i].pan[currentx].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    colorStack.Add(chesspan[currenty + i].pan[currentx].gameObject);
                }
            }
            else
            {
                break;
            }
        }

        for (int i = 1; i < 8; i++) // 왼쪽으로 어디까지 갈수 있나 확인
        {
            if (currentx - i >= 0)
            {
                if (chesspan[currenty].pan[currentx - i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty].pan[currentx - i].GetComponent<SquareController>().isBlack)
                    {
                        colorStack.Add(chesspan[currenty].pan[currentx - i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    colorStack.Add(chesspan[currenty].pan[currentx - i].gameObject);
                }
            }
            else
            {
                break;
            }
        }
        for (int i = 1; i < 8; i++) // 오른쪽으로 어디까지 갈수 있나 확인
        {
            if (currentx + i <= 7)
            {
                if (chesspan[currenty].pan[currentx + i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty].pan[currentx + i].GetComponent<SquareController>().isBlack)
                    {
                        colorStack.Add(chesspan[currenty].pan[currentx + i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    colorStack.Add(chesspan[currenty].pan[currentx + i].gameObject);
                }
            }
            else
            {
                break;
            }
        }
        colorDraw(ref colorStack);
    }

    void b_queenMove()
    {
        List<GameObject> colorStack = new List<GameObject>(); //이동 가능한 것들 다 담아놓기


        for (int i = 1; i < 8; i++)
        {
            if (currenty - i >= 0 && currentx + i <= 7) // 오른쪽 위 대각선
            {
                if (chesspan[currenty - i].pan[currentx + i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty - i].pan[currentx + i].GetComponent<SquareController>().isWhite)
                    {
                        colorStack.Add(chesspan[currenty - i].pan[currentx + i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
                else
                {
                    colorStack.Add(chesspan[currenty - i].pan[currentx + i].gameObject);
                }
            }
            else
            {
                break;
            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (currenty - i >= 0 && currentx - i >= 0) // 왼쪽 위 대각선
            {
                if (chesspan[currenty - i].pan[currentx - i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty - i].pan[currentx - i].GetComponent<SquareController>().isWhite)
                    {
                        colorStack.Add(chesspan[currenty - i].pan[currentx - i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
                else
                {
                    colorStack.Add(chesspan[currenty - i].pan[currentx - i].gameObject);
                }
            }
            else
            {
                break;
            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (currenty + i <= 7 && currentx + i <= 7) // 오른쪽 아래 대각선
            {
                if (chesspan[currenty + i].pan[currentx + i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty + i].pan[currentx + i].GetComponent<SquareController>().isWhite)
                    {
                        colorStack.Add(chesspan[currenty + i].pan[currentx + i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
                else
                {
                    colorStack.Add(chesspan[currenty + i].pan[currentx + i].gameObject);
                }
            }
            else
            {
                break;
            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (currenty + i <= 7 && currentx - i >= 0) // 왼쪽 아래 대각선
            {
                if (chesspan[currenty + i].pan[currentx - i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty + i].pan[currentx - i].GetComponent<SquareController>().isWhite)
                    {
                        colorStack.Add(chesspan[currenty + i].pan[currentx - i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }


                }
                else
                {
                    colorStack.Add(chesspan[currenty + i].pan[currentx - i].gameObject);
                }
            }
            else
            {
                break;
            }

        }
        for (int i = 1; i < 8; i++) // 위로 어디까지 갈수 있나 확인
        {
            if (currenty - i >= 0)
            {
                if (chesspan[currenty - i].pan[currentx].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty - i].pan[currentx].GetComponent<SquareController>().isWhite)
                    {
                        colorStack.Add(chesspan[currenty - i].pan[currentx].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    colorStack.Add(chesspan[currenty - i].pan[currentx].gameObject);
                }
            }
            else
            {
                break;
            }
        }

        for (int i = 1; i < 8; i++) // 아래로 어디까지 갈수 있나 확인
        {
            if (currenty + i <= 7)
            {
                if (chesspan[currenty + i].pan[currentx].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty + i].pan[currentx].GetComponent<SquareController>().isWhite)
                    {
                        colorStack.Add(chesspan[currenty + i].pan[currentx].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    colorStack.Add(chesspan[currenty + i].pan[currentx].gameObject);
                }
            }
            else
            {
                break;
            }
        }

        for (int i = 1; i < 8; i++) // 왼쪽으로 어디까지 갈수 있나 확인
        {
            if (currentx - i >= 0)
            {
                if (chesspan[currenty].pan[currentx - i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty].pan[currentx - i].GetComponent<SquareController>().isWhite)
                    {
                        colorStack.Add(chesspan[currenty].pan[currentx - i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    colorStack.Add(chesspan[currenty].pan[currentx - i].gameObject);
                }
            }
            else
            {
                break;
            }
        }
        for (int i = 1; i < 8; i++) // 오른쪽으로 어디까지 갈수 있나 확인
        {
            if (currentx + i <= 7)
            {
                if (chesspan[currenty].pan[currentx + i].GetComponent<SquareController>().exists)
                {
                    if (chesspan[currenty].pan[currentx + i].GetComponent<SquareController>().isWhite)
                    {
                        colorStack.Add(chesspan[currenty].pan[currentx + i].gameObject);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    colorStack.Add(chesspan[currenty].pan[currentx + i].gameObject);
                }
            }
            else
            {
                break;
            }
        }
        colorDraw(ref colorStack);
    }

    void w_kingMove()
    {
        List<GameObject> colorStack = new List<GameObject>(); //이동 가능한 것들 다 담아놓기

        int[,] panArray = new int[8, 8];

        int x = whiteking_x;
        int y = whiteking_y;


        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                panArray[i, j] = 0;
            }
        }

        panArray[whiteking_x, whiteking_y] = 3;


        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (chesspan[j].pan[i].GetComponent<SquareController>().exists)
                {
                    panArray[i, j] = 1;

                    if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_b_pawn)
                    {
                        b_pawn2maker(i, j, panArray);
                    }
                    else if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_b_rook)
                    {
                        rook2maker(i, j, panArray);
                    }
                    else if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_b_bishop)
                    {
                        bishop2maker(i, j, panArray);
                    }
                    else if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_b_queen)
                    {
                        bishop2maker(i, j, panArray);
                        rook2maker(i, j, panArray);
                    }
                    else if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_b_knight)
                    {
                        knight2maker(i, j, panArray);
                    }
                    else if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_b_king)
                    {
                        king2maker(i, j, panArray);
                    }
                }

            }
        }

        

        if (x - 1 >= 0) // 왼쪽
        {
            if (panArray[x - 1, y] == 0) colorStack.Add(chesspan[y].pan[x - 1].gameObject);
        }
        if (x + 1 <= 7) // 오른쪽
        {
            if (panArray[x + 1, y] == 0) colorStack.Add(chesspan[y].pan[x + 1].gameObject);
        }
        if (y - 1 >= 0) // 윗쪽
        {
            if (panArray[x, y - 1] == 0) colorStack.Add(chesspan[y - 1].pan[x].gameObject);
        }
        if (y + 1 <= 7) // 아랫쪽
        {
            if (panArray[x, y + 1] == 0) colorStack.Add(chesspan[y + 1].pan[x].gameObject);
        }
        if (y - 1 >= 0 && x - 1 >= 0) // 왼쪽 위
        {
            if (panArray[x - 1, y - 1] == 0) colorStack.Add(chesspan[y - 1].pan[x - 1].gameObject);
        }
        if (y - 1 >= 0 && x + 1 <= 7) // 오른쪽 위
        {
            if (panArray[x + 1, y - 1] == 0) colorStack.Add(chesspan[y - 1].pan[x + 1].gameObject);
        }
        if (y + 1 <= 7 && x - 1 >= 0) // 왼쪽 아래 
        {
            if (panArray[x - 1, y + 1] == 0) colorStack.Add(chesspan[y + 1].pan[x - 1].gameObject);
        }
        if (y + 1 <= 7 && x + 1 <= 7) // 오른쪽 아래 
        {
            if (panArray[x + 1, y + 1] == 0) colorStack.Add(chesspan[y + 1].pan[x + 1].gameObject);
        }

        colorDraw(ref colorStack);

    }

    void w_kingCheck(int x, int y)
    {
        if (x - 1 >= 0) // 왼쪽
        {
            if (chesspan[y].pan[x - 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[y].pan[x - 1].GetComponent<SquareController>().mal == Mal.is_b_king)
                {
                    b_kingCanMove();
                }
            }
        }
        if (x + 1 <= 7) // 오른쪽
        {
            if (chesspan[y].pan[x + 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[y].pan[x + 1].GetComponent<SquareController>().mal == Mal.is_b_king)
                {
                    b_kingCanMove();
                }
            }
        }
        if (y - 1 >= 0) // 윗쪽
        {
            if (chesspan[y - 1].pan[x].GetComponent<SquareController>().exists)
            {
                if (chesspan[y - 1].pan[x].GetComponent<SquareController>().mal == Mal.is_b_king)
                {
                    b_kingCanMove();
                }
            }
        }
        if (y + 1 <= 7) // 아랫쪽
        {
            if (chesspan[y + 1].pan[x].GetComponent<SquareController>().exists)
            {
                if (chesspan[y + 1].pan[x].GetComponent<SquareController>().mal == Mal.is_b_king)
                {
                    b_kingCanMove();
                }
            }
        }
        if (y - 1 >= 0 && x - 1 >= 0) // 왼쪽 위
        {
            if (chesspan[y - 1].pan[x - 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[y - 1].pan[x - 1].GetComponent<SquareController>().mal == Mal.is_b_king)
                {
                    b_kingCanMove();
                }
            }
        }
        if (y - 1 >= 0 && x + 1 <= 7) // 오른쪽 위
        {
            if (chesspan[y - 1].pan[x + 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[y - 1].pan[x + 1].GetComponent<SquareController>().mal == Mal.is_b_king)
                {
                    b_kingCanMove();
                }
            }
        }
        if (y + 1 <= 7 && x - 1 >= 0) // 왼쪽 아래 
        {
            if (chesspan[y + 1].pan[x - 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[y + 1].pan[x - 1].GetComponent<SquareController>().mal == Mal.is_b_king)
                {
                    b_kingCanMove();
                }
            }
        }
        if (y + 1 <= 7 && x + 1 <= 7) // 오른쪽 아래 
        {
            if (chesspan[y + 1].pan[x + 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[y + 1].pan[x + 1].GetComponent<SquareController>().mal == Mal.is_b_king)
                {
                    b_kingCanMove();
                }
            }
        }
    }

    void b_kingMove()
    {
        List<GameObject> colorStack = new List<GameObject>(); //이동 가능한 것들 다 담아놓기

        int[,] panArray = new int[8, 8];

        int x = blackking_x;
        int y = blackking_y;


        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                panArray[i, j] = 0;
            }
        }

        panArray[blackking_x, blackking_y] = 3;


        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (chesspan[j].pan[i].GetComponent<SquareController>().exists)
                {
                    panArray[i, j] = 1;

                    if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_w_pawn)
                    {
                        w_pawn2maker(i, j, panArray);
                    }
                    else if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_w_rook)
                    {
                        rook2maker(i, j, panArray);
                    }
                    else if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_w_bishop)
                    {
                        bishop2maker(i, j, panArray);
                    }
                    else if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_w_queen)
                    {
                        bishop2maker(i, j, panArray);
                        rook2maker(i, j, panArray);
                    }
                    else if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_w_knight)
                    {
                        knight2maker(i, j, panArray);
                    }
                    else if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_w_king)
                    {
                        king2maker(i, j, panArray);
                    }
                }

            }
        }

        

        if (x - 1 >= 0) // 왼쪽
        {
            if (panArray[x - 1, y] == 0) colorStack.Add(chesspan[y].pan[x - 1].gameObject);
        }
        if (x + 1 <= 7) // 오른쪽
        {
            if (panArray[x + 1, y] == 0) colorStack.Add(chesspan[y].pan[x + 1].gameObject);
        }
        if (y - 1 >= 0) // 윗쪽
        {
            if (panArray[x, y - 1] == 0) colorStack.Add(chesspan[y - 1].pan[x].gameObject);
        }
        if (y + 1 <= 7) // 아랫쪽
        {
            if (panArray[x, y + 1] == 0) colorStack.Add(chesspan[y + 1].pan[x].gameObject);
        }
        if (y - 1 >= 0 && x - 1 >= 0) // 왼쪽 위
        {
            if (panArray[x - 1, y - 1] == 0) colorStack.Add(chesspan[y - 1].pan[x - 1].gameObject);
        }
        if (y - 1 >= 0 && x + 1 <= 7) // 오른쪽 위
        {
            if (panArray[x + 1, y - 1] == 0) colorStack.Add(chesspan[y - 1].pan[x + 1].gameObject);
        }
        if (y + 1 <= 7 && x - 1 >= 0) // 왼쪽 아래 
        {
            if (panArray[x - 1, y + 1] == 0) colorStack.Add(chesspan[y + 1].pan[x - 1].gameObject);
        }
        if (y + 1 <= 7 && x + 1 <= 7) // 오른쪽 아래 
        {
            if (panArray[x + 1, y + 1] == 0) colorStack.Add(chesspan[y + 1].pan[x + 1].gameObject);
        }

        colorDraw(ref colorStack);

    }

    void b_kingCheck(int x, int y)
    {
        if (x - 1 >= 0) // 왼쪽
        {
            if (chesspan[y].pan[x - 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[y].pan[x - 1].GetComponent<SquareController>().mal == Mal.is_w_king)
                {
                    w_kingCanMove();
                }
            }
        }
        if (x + 1 <= 7) // 오른쪽
        {
            if (chesspan[y].pan[x + 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[y].pan[x + 1].GetComponent<SquareController>().mal == Mal.is_w_king)
                {
                    w_kingCanMove();
                }
            }
        }
        if (y - 1 >= 0) // 윗쪽
        {
            if (chesspan[y - 1].pan[x].GetComponent<SquareController>().exists)
            {
                if (chesspan[y - 1].pan[x].GetComponent<SquareController>().mal == Mal.is_w_king)
                {
                    w_kingCanMove();
                }
            }
        }
        if (y + 1 <= 7) // 아랫쪽
        {
            if (chesspan[y + 1].pan[x].GetComponent<SquareController>().exists)
            {
                if (chesspan[y + 1].pan[x].GetComponent<SquareController>().mal == Mal.is_w_king)
                {
                    w_kingCanMove();
                }
            }
        }
        if (y - 1 >= 0 && x - 1 >= 0) // 왼쪽 위
        {
            if (chesspan[y - 1].pan[x - 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[y - 1].pan[x - 1].GetComponent<SquareController>().mal == Mal.is_w_king)
                {
                    w_kingCanMove();
                }
            }
        }
        if (y - 1 >= 0 && x + 1 <= 7) // 오른쪽 위
        {
            if (chesspan[y - 1].pan[x + 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[y - 1].pan[x + 1].GetComponent<SquareController>().mal == Mal.is_w_king)
                {
                    w_kingCanMove();
                }
            }
        }
        if (y + 1 <= 7 && x - 1 >= 0) // 왼쪽 아래 
        {
            if (chesspan[y + 1].pan[x - 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[y + 1].pan[x - 1].GetComponent<SquareController>().mal == Mal.is_w_king)
                {
                    w_kingCanMove();
                }
            }
        }
        if (y + 1 <= 7 && x + 1 <= 7) // 오른쪽 아래 
        {
            if (chesspan[y + 1].pan[x + 1].GetComponent<SquareController>().exists)
            {
                if (chesspan[y + 1].pan[x + 1].GetComponent<SquareController>().mal == Mal.is_w_king)
                {
                    w_kingCanMove();
                }
            }
        }

    }

    void w_pawn2maker(int x, int y, int[,] panArray)
    {
        if (x > 0 && y > 0 && panArray[x - 1, y - 1] != 1)
        {
            panArray[x - 1, y - 1] = 2;
        }

        if (x < 7 && y > 0 && panArray[x + 1, y - 1] != 1)
        {
            panArray[x + 1, y - 1] = 2;
        }
    }

    void b_pawn2maker(int x, int y, int[,] panArray)
    {
        if (x > 0 && y < 7 && panArray[x - 1, y + 1] != 1)
        {
            panArray[x - 1, y + 1] = 2;
        }

        if (x < 7 && y < 7 && panArray[x + 1, y + 1] != 1)
        {
            panArray[x + 1, y + 1] = 2;
        }
    }

    void rook2maker(int x, int y, int[,] panArray)
    {
        for (int i = 1; i < 8; i++) // 위로 어디까지 갈수 있나 확인
        {
            if (y - i >= 0)
            {
                if (panArray[x, y - i] == 1) break;
                else if (panArray[x, y - i] == 3) continue;
                else panArray[x, y - i] = 2;
            }
            else break;

        }

        for (int i = 1; i < 8; i++) // 아래로 어디까지 갈수 있나 확인
        {
            if (y + i <= 7)
            {
                if (panArray[x, y + i] == 1) break;
                else if (panArray[x, y + i] == 3) continue;
                else panArray[x, y + i] = 2;
            }
            else break;
        }

        for (int i = 1; i < 8; i++) // 왼쪽으로 어디까지 갈수 있나 확인
        {
            if (x - i >= 0)
            {
                if (panArray[x - i, y] == 1) break;
                else if (panArray[x - i, y] == 3) continue;
                else panArray[x - i, y] = 2;
            }
            else break;
        }
        for (int i = 1; i < 8; i++) // 오른쪽으로 어디까지 갈수 있나 확인
        {
            if (x + i <= 7)
            {
                if (panArray[x + i, y] == 1) break;
                else if (panArray[x + i, y] == 3) continue;
                else panArray[x + i, y] = 2;
            }
            else break;
        }
    }

    void bishop2maker(int x, int y, int[,] panArray)
    {
        for (int i = 1; i < 8; i++)
        {
            if (y - i >= 0 && x + i <= 7) // 오른쪽 위 대각선
            {
                if (panArray[x + i, y - i] == 1) break;
                else if (panArray[x + i, y - i] == 3) continue;
                else panArray[x + i, y - i] = 2;
            }
            else
            {
                break;
            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (y - i >= 0 && x - i >= 0) // 왼쪽 위 대각선
            {
                if (panArray[x - i, y - i] == 1) break;
                else if (panArray[x - i, y - i] == 3) continue;
                else panArray[x - i, y - i] = 2;
            }
            else
            {
                break;
            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (y + i <= 7 && x + i <= 7) // 오른쪽 아래 대각선
            {
                if (panArray[x + i, y + i] == 1) break;
                else if (panArray[x + i, y + i] == 3) continue;
                else panArray[x + i, y + i] = 2;
            }
            else
            {
                break;
            }

        }

        for (int i = 1; i < 8; i++)
        {
            if (y + i <= 7 && x - i >= 0) // 왼쪽 아래 대각선
            {
                if (panArray[x - i, y + i] == 1) break;
                else if (panArray[x - i, y + i] == 3) continue;
                else panArray[x - i, y + i] = 2;
            }
            else
            {
                break;
            }

        }
    }

    void knight2maker(int x, int y, int[,] panArray)
    {
        // (1)
        if (y - 2 >= 0 && x + 1 <= 7) // 오른쪽 2 x 3 위 칸
        {
            if (panArray[x + 1, y - 2] == 0) panArray[x + 1, y - 2] = 2;
        }
        // (2)
        if (y - 1 >= 0 && x + 2 <= 7) // 오른쪽 3 x 2 위 칸
        {
            if (panArray[x + 2, y - 1] == 0) panArray[x + 2, y - 1] = 2;
        }
        // (3)
        if (y + 1 <= 7 && x + 2 <= 7) // 오른쪽 3 x 2 아래 칸
        {
            if (panArray[x + 2, y + 1] == 0) panArray[x + 2, y + 1] = 2;
        }
        // (4)
        if (y + 2 <= 7 && x + 1 <= 7) // 오른쪽 2 x 3 아래 칸
        {
            if (panArray[x + 1, y + 2] == 0) panArray[x + 1, y + 2] = 2;
        }
        // (5)
        if (y - 2 >= 0 && x - 1 >= 0) // 왼쪽 2 x 3 위 칸
        {
            if (panArray[x - 1, y - 2] == 0) panArray[x - 1, y - 2] = 2;
        }
        // (6)
        if (y - 1 >= 0 && x - 2 >= 0) // 왼쪽 3 x 2 위 칸
        {
            if (panArray[x - 2, y - 1] == 0) panArray[x - 2, y - 1] = 2;
        }
        // (7)
        if (y + 1 <= 7 && x - 2 >= 0) // 왼쪽 3 x 2 아래 칸
        {
            if (panArray[x - 2, y + 1] == 0) panArray[x - 2, y + 1] = 2;
        }
        // (8)
        if (y + 2 <= 7 && x - 1 >= 0) // 왼쪽 2 x 3 아래 칸
        {
            if (panArray[x - 1, y + 2] == 0) panArray[x - 1, y + 2] = 2;
        }
    }

    void king2maker(int x, int y, int[,] panArray)
    {
        if (x - 1 >= 0) // 왼쪽
        {
            if (panArray[x - 1, y] == 0) panArray[x - 1, y] = 2;
        }
        if (x + 1 <= 7) // 오른쪽
        {
            if (panArray[x + 1, y] == 0) panArray[x + 1, y] = 2;
        }
        if (y - 1 >= 0) // 윗쪽
        {
            if (panArray[x, y - 1] == 0) panArray[x, y - 1] = 2;
        }
        if (y + 1 <= 7) // 아랫쪽
        {
            if (panArray[x, y + 1] == 0) panArray[x, y + 1] = 2;
        }
        if (y - 1 >= 0 && x - 1 >= 0) // 왼쪽 위
        {
            if (panArray[x - 1, y - 1] == 0) panArray[x - 1, y - 1] = 2;
        }
        if (y - 1 >= 0 && x + 1 <= 7) // 오른쪽 위
        {
            if (panArray[x + 1, y - 1] == 0) panArray[x + 1, y - 1] = 2;
        }
        if (y + 1 <= 7 && x - 1 >= 0) // 왼쪽 아래 
        {
            if (panArray[x - 1, y + 1] == 0) panArray[x - 1, y + 1] = 2;
        }
        if (y + 1 <= 7 && x + 1 <= 7) // 오른쪽 아래 
        {
            if (panArray[x + 1, y + 1] == 0) panArray[x + 1, y + 1] = 2;
        }
    }

    // 체크메이트 구현
    // 말의 이동이 킹에 닿으면 체크메이트 상황 -> 킹의 주변을 둘러보면서 역추적으로 찾기
    // 체크메이트 상황일 때 아래의 함수 불러보자

    void w_kingCanMove()
    {
        wking_dangerous = true;

        int[,] panArray = new int[8, 8];

        int x = whiteking_x;
        int y = whiteking_y;


        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                panArray[i, j] = 0;
            }
        }

        panArray[whiteking_x, whiteking_y] = 3;


        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (chesspan[j].pan[i].GetComponent<SquareController>().exists)
                {
                    panArray[i, j] = 1;

                    if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_b_pawn)
                    {
                        b_pawn2maker(i, j, panArray);
                    }
                    else if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_b_rook)
                    {
                        rook2maker(i, j, panArray);
                    }
                    else if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_b_bishop)
                    {
                        bishop2maker(i, j, panArray);
                    }
                    else if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_b_queen)
                    {
                        bishop2maker(i, j, panArray);
                        rook2maker(i, j, panArray);
                    }
                    else if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_b_knight)
                    {
                        knight2maker(i, j, panArray);
                    }
                    else if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_b_king)
                    {
                        king2maker(i, j, panArray);
                    }
                }

            }
        }

        bool canMove = false;

        if (x - 1 >= 0) // 왼쪽
        {
            if (panArray[x - 1, y] == 0) canMove = true;
        }
        if (x + 1 <= 7) // 오른쪽
        {
            if (panArray[x + 1, y] == 0) canMove = true;
        }
        if (y - 1 >= 0) // 윗쪽
        {
            if (panArray[x, y - 1] == 0) canMove = true;
        }
        if (y + 1 <= 7) // 아랫쪽
        {
            if (panArray[x, y + 1] == 0) canMove = true;
        }
        if (y - 1 >= 0 && x - 1 >= 0) // 왼쪽 위
        {
            if (panArray[x - 1, y - 1] == 0) canMove = true;
        }
        if (y - 1 >= 0 && x + 1 <= 7) // 오른쪽 위
        {
            if (panArray[x + 1, y - 1] == 0) canMove = true;
        }
        if (y + 1 <= 7 && x - 1 >= 0) // 왼쪽 아래 
        {
            if (panArray[x - 1, y + 1] == 0) canMove = true;
        }
        if (y + 1 <= 7 && x + 1 <= 7) // 오른쪽 아래 
        {
            if (panArray[x + 1, y + 1] == 0) canMove = true;
        }

        if (canMove == false)
        {
            b_win();
        }


    }

    void b_kingCanMove()
    {
        bking_dangerous = true;
        int[,] panArray = new int[8, 8];

        int x = blackking_x;
        int y = blackking_y;


        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                panArray[i, j] = 0;
            }
        }

        panArray[blackking_x, blackking_y] = 3;


        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (chesspan[j].pan[i].GetComponent<SquareController>().exists)
                {
                    panArray[i, j] = 1;

                    if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_w_pawn)
                    {
                        w_pawn2maker(i, j, panArray);
                    }
                    else if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_w_rook)
                    {
                        rook2maker(i, j, panArray);
                    }
                    else if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_w_bishop)
                    {
                        bishop2maker(i, j, panArray);
                    }
                    else if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_w_queen)
                    {
                        bishop2maker(i, j, panArray);
                        rook2maker(i, j, panArray);
                    }
                    else if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_w_knight)
                    {
                        knight2maker(i, j, panArray);
                    }
                    else if (chesspan[j].pan[i].GetComponent<SquareController>().mal == Mal.is_w_king)
                    {
                        king2maker(i, j, panArray);
                    }
                }

            }
        }

        bool canMove = false;

        if (x - 1 >= 0) // 왼쪽
        {
            if (panArray[x - 1, y] == 0) canMove = true;
        }
        if (x + 1 <= 7) // 오른쪽
        {
            if (panArray[x + 1, y] == 0) canMove = true;
        }
        if (y - 1 >= 0) // 윗쪽
        {
            if (panArray[x, y - 1] == 0) canMove = true;
        }
        if (y + 1 <= 7) // 아랫쪽
        {
            if (panArray[x, y + 1] == 0) canMove = true;
        }
        if (y - 1 >= 0 && x - 1 >= 0) // 왼쪽 위
        {
            if (panArray[x - 1, y - 1] == 0) canMove = true;
        }
        if (y - 1 >= 0 && x + 1 <= 7) // 오른쪽 위
        {
            if (panArray[x + 1, y - 1] == 0) canMove = true;
        }
        if (y + 1 <= 7 && x - 1 >= 0) // 왼쪽 아래 
        {
            if (panArray[x - 1, y + 1] == 0) canMove = true;
        }
        if (y + 1 <= 7 && x + 1 <= 7) // 오른쪽 아래 
        {
            if (panArray[x + 1, y + 1] == 0) canMove = true;
        }

        if (canMove == false)
        {
            w_win();
        }

    }


    void w_win()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {

                chesspan[i].pan[j].gameObject.GetComponentInChildren<Button>().interactable = false;

            }
        }

        w_winimage.enabled = true;
    }

    void b_win()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {

                chesspan[i].pan[j].gameObject.GetComponentInChildren<Button>().interactable = false;

            }
        }
        b_winimage.enabled = true;
    }
    
}
