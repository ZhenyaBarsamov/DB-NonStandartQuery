using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonstandardQuery.MyDataClasses {
    //Облочка для byte[] для определения метода ToString
    class ByteArray {
        public byte[] Array { get; set; }

        //Виновник торжества - для отображения в интерфейсе
        public override string ToString() {
            return Convert.ToBase64String(Array);
        }

        //Оборачивание массива в оболочку
        public static ByteArray ToByteArray(byte[] array) {
            return new ByteArray { Array = array };
        }
    }
}
