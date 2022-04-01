using ChessGame.test;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class FormChessBoard : Form
    {
        private ChessBoard chessGame;

        public FormChessBoard()
        {
            InitializeComponent();
            var test = new ChessBuilder();
            test.TestObjects();
        }

        private void FormChessBoard_Paint(object sender, PaintEventArgs e)
        {
            chessGame = new ChessBoard(this, 50, 20, 3);
            chessGame.BuildChessBoard(8, Color.PeachPuff, Color.Peru);
            chessGame.AddChessPieces();
        }

        private void FormChessBoard_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        public void Add(CustomChessSquare square)
        {
            Controls.Add(square.GetControl());
        }
    }
}