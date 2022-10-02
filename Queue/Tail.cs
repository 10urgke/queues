using System.Collections;
using System.Diagnostics;

namespace Tail;

public class Tail 
    {
        private object?[] _array;
        private int _head; // Kuyruktaki ilk geçerli öğe
        private int _last; // Kuyruktaki son geçerli öğe.
        private int _size; // Eleman sayısı.
        
        /// <summary>
        /// Büyüme faktörü, daha büyük bir kapasite gerektiğinde geçerli kapasitenin çarpıldığı sayıdır. Büyüme faktörü, oluşturulurken Queue belirlenir. Varsayılan büyüme faktörü 2.0'dır.
        /// Queue kapasitesi, büyüme faktöründen bağımsız olarak her zaman en az dört artacaktır. Örneğin, büyüme faktörü 1,0 olan bir Queue , daha büyük bir kapasite gerektiğinde kapasitede her zaman dört artacaktır.
        /// </summary>
        /// 
        private readonly int _growFactor; // 100 == 1.0, 130 == 1.3, 200 == 2.0. Büyüme faktörü.
        

        private const int MinimumGrow = 4;

        // Yeri olan bir kuyruk oluşturur.
        public Tail()
            : this(32, (float)2.0)
        {
        }
        // Dolu olduğunda, yeni kapasite : capacity * growfactor
        public Tail(int capacity, float growFactor)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity),"capacity was less than the current size.");
            if (!(growFactor >= 1.0 && growFactor <= 10.0))
                throw new ArgumentOutOfRangeException(nameof(growFactor), "Queue empty");

            _array = new object[capacity];
            _head = 0;
            _last = 0;
            _size = 0;
            _growFactor = (int)(growFactor * 100);
        }

        public virtual int Count
        {
            get { return _size; }
        }

        // Tüm Nesneleri kuyruktan kaldırır.
        public virtual void Clear()
        {
            if (_size != 0)
            {
                if (_head < _last)
                    Array.Clear(_array, _head, _size);
                else
                {
                    Array.Clear(_array, _head, _array.Length - _head);
                    Array.Clear(_array, 0, _last);
                }

                _size = 0;
            }

            _head = 0;
            _last = 0;
        }
        
        // Kuyruğun sonuna nesne ekler.
        public virtual void Enqueue(object? obj)
        {
            if (_size == _array.Length)
            {
                int newcapacity = (int)((long)_array.Length * (long)_growFactor / 100);
                if (newcapacity < _array.Length + MinimumGrow)
                {
                    newcapacity = _array.Length + MinimumGrow;
                }
                SetCapacity(newcapacity);
            }

            _array[_last] = obj;
            _last = (_last + 1) % _array.Length;
            _size++;
        }
        
        // Kuyruğun başındaki nesneyi kaldırır ve geri döndürür. Kuyruk boşsa, bu yöntem bir InvalidOperationException oluşturur.
        public virtual object? Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue empty.");

            object? removed = _array[_head];
            _array[_head] = null;
            _head = (_head + 1) % _array.Length;
            _size--;
            return removed;
        }

        // Kuyruğun başındaki nesneyi döndürür. Nesne kuyrukta kalır. Kuyruk boşsa, bu yöntem bir InvalidOperationException oluşturur.
        public virtual object? Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue empty.");

            return _array[_head];
        }
        
        // nesneleri tutmak için arabelleği büyütür veya küçültür. capacity >= _size olmalıdır.
        private void SetCapacity(int capacity)
        {
            object[] newarray = new object[capacity];
            if (_size > 0)
            {
                if (_head < _last)
                {
                    Array.Copy(_array, _head, newarray, 0, _size);
                }
                else
                {
                    Array.Copy(_array, _head, newarray, 0, _array.Length - _head);
                    Array.Copy(_array, 0, newarray, _array.Length - _head, _last);
                }
            }

            _array = newarray;
            _head = 0;
            _last = (_size == capacity) ? 0 : _size;
        }
    }