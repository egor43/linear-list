using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_List
{
    /// <summary>
    /// Представляет линейный список открытого структурного типа.
    /// </summary>
    /// <typeparam name="T">указатель места заполнения (ограничение: struct)</typeparam>
    public class LinearList<T> where T : struct
    {
        #region Свойства

        /// <summary>
        /// Указатель на первый элемент списка
        /// </summary>
        private Element Head { get; set; }

        /// <summary>
        /// Длинна списка (отсчет с 1)
        /// </summary>
        public int Length { get; private set; }
        #endregion

        #region Вложенные классы

        /// <summary>
        /// Представляет элемент линейного списка
        /// </summary>
        internal class Element
        {
            #region Свойства
            /// <summary>
            /// Значение элемента
            /// </summary>
            internal T Value { get; set; }

            /// <summary>
            /// Указатель на следующий элемент
            /// </summary>
            internal Element Next { get; set; }
            #endregion

            #region Конструкторы

            /// <summary>
            /// Инициализирует элемент линейного списка
            /// </summary>
            /// <param name="value">значение элемента</param>
            /// <param name="next">ссылка на следующий элемент</param>
            internal Element(T value, Element next)
            {
                Value = value;
                Next = next;
            }
            #endregion
        }
        #endregion

        #region Конструкторы

        /// <summary>
        /// Инициализирует линейный список значениями по умолчанию
        /// </summary>
        public LinearList()
        {
            Head = null;
            Length = 0;
        }

        /// <summary>
        /// Инициализирует линейный список и первый элемент списка
        /// </summary>
        /// <param name="value">значение первого элемента списка</param>
        public LinearList(T value)
        {
            Head = new Element(value, null);
            Length = 1;
        }
        #endregion

        #region Методы

        /// <summary>
        /// Спбрасывает линейный список в значения по умолчанию
        /// </summary>
        public void Clear()
        {
            this.Head = null;
            this.Length = 0;
        }

        /// <summary>
        /// Добавляет элемент в конец списка
        /// </summary>
        /// <param name="value">значение элемента</param>
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

        /// <summary>
        /// Добавляет элемент в начало списка
        /// </summary>
        /// <param name="value">значение элемента</param>
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

        /// <summary>
        /// Добавляет элемент в указанную позицию списка
        /// </summary>
        /// <param name="value">значение элемента</param>
        /// <param name="position">позиция элемента</param>
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

        /// <summary>
        /// Возвращает строковое представление линейного списка
        /// </summary>
        /// <returns>строковое представление линейного списка</returns>
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

        /// <summary>
        /// Удаляет элемент из линейного списка
        /// </summary>
        /// <param name="position">позиция удаляемого элемента</param>
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

        /// <summary>
        /// Осуществляет поиск элемента по значению
        /// </summary>
        /// <param name="ValueToSearch">значение для поиска</param>
        /// <returns>Если поиск успешен: возвращает позицию элемента в списке начиная с 1, иначе: возвращает -1</returns>
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

        /// <summary>
        /// Осуществляет поиск элемента по значению
        /// </summary>
        /// <param name="ValueToSearch">значение для поиска</param>
        /// <returns>Возвращает форматированное строковое представление результата поиска элемента.</returns>
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

        /// <summary>
        /// Осуществляет поиск элемента по значению
        /// </summary>
        /// <param name="ValueToSearch">значение для поиска</param>
        /// <returns>Если поиск успешен: возвращает линейный список, состоящий из искомого элемента, иначе: возвращает null</returns>
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
