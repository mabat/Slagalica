using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slagalica
{
    public class Card
    {
        public string _type; //bastoni, spade...
        public string _name; //as , trica, kralj...
        public int _value; //broj na karti
        public string _cardImage; //slika

        public Card(string t, string n, int v, string cIm)
        {
            this._type = t;
            this._name = n;
            this._value = v;
            this._cardImage = cIm;
        }
        public string Type { get { return _type; } set { _type = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public int Value   { get { return _value; } set { _value = value; }}
        public string CardImage { get { return _cardImage; } set { _cardImage = value; } }
    }
}
