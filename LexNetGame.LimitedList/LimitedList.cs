using System.Collections;

namespace LexNetGame.LimitedList
{
    public class LimitedList<T> :  ILimitedList<T>
    {
        private readonly int capacity;
        protected List<T> list;

        public int Count => list.Count;

        public bool IsFull => capacity <= Count;

        public T this[int index] => list[index];
        //{
        //    get => list[index];
        //}
        //{
        //    get
        //    {
        //        return list[index];
        //    }
        //    set => list[index] = value;
        //}

        public LimitedList(int capacity)
        {
            this.capacity = Math.Max(capacity, 2);
            list = new List<T>(this.capacity);
        }

        public virtual bool Add(T item)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));

            if (IsFull) return false;
            list.Add(item); return true;
        }

        public void Print(Action<T> action)
        {
            list.ForEach(i => action?.Invoke(i));

            //list.ForEach(action);

            //foreach (var i in list)
            //{
            //    action?.Invoke(i);
            //}
        }

        public bool Remove(T item) => list.Remove(item);
        //{
        //    return list.Remove(item);
        //}


        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in list)
            {
                //....... 

                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()// => GetEnumerator();
        {
            return GetEnumerator();
        }

    }

    //public interface T1
    //{
    //    void Print();
    //}
    //public interface T2
    //{
    //    void Print();
    //}

    //public class Test : T1, T2
    //{
    //    public void Print()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    void T1.Print()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}

