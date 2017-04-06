using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Linq;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Input;
using System;
using WPFBehaviorLibrary.DragDropBehavior;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Data;
using System.Media;
using System.Windows.Media;

namespace Slagalica
{
    class MainViewModel : DragDropBehavior, INotifyPropertyChanged

    {
        private ObservableCollection<Card> _CardsSpil;
        private ObservableCollection<Card> _As1;
        private ObservableCollection<Card> _As2;
        private ObservableCollection<Card> _As3;
        private ObservableCollection<Card> _As4;
        private ObservableCollection<Card> _Table1;
        private ObservableCollection<Card> _Table2;
        private ObservableCollection<Card> _Table3;
        private ObservableCollection<Card> _Table4;
        private Card _backCard;
        private Card _backRotatedCard;
        private CollectionViewSource _data = new CollectionViewSource();
        private SoundPlayer _cardSlide;
        private SoundPlayer _cardFan1;

        public MainViewModel()
        {
            #region Cards Initialization 
            _cardSlide = new SoundPlayer("Resources/cardSlide6.wav");
            _cardFan1 = new SoundPlayer("Resources/cardFan1.wav");
            _cardFan1.Play(); //zvucni efekt dijeljenja karata

            this._CardsSpil = new ObservableCollection<Card>();
            this._As1 = new ObservableCollection<Card>();
            this._As2 = new ObservableCollection<Card>();
            this._As3 = new ObservableCollection<Card>();
            this._As4 = new ObservableCollection<Card>();
            this._Table1 = new ObservableCollection<Card>();
            this._Table2 = new ObservableCollection<Card>();
            this._Table3 = new ObservableCollection<Card>();
            this._Table4 = new ObservableCollection<Card>();
            _CardsSpil.Add(new Card("bastoni", "as", 1, "pack://siteoforigin:,,,/Images/b10.png"));
            _CardsSpil.Add(new Card("bastoni", "trica", 3, "pack://siteoforigin:,,,/Images/b9.png"));
            _CardsSpil.Add(new Card("bastoni", "kralj", 10, "pack://siteoforigin:,,,/Images/b8.png"));
            _CardsSpil.Add(new Card("bastoni", "konj", 9, "pack://siteoforigin:,,,/Images/b7.png"));
            _CardsSpil.Add(new Card("bastoni", "fanta", 8, "pack://siteoforigin:,,,/Images/b6.png"));
            _CardsSpil.Add(new Card("bastoni", "sedmica", 7, "pack://siteoforigin:,,,/Images/b5.png"));
            _CardsSpil.Add(new Card("bastoni", "sestica", 6, "pack://siteoforigin:,,,/Images/b4.png"));
            _CardsSpil.Add(new Card("bastoni", "petica", 5, "pack://siteoforigin:,,,/Images/b3.png"));
            _CardsSpil.Add(new Card("bastoni", "cetvorka", 4, "pack://siteoforigin:,,,/Images/b2.png"));
            _CardsSpil.Add(new Card("bastoni", "dvojka", 2, "pack://siteoforigin:,,,/Images/b1.png"));

            _CardsSpil.Add(new Card("dinari", "as", 1, "pack://siteoforigin:,,,/Images/d10.png"));
            _CardsSpil.Add(new Card("dinari", "trica", 3, "pack://siteoforigin:,,,/Images/d9.png"));
            _CardsSpil.Add(new Card("dinari", "kralj", 10, "pack://siteoforigin:,,,/Images/d8.png"));
            _CardsSpil.Add(new Card("dinari", "konj", 9, "pack://siteoforigin:,,,/Images/d7.png"));
            _CardsSpil.Add(new Card("dinari", "fanta", 8, "pack://siteoforigin:,,,/Images/d6.png"));
            _CardsSpil.Add(new Card("dinari", "sedmica", 7, "pack://siteoforigin:,,,/Images/d5.png"));
            _CardsSpil.Add(new Card("dinari", "sestica", 6, "pack://siteoforigin:,,,/Images/d4.png"));
            _CardsSpil.Add(new Card("dinari", "petica", 5, "pack://siteoforigin:,,,/Images/d3.png"));
            _CardsSpil.Add(new Card("dinari", "cetvorka", 4, "pack://siteoforigin:,,,/Images/d2.png"));
            _CardsSpil.Add(new Card("dinari", "dvojka", 2, "pack://siteoforigin:,,,/Images/d1.png"));

            _CardsSpil.Add(new Card("spade", "as", 1, "pack://siteoforigin:,,,/Images/s10.png"));
            _CardsSpil.Add(new Card("spade", "trica", 3, "pack://siteoforigin:,,,/Images/s9.png"));
            _CardsSpil.Add(new Card("spade", "kralj", 10, "pack://siteoforigin:,,,/Images/s8.png"));
            _CardsSpil.Add(new Card("spade", "konj", 9, "pack://siteoforigin:,,,/Images/s7.png"));
            _CardsSpil.Add(new Card("spade", "fanta", 8, "pack://siteoforigin:,,,/Images/s6.png"));
            _CardsSpil.Add(new Card("spade", "sedmica", 7, "pack://siteoforigin:,,,/Images/s5.png"));
            _CardsSpil.Add(new Card("spade", "sestica", 6, "pack://siteoforigin:,,,/Images/s4.png"));
            _CardsSpil.Add(new Card("spade", "petica", 5, "pack://siteoforigin:,,,/Images/s3.png"));
            _CardsSpil.Add(new Card("spade", "cetvorka", 4, "pack://siteoforigin:,,,/Images/s2.png"));
            _CardsSpil.Add(new Card("spade", "dvojka", 2, "pack://siteoforigin:,,,/Images/s1.png"));

            _CardsSpil.Add(new Card("coppe", "as", 1, "pack://siteoforigin:,,,/Images/c10.png"));
            _CardsSpil.Add(new Card("coppe", "trica", 3, "pack://siteoforigin:,,,/Images/c9.png"));
            _CardsSpil.Add(new Card("coppe", "kralj", 10, "pack://siteoforigin:,,,/Images/c8.png"));
            _CardsSpil.Add(new Card("coppe", "konj", 9, "pack://siteoforigin:,,,/Images/c7.png"));
            _CardsSpil.Add(new Card("coppe", "fanta", 8, "pack://siteoforigin:,,,/Images/c6.png"));
            _CardsSpil.Add(new Card("coppe", "sedmica", 7, "pack://siteoforigin:,,,/Images/c5.png"));
            _CardsSpil.Add(new Card("coppe", "sestica", 6, "pack://siteoforigin:,,,/Images/c4.png"));
            _CardsSpil.Add(new Card("coppe", "petica", 5, "pack://siteoforigin:,,,/Images/c3.png"));
            _CardsSpil.Add(new Card("coppe", "cetvorka", 4, "pack://siteoforigin:,,,/Images/c2.png"));
            _CardsSpil.Add(new Card("coppe", "dvojka", 2, "pack://siteoforigin:,,,/Images/c1.png"));

            this._backCard = new Card("back", "back", 0, "pack://siteoforigin:,,,/Images/back.png");
            this._backRotatedCard = new Card("back", "back", 0, "pack://siteoforigin:,,,/Images/back_rotated.png");

            #endregion

            Shuffle(_CardsSpil); //mijesanje spila

            #region Fill As and Table
            _Table1.Add(_CardsSpil.ElementAt(0));
            _CardsSpil.RemoveAt(0);
            _Table1.Add(_CardsSpil.ElementAt(0));
            _CardsSpil.RemoveAt(0);
            _Table1.Add(_CardsSpil.ElementAt(0));
            _CardsSpil.RemoveAt(0);
            _Table1.Add(_CardsSpil.ElementAt(0));
            _CardsSpil.RemoveAt(0);

            _Table2.Add(_CardsSpil.ElementAt(0));
            _CardsSpil.RemoveAt(0);
            _Table2.Add(_CardsSpil.ElementAt(0));
            _CardsSpil.RemoveAt(0);
            _Table2.Add(_CardsSpil.ElementAt(0));
            _CardsSpil.RemoveAt(0);

            _Table3.Add(_CardsSpil.ElementAt(0));
            _CardsSpil.RemoveAt(0);
            _Table3.Add(_CardsSpil.ElementAt(0));
            _CardsSpil.RemoveAt(0);

            _Table4.Add(_CardsSpil.ElementAt(0));
            _CardsSpil.RemoveAt(0);

            #endregion Fill As and Table
        }

