using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_List
{
    public class LinearList<T>
    {
        #region Свойства
        private Element Head { get; set; }
        public int Length { get; private set; }
        #endregion

        #region Вложенные классы
        internal class Element
        {
            private T Value { get; set; }
            internal Element Next { get; set; }

            public Element(T value, Element next)
            {
                Value = value;
                Next = next;
            }
        }
        #endregion

        #region Конструкторы
        public LinearList()
        {
            Head = null;
            Length = 0;
        }

        public LinearList(T value)
        {
            Head = new Element(value, null);
            Length = 1;
        }
        #endregion

        #region Методы
        public void AddBack(T value)
        {
            if (Head == null)
            {
                Head = new Element(value, null);
            }
            else
            {
                Element NewElement = new Element(value, Head);
                Head = NewElement;
            }
            Length++;
        }

        public void AddFront(T value)
        {
            if (Head == null)
            {
                Head = new Element(value, null);
            }
            else
            {
                Element NewElement = Head;
                while (NewElement.Next != null) NewElement = NewElement.Next;
                NewElement.Next = new Element(value, null);
            }
            Length++;
        }

        public void Add(T value, int position)
        {
            if ((position > 0) && (position <= this.Length + 1))
            {
                if ((position > 1) && (position <= this.Length))
                {
                    Element NewElement = this.Head;
                    for (int i = 2; i <= position; i++)
                    {
                        if (i != position) NewElement = NewElement.Next;
                        else
                        {
                            Element insert = new Element(value, NewElement.Next);
                            NewElement.Next = insert;
                            Length++;
                        }
                    }
                }
                else
                {
                    if (position == 1) AddBack(value);
                    else AddFront(value);
                }
            }
            else
            {
                throw new Exception("Position not set correctly.");
            }
        }
        #endregion

    }
}
