using System.Collections.Generic;

namespace Set
{
    public interface ISet<T>: IEnumerable<T>
    {
        void Add(ISet<T> s);

        void Add(T value);

        void Remove(ISet<T> s);

        void Remove(T value);

        bool Contains(T value);

        int Size { get; }

        List<T> Elements { get; }


    }
}