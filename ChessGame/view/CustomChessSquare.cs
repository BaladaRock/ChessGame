using ChessGame.model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChessGame
{
    public class CustomChessSquare
    {
        private readonly controller.ChessGame chessGame;

        private readonly FormChessBoard chessBoardGraphics;

        private readonly int boardSize;

        private readonly PictureBox rawPicture;

        public Color OriginalColor { get; set; }

        internal CustomChessSquare(controller.ChessGame chessBoard, PictureBox square, FormChessBoard chessBoardGraphics, int boardSize)
        {
            this.chessBoardGraphics = chessBoardGraphics;
            this.chessGame = chessBoard;
            this.boardSize = boardSize;
            OriginalColor = square.BackColor;
            square.Click += PicureBox_OnClick;
            rawPicture = square;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public PictureBox GetControl() => rawPicture;

        private void PicureBox_OnClick(object sender, EventArgs e)
        {
            //PictureBox temp = (PictureBox)sender;
            int freshIndex = (boardSize * X) + Y;

            if (chessGame.UpdatedAfterClick(X, Y))
            {
                string activePiece = chessGame.GetActivePiece();

                // Update previously clicked piece image
                Position coordinates = chessGame.GetLastActivePositions();
                int oldIndex = (boardSize * coordinates.X) + coordinates.Y;
                chessBoardGraphics.Controls[oldIndex].BackgroundImage = null;

                // Reset last active piece color
                //chessBoardGraphics.Controls[oldIndex].BackColor = OriginalColor;

                // Update freshly moved piece image
                var pieceType = $"{chessGame.GetActivePieceColor()}_{chessGame.GetActivePieceType()}";
                chessBoardGraphics.Controls[freshIndex].BackgroundImage = SetPieceImage(pieceType);
                chessBoardGraphics.Controls[freshIndex].BackgroundImageLayout = ImageLayout.Zoom;

                // Set active piece color
                //chessBoardGraphics.Controls[freshIndex].BackColor = Color.BlueViolet;
            }
        }

        private Image SetPieceImage(string pieceType)
        {
            switch (pieceType)
            {
                case "white_pawn":
                    return Properties.Resources.white_pawn;

                case "black_pawn":
                    return Properties.Resources.black_pawn;

                case "white_knight":
                    return Properties.Resources.white_knight;

                case "black_knight":
                    return Properties.Resources.black_knight;

                case "white_bishop":
                    return Properties.Resources.white_bishop;

                case "black_bishop":
                    return Properties.Resources.black_bishop;

                case "white_king":
                    return Properties.Resources.white_king;

                case "black_king":
                    return Properties.Resources.black_king;

                case "white_queen":
                    return Properties.Resources.white_queen;

                case "black_queen":
                    return Properties.Resources.black_queen;

                case "white_rook":
                    return Properties.Resources.white_rook;

                case "black_rook":
                    return Properties.Resources.black_rook;

                default:
                    return Properties.Resources.white_pawn;
            }
        }
    }
}