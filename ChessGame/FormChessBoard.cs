using ChessGame.test;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class FormChessBoard : Form
    {
        public FormChessBoard()
        {
            InitializeComponent();
        }

        private void FormChessBoard_Paint(object sender, PaintEventArgs e)
        {
            var chessGame = new ChessBoard(this, 50, 20, 3);
            chessGame.BuildChessBoard(8, Color.PeachPuff, Color.Peru);
            chessGame.AddChessPieces();
            var test = new ChessBuilder();
            test.TestObjects();
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