        #region ObsevableCollections definitions
        public ObservableCollection<Card> CardsSpil { get { return _CardsSpil; } private set { _CardsSpil = value; } }
        public ObservableCollection<Card> As1 { get { return _As1; } private set { _As1 = value; } }
        public ObservableCollection<Card> As2 { get { return _As2; } private set { _As2 = value; } }
        public ObservableCollection<Card> As3 { get { return _As3; } private set { _As3 = value; } }
        public ObservableCollection<Card> As4 { get { return _As4; } private set { _As4 = value; } }
        public ObservableCollection<Card> Table1 { get { return _Table1; } private set { _Table1 = value; } }
        public ObservableCollection<Card> Table2 { get { return _Table2; } private set { _Table2 = value; } }
        public ObservableCollection<Card> Table3 { get { return _Table3; } private set { _Table3 = value; } }
        public ObservableCollection<Card> Table4 { get { return _Table4; } private set { _Table4 = value; } }
        public string BackCard { get { return _backCard.CardImage; } }
        public string BackRotated { get { if (this._backRotatedCard == null) return null; return _backRotatedCard.CardImage; } }
        #endregion ObsevableCollections definitions

        #region shuffling card list
        private Random rng = new Random();
        public void Shuffle(ObservableCollection<Card> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        #endregion shuffling card list

        #region Override abstract class DragDropBehavior
        protected override void AddItem(ItemsControl itemsControl, object item, int insertIndex)
        {
            if (itemsControl == null) return;

            IList iList = itemsControl.ItemsSource as IList;
            if (iList != null)
            {
                iList.Insert(iList.Count, item);
            }
            else
            {
                itemsControl.Items.Insert(iList.Count, item);
            }
        }
        protected override bool CanDrag(ItemsControl itemsControl, object item)
        {
            if (itemsControl.Name.Equals("As1") || itemsControl.Name.Equals("As2")
                || itemsControl.Name.Equals("As3") || itemsControl.Name.Equals("As4"))
            {
                return false;
            }
            if (!itemsControl.Name.Equals("CardsSpil"))
            {

                //ako je karta ispod karte na table spilu razlicitog tipa onda se ne moze drag-ati
                ObservableCollection<Card> lista = itemsControl.ItemsSource as ObservableCollection<Card>;
                Card card = item as Card;
                int index = lista.IndexOf(card);
                if (index < lista.Count-1)
                {
                    for (int i = index; i < lista.Count; ++i)
                    {
                        if (!lista.ElementAt(i).Type.Equals(card.Type))
                        {
                            return false;
                        }
                    }
                }
            }
            //sound effect drag
            using (SoundPlayer player1 = new SoundPlayer("Resources/cardPlace2.wav"))
            {
                player1.Play();
            }
            return (this.ItemType == null) || this.ItemType.IsInstanceOfType(item);
        }
        protected override bool CanDrop(ItemsControl itemsControl, object item)
        {
            Card i = item as Card;
            ObservableCollection<Card> destination = itemsControl.ItemsSource as ObservableCollection<Card>;

            if (destination.Count == 0) //ako je polje prazno
            {

                if ((itemsControl.Name.Equals("As1") || itemsControl.Name.Equals("As2")
                || itemsControl.Name.Equals("As3") || itemsControl.Name.Equals("As4")) && i._value == 1) //ako je mjesto od asa i ako je igraca karta as igraj!
                {
                    return (this.ItemType == null) || this.ItemType.IsInstanceOfType(item);
                }
                else if (((itemsControl.Name.Equals("Table1") || itemsControl.Name.Equals("Table2")
                || itemsControl.Name.Equals("Table3") || itemsControl.Name.Equals("Table4") && i._value == 10))) //ako je Table mjesto i ako je igraca karta Kralj igraj!
                {
                    return (this.ItemType == null) || this.ItemType.IsInstanceOfType(item);
                }
            }
            else //ako polje nije prazno
            {
                if ((itemsControl.Name.Equals("As1") || itemsControl.Name.Equals("As2")//ako je destination polje As, tip igrace karte istog tipa kao as, a vrijednosti +1, igraj!
                || itemsControl.Name.Equals("As3") || itemsControl.Name.Equals("As4"))
                && i.Value == (destination.Last()._value + 1) && destination.Last()._type.Equals(i._type))
                {
                    return (this.ItemType == null) || this.ItemType.IsInstanceOfType(item);
                }
                else if (((itemsControl.Name.Equals("Table1") || itemsControl.Name.Equals("Table2")//ako je destination polje Table, tip igrace karte istog tipa kao Table, a vrijednosti -1, igraj!
                || itemsControl.Name.Equals("Table3") || itemsControl.Name.Equals("Table4"))
                && i.Value == (destination.Last()._value - 1) && destination.Last()._type.Equals(i._type)))
                {
                    return (this.ItemType == null) || this.ItemType.IsInstanceOfType(item);
                }
            }
            return false;
        }
        #endregion Override abstract class DragDropBehavior

        #region treci red okretanje karte

        public DelegateCommand FlipCommand { get { return new DelegateCommand(OnFlip); } }
        private void OnFlip()
        {
            _cardSlide.Play();
            /*okretenje karata u spilu. Prikazujemo svako trecu kartu na zadnjem indexu. 
             * Mora biti svako treca jer je to smisao igre, kada bi samo listali karte iz 
             * spila onda bi se igra uvijek dovrsila, ovako ovisi o sreci*/
            int last = _CardsSpil.Count;

            //ako su ostale tri karte onda nema vise one sa praznom poledjinom koju klikamo
            if (last < 3)
            {
                this._backRotatedCard = null;
                OnPropertyChanged("BackRotated");
            }

            //setanje po nizu, svako treca karta
            _CardsSpil.Move(last - 1, 0);
            _CardsSpil.Move(last - 1, 0);
            _CardsSpil.Move(last - 1, 0);
        }
        #endregion

        #region Menu komande
        public DelegateCommand New_Game
        {
            get
            {
                return new DelegateCommand(new_game);
            }
        }
        public void new_game() //nova igra
        {
            MainWindow game = new MainWindow();
            Application.Current.Windows[0].Close();
            game.Show();
            //game.ShowDialog();
        }
        public DelegateCommand Close
        {
            get
            {
                return new DelegateCommand(close);
            }
        }
        public void close()
        {
            System.Environment.Exit(1);
        }
        public DelegateCommand About
        {
            get
            {
                return new DelegateCommand(about);
            }
        }
        public void about() //nova igra
        {
            MessageBox.Show("Kolegij:\t Napredno Windows Programiranje\nRazvoj:\t Marko Batarelo\nMentor:\t Stipe Braica","About", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public DelegateCommand HowTo
        {
            get
            {
                return new DelegateCommand(howto);
            }
        }
        public void howto() //nova igra
        {
            MessageBox.Show("Cilj je igre složiti karte redom od najmanje do najveće.\n\nU prvom redu slažemo karte od Asa pa naviše. \n\nU drugom redu nalaze se karte koje su igri, na njih slažemo karte koje su manje od njih, od kralja pa naniže, a cilj ih je u konačnici složiti u prvi red. \n\nKlikom na praznu kartu dodjeljuje se nova nova karta iz špila. \n\nAko nemamo sljedećeg poteza, igra je izgubljena. \n\nAko složimo sva 4 tipa karata u prvom redom od Asa do Kralja igra je gotova sa pobjedom.", "How To", MessageBoxButton.OK, MessageBoxImage.Question);
        }
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}