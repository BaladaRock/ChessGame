using ChessGame.model;
using System.Drawing;
using System.Windows.Forms;

namespace ChessGame
{
    internal class ChessBoard
    {
        private const string blackColor = "black";

        private const int RookIndex = 7;

        private const int KnightLeftIndex = 1;

        private const int KnightRightIndex = 6;

        private const int BishopLeftIndex = 2;

        private const int BishopRightIndex = 5;

        private const int QueenIndex = 3;

        private const int KingIndex = 4;

        private readonly FormChessBoard chessBoard;

        private ChessGame.model.ChessBoard chessSquares;

        private readonly int leftMargin;

        private readonly int upperMargin;

        private readonly int gutterLength;

        private readonly int rectangleLength;

        public int Size { get; private set; }

        public ChessBoard(FormChessBoard chessBoard, int leftMargin, int upperMargin, int borderThickness)
        {
            this.chessBoard = chessBoard;
            this.leftMargin = leftMargin;
            this.upperMargin = upperMargin;
            gutterLength = leftMargin * KingIndex;
            rectangleLength = (BishopLeftIndex * gutterLength) + (KingIndex * borderThickness);
            DrawOutline(borderThickness);
        }

        internal void AddChessPieces()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    switch (j)
                    {
                        case 0:
                            AddBlackBackPieces(i, j);
                            break;

                        case KnightLeftIndex:
                            AddBlackPawns(i, j);
                            break;

                        case 6:
                            AddWhitePawns(i, j);
                            break;

                        case RookIndex:
                            AddWhiteBackPieces(i, j);
                            break;
                    }
                }
            }
        }

        private void AddWhiteBackPieces(int rowIndex, int columnIndex)
        {
            AddRooks(rowIndex, columnIndex, "white");
            AddKnights(rowIndex, columnIndex, "white");
            AddBishops(rowIndex, columnIndex, "white");
            AddQueen(rowIndex, columnIndex, "white");
            AddKing(rowIndex, columnIndex, "white");
        }

        private void AddKing(int rowIndex, int columnIndex, string colorType = blackColor)
        {
            if (rowIndex != KingIndex)
            {
                return;
            }

            var imageColor = colorType == blackColor ? Properties.Resources.black_king : Properties.Resources.white_king;
            AddPieceAndImage(rowIndex, columnIndex, new King(colorType == blackColor ? ColorType.black : ColorType.white), imageColor);
        }

        private void AddPieceAndImage(int rowIndex, int columnIndex, ChessPiece newKing, Bitmap imageColor)
        {
            InsertImage(rowIndex, columnIndex, imageColor);
            newKing.OccupySquare(chessSquares.GetSquare(rowIndex, columnIndex));
        }

        private void AddQueen(int rowIndex, int columnIndex, string colorType = blackColor)
        {
            if (rowIndex != QueenIndex)
            {
                return;
            }

            var imageColor = colorType == blackColor ? Properties.Resources.black_queen : Properties.Resources.white_queen;
            AddPieceAndImage(rowIndex, columnIndex, new Queen(colorType == blackColor ? ColorType.black : ColorType.white), imageColor);
        }

        private void AddBishops(int rowIndex, int columnIndex, string colorType = blackColor)
        {
            if (rowIndex != BishopLeftIndex && rowIndex != BishopRightIndex)
            {
                return;
            }

            var imageColor = colorType == blackColor ? Properties.Resources.black_bishop : Properties.Resources.white_bishop;
            AddPieceAndImage(rowIndex, columnIndex, new Bishop(colorType == blackColor ? ColorType.black : ColorType.white), imageColor);
        }

        private void AddKnights(int rowIndex, int columnIndex, string colorType = blackColor)
        {
            if (rowIndex != KnightLeftIndex && rowIndex != KnightRightIndex)
            {
                return;
            }

            var imageColor = colorType == blackColor ? Properties.Resources.black_knight : Properties.Resources.white_knight;
            AddPieceAndImage(rowIndex, columnIndex, new Knight(colorType == blackColor ? ColorType.black : ColorType.white), imageColor);
        }

        private void AddRooks(int rowIndex, int columnIndex, string colorType = blackColor)
        {
            if (columnIndex != 0 && columnIndex != RookIndex)
            {
                return;
            }

            var imageColor = colorType == blackColor ? Properties.Resources.black_rook : Properties.Resources.white_rook;
            AddPieceAndImage(rowIndex, columnIndex, new Rook(colorType == blackColor ? ColorType.black : ColorType.white), imageColor);
        }

        private void AddBlackBackPieces(int rowIndex, int columnIndex)
        {
            AddRooks(rowIndex, columnIndex);
            AddKnights(rowIndex, columnIndex);
            AddBishops(rowIndex, columnIndex);
            AddQueen(rowIndex, columnIndex);
            AddKing(rowIndex, columnIndex);
        }

        private void AddWhitePawns(int rowIndex, int columnIndex)
        {
            AddPawns(rowIndex, columnIndex, "white");
        }

        private void AddBlackPawns(int rowIndex, int columnIndex)
        {
            AddPawns(rowIndex, columnIndex);
        }

        private void AddPawns(int rowIndex, int columnIndex, string colorType = blackColor)
        {
            var imageColor = colorType == blackColor ? Properties.Resources.black_pawn : Properties.Resources.white_pawn;
            AddPieceAndImage(rowIndex, columnIndex, new Pawn(colorType == blackColor ? ColorType.black : ColorType.white), imageColor);
        }

        private void InsertImage(int rowIndex, int columnIndex, Bitmap pieceImage)
        {
            int controlIndex = (rowIndex * Size) + columnIndex;
            var chessSquare = chessBoard.Controls[controlIndex];
            chessSquare.BackgroundImage = pieceImage;
            chessSquare.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void DrawOutline(int borderThickness)
        {
            Graphics board = chessBoard.CreateGraphics();
            Brush brown = new SolidBrush(Color.Brown);
            Pen borderPen = new Pen(brown, borderThickness);

            board.DrawRectangle(borderPen, gutterLength - borderThickness,
                upperMargin - borderThickness, rectangleLength, rectangleLength);

            board.Dispose();
            brown.Dispose();
            borderPen.Dispose();
        }

        internal void BuildChessBoard(int size, Color firstSquareColor, Color secondSquareColor)
        {
            Size = size;
            chessSquares = new ChessGame.model.ChessBoard(Size);

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    var chessSquare = new PictureBox
                    {
                        Location = new Point(i + gutterLength + (leftMargin * i), j + upperMargin + (j * leftMargin)),
                        Size = new Size(leftMargin, leftMargin),
                        BackColor = j % BishopLeftIndex == 0 ? firstSquareColor : secondSquareColor
                    };

                    var customSquare = new CustomChessSquare(chessSquares, chessSquare, chessBoard, Size)
                    {
                        X = i,
                        Y = j
                    };

                    chessBoard.Add(customSquare);
                }
                SwapColors(ref firstSquareColor, ref secondSquareColor);
            }
        }

        private void SwapColors(ref Color firstColor, ref Color secondColor)
        {
            Color tempColor = firstColor;
            firstColor = secondColor;
            secondColor = tempColor;
        }
    }
}