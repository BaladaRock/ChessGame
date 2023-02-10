using ChessGame.Controller;
using System.Drawing;
using System.Windows.Forms;

namespace ChessGame
{
    internal class ChessBoard
    {
        private const string blackColor = "black";

        private const byte RookIndex = 7;

        private const byte KnightLeftIndex = 1;

        private const byte KnightRightIndex = 6;

        private const byte BishopLeftIndex = 2;

        private const byte BishopRightIndex = 5;

        private const byte QueenIndex = 3;

        private const byte KingIndex = 4;

        private readonly FormChessBoard squares;

        private Controller.ChessGame chessGame;

        private readonly int leftMargin;

        private readonly int upperMargin;

        private readonly int gutterLength;

        private readonly int rectangleLength;

        public byte Size { get; private set; }

        public ChessBoard(FormChessBoard chessBoard, int leftMargin, int upperMargin, int borderThickness)
        {
            squares = chessBoard;
            this.leftMargin = leftMargin;
            this.upperMargin = upperMargin;
            gutterLength = leftMargin * KingIndex;
            rectangleLength = (BishopLeftIndex * gutterLength) + (KingIndex * borderThickness);
            chessGame = new Controller.ChessGame(Size);
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
            AddPieceAndImage(rowIndex, columnIndex, "king", colorType, imageColor);
        }

        private void AddPieceAndImage(int rowIndex, int columnIndex, string pieceToPlace, string color, Bitmap imageColor)
        {
            InsertImage(rowIndex, columnIndex, imageColor);
            chessGame.OccupySquare(pieceToPlace, color, rowIndex, columnIndex);
        }

        private void AddQueen(int rowIndex, int columnIndex, string colorType = blackColor)
        {
            if (rowIndex != QueenIndex)
            {
                return;
            }

            var imageColor = colorType == blackColor ? Properties.Resources.black_queen : Properties.Resources.white_queen;
            AddPieceAndImage(rowIndex, columnIndex, "queen", colorType, imageColor);
        }

        private void AddBishops(int rowIndex, int columnIndex, string colorType = blackColor)
        {
            if (rowIndex != BishopLeftIndex && rowIndex != BishopRightIndex)
            {
                return;
            }

            var imageColor = colorType == blackColor ? Properties.Resources.black_bishop : Properties.Resources.white_bishop;
            AddPieceAndImage(rowIndex, columnIndex, "bishop", colorType, imageColor);
        }

        private void AddKnights(int rowIndex, int columnIndex, string colorType = blackColor)
        {
            if (rowIndex != KnightLeftIndex && rowIndex != KnightRightIndex)
            {
                return;
            }

            var imageColor = colorType == blackColor ? Properties.Resources.black_knight : Properties.Resources.white_knight;
            AddPieceAndImage(rowIndex, columnIndex, "knight", colorType, imageColor);
        }

        private void AddRooks(int rowIndex, int columnIndex, string colorType = blackColor)
        {
            if (columnIndex != 0 && columnIndex != RookIndex)
            {
                return;
            }

            var imageColor = colorType == blackColor ? Properties.Resources.black_rook : Properties.Resources.white_rook;
            AddPieceAndImage(rowIndex, columnIndex, "rook", colorType, imageColor);
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
            AddPieceAndImage(rowIndex, columnIndex, "pawn", colorType, imageColor);
        }

        private void InsertImage(int rowIndex, int columnIndex, Bitmap pieceImage)
        {
            int controlIndex = (rowIndex * Size) + columnIndex;
            var chessSquare = squares.Controls[controlIndex];
            chessSquare.BackgroundImage = pieceImage;
            chessSquare.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void DrawOutline(int borderThickness)
        {
            Graphics board = squares.CreateGraphics();
            Brush brown = new SolidBrush(Color.Brown);
            Pen borderPen = new Pen(brown, borderThickness);

            board.DrawRectangle(borderPen, gutterLength - borderThickness,
                upperMargin - borderThickness, rectangleLength, rectangleLength);

            board.Dispose();
            brown.Dispose();
            borderPen.Dispose();
        }

        internal void BuildChessBoard(byte size, Color firstSquareColor, Color secondSquareColor)
        {
            Size = size;
            chessGame.BuildChessGame(Size);

            for (byte i = 0; i < Size; i++)
            {
                for (byte j = 0; j < Size; j++)
                {
                    var chessSquare = new PictureBox
                    {
                        Location = new Point(i + gutterLength + (leftMargin * i), j + upperMargin + (j * leftMargin)),
                        Size = new Size(leftMargin, leftMargin),
                        BackColor = j % 2 == 0 ? firstSquareColor : secondSquareColor
                    };

                    var customSquare = new CustomChessSquare(chessGame, chessSquare, squares, Size)
                    {
                        X = i,
                        Y = j
                    };

                    squares.Add(customSquare);
                }
                SwapColors(ref firstSquareColor, ref secondSquareColor);
            }
        }

        private void SwapColors(ref Color firstColor, ref Color secondColor)
        {
            (secondColor, firstColor) = (firstColor, secondColor);
        }
    }
}