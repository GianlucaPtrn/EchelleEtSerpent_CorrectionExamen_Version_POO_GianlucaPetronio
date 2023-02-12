using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace EX_Simpl_EchelleSerpent
{
    class PlayGame
    {
        private int _nbrPtsJoueur;
        private int[] _positionPion;
        private string _iconPlayer;
        private string _lastValue;

        public int NbrPtsJoueur
        {
            get { return _nbrPtsJoueur; }
            set { _nbrPtsJoueur = value; }
        }

        public int[] PositionPion
        {
            get { return _positionPion; }
            set { _positionPion = value; }
        }

        public string IconPlayer
        {
            get { return _iconPlayer; }
            set { _iconPlayer = value; }
        }

        public string LastValue
        {
            get { return _lastValue; }
            set { _lastValue = value; }
        }

        public PlayGame()
        {
            LastValue = "1";
            PositionPion = new int[] { 0, 0 };
            IconPlayer = "X";
            NbrPtsJoueur = 1;
        }

        public void TourPlateau(int numeroJoueur)
        {
            MainWindow Jeu = (EX_Simpl_EchelleSerpent.MainWindow)App.Current.MainWindow;
            Random alea = new Random();
            int de = alea.Next(1, 7);
            Jeu.nameJoueur.Text = "Joueur" + numeroJoueur;
            Jeu.infoDe.Text = "Dé : " + de;
            int reste;
            Jeu.BtnCase[PositionPion[0], PositionPion[1]].Content = LastValue;
            Jeu.BtnCase[PositionPion[0], PositionPion[1]].Foreground = Brushes.Black;
            NbrPtsJoueur += de;
            reste = NbrPtsJoueur - 10 * (PositionPion[0] + 1);
            if (reste < 0)
            {
                reste += 10;
            }
            else
            {
                PositionPion[0] += 1;
            }
            if (PositionPion[0] % 2 != 0)
            {
                PositionPion[1] = 9 - reste;
            }
            else
            {
                PositionPion[1] = reste;
            }
            if (PositionPion[0] <= 9)
            {
                LastValue = Jeu.BtnCase[PositionPion[0], PositionPion[1]].Content.ToString();
                Jeu.BtnCase[PositionPion[0], PositionPion[1]].Content = IconPlayer;
                Jeu.BtnCase[PositionPion[0], PositionPion[1]].Foreground = Brushes.Gold;
            }
            else
            {
                Jeu.nameJoueur.Text = "Fin !";
                Jeu.BtnCase[9, 0].Content = IconPlayer;
                Jeu.BtnCase[9, 0].Foreground = Brushes.Gold;
                Jeu.btnJouer.IsEnabled = false;
            }
        }
    }
}
