using System;
using System.Collections;
using System.Collections.Generic;

namespace Set
{
    public class Set<T> : ISet<T>
    {
        private HashSet<T> hashSet;

        public Set()
        {
            // do something so bad things don't happen in the future...
            hashSet = new HashSet<T>();

        }

        public int Size => hashSet.Count;

        public List<T> Elements => new List<T>(hashSet);

        public void Add(ISet<T> s)
        {
            foreach( var item in s)
            {
                this.Add(item);
            }
        }

        public void Add(T value)
        {
            hashSet.Add(value);
        }

        public bool Contains(T value)
        {
            if(hashSet.Contains(value))
            {
                return true;
            }

            return false;
        }

        public void Remove(ISet<T> s)
        {
            foreach (var item in s)
            {
                this.Remove(item);
            }
        }

        public void Remove(T value)
        {
            hashSet.Remove(value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return hashSet.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static Set<T> Union(ISet<T> set1, ISet<T> set2)
        {
            var list = new Set<T>();
            list.Add(set1);
            list.Add(set2);
            return list;

        }

        public static Set<T> Intersection(ISet<T> set1, ISet<T> set2)
        {
            var list = new Set<T>();
            var sameNum = new Set<T>();

            
            
            foreach( var item in set1 )
            {
                if( set2.Contains(item))
                {
                    list.Add(set1);
                    sameNum.Add(item);
                    list.Remove(item);

                }
                
            }

            foreach (var item in set2)
            {
                if (set1.Contains(item))
                {
                    list.Add(set2);
                    sameNum.Add(item);
                    list.Remove(item);

                }
                
            }

            return list;
            
        }

    }
}
