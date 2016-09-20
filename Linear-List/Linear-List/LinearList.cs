using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_List
{
    //TODO: Метод поиска по значению
    public class LinearList<T> where T : struct
    {
        #region Свойства
        private Element Head { get; set; }
        public int Length { get; private set; }
        #endregion

        #region Вложенные классы
        internal class Element
        {
            internal T Value { get; set; }
            internal Element Next { get; set; }

            internal Element(T value, Element next)
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

        public void Clear()
        {
            this.Head = null;
            this.Length = 0;
        }
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

        public string Print()
        {
            string result = "";
            Element count = Head;
            while (count != null)
            {
                result = result + Convert.ToString(count.Value) + " ";
                count = count.Next;
            }
            return result;
        }

        public void Delete(int position)
        {
            if ((position > 0) && (position <= this.Length))
            {
                if (position == 1) this.Head = Head.Next;
                else
                {
                    Element NewElement = Head;
                    for (int i = 1; i < position; i++)
                    {
                        if (i + 1 != position) NewElement = NewElement.Next;
                        else
                        {
                            if (position == this.Length) NewElement.Next = null;
                            else
                            {
                                NewElement.Next = (NewElement.Next).Next;
                            }
                        }
                    }
                }
                Length--;
            }
            else
            {
                throw new Exception("Position not set correctly.");
            }
        }

        public int SearchValue(T ValueToSearch)
        {
            int Result = 0;
            Element count = Head;
            while (count != null)
            {
                Result++;
                if (count.Value.ToString() == ValueToSearch.ToString()) return Result;
                count = count.Next;
            }
            return -1;
        }

        public string SearchValueToString(T ValueToSearch)
        {
            int Result = 0;
            Element count = Head;
            while (count != null)
            {
                Result++;
                if (count.Value.ToString() == ValueToSearch.ToString()) return String.Format("Element:{0} found at position:{1}", ValueToSearch, Result);
                count = count.Next;
            }
            return String.Format("Element not found");
        }

        public LinearList<T> SearchValueToLinearList(T ValueToSearch)
        {
            int Result = 0;
            Element count = Head;
            while (count != null)
            {
                Result++;
                if (count.Value.ToString() == ValueToSearch.ToString()) return new LinearList<T>(ValueToSearch);
                count = count.Next;
            }
            return null;
        }
        #endregion
    }
}
