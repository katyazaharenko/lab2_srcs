using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;

namespace Sources_Lab2
{
    /// <summary>
    /// Абстрактный класс <c>Source</c>.
    /// Базовый класс.
    /// <list type="bullet">
    /// <item>
    /// <term>Name</term>
    /// <description>Свойство, соответсвующее названию издания.</description>
    /// </item>
    /// <item>
    /// <term>Author</term>
    /// <description>Свойство, соответствующее фамилии автора издания.</description>
    /// </item>
    /// <item>
    /// <term>Source</term>
    /// <description>Конструктор класса.</description>
    /// </item>
    /// <item>
    /// <term>Source</term>
    /// <description>Конструктор класса по умолчанию.</description>
    /// </item>
    /// <item>
    /// <term>FindSources</term>
    /// <description>Проверка соответствия искомой фамилии и той, 
    /// что определена для конкретного объекта класса.</description>
    /// </item>
    /// <item>
    /// <term>Display</term>
    /// <description>Абстрактный метод для вывода информации об издании.</description>
    /// </item>
    /// </list>
    /// </summary>
    [Serializable]
    public abstract class Source
    {
        /// <summary>
        /// Свойство Name, определяющее название издания.
        /// </summary>
        /// <value>Название издания</value>
        public string Name { get; set; }
        /// <summary>
        /// Свойство Author, определяющее имя автора издания.
        /// </summary>
        /// <value>Фамилия автора</value>
        public string Author { get; set; }
        /// <summary>
        /// Конструктор класса Source.
        /// </summary>
        public Source(string name, string author)
        {
            Name = name;
            Author = author;
        }
        public Source() { }
        /// <summary>
        /// Функция FindSources для определения, является ли издание искомым.
        /// </summary>
        /// <returns>
        /// Bool-значение, совпадает ли искомая фамилия автора с той, которая определена для объекта класса.
        /// </returns>
        /// <param name="strAuthor">Искомая фамилия</param>
        public bool FindSources(string strAuthor)
        {
            Trace.WriteLine("Запуск метода FindSources");         
            bool res = strAuthor == this.Author;
            Trace.WriteLine("Метод FindSources выполнен успешно.");
            return res;
        }
        /// <summary>
        /// Метод Display для отображения характеристик издания.
        /// Переопределяется в производных классах.
        /// </summary>
        public abstract void Display();
    }
    /// <summary>
    /// Производный класс <c>Book</c>.
    /// <list type="bullet">
    /// <item>
    /// <term>Year</term>
    /// <description>Свойство, соответсвующее году издания книги.</description>
    /// </item>
    /// <item>
    /// <term>Publisher</term>
    /// <description>Свойство, соответствующее наименованию издательства.</description>
    /// </item>
    /// <item>
    /// <term>Book</term>
    /// <description>Конструктор класса.</description>
    /// </item>
    /// <item>
    /// <term>Book</term>
    /// <description>Конструктор класса по умолчанию.</description>
    /// </item>
    /// <item>
    /// <term>Display</term>
    /// <description>Переопределенный метод для вывода информации о книге.</description>
    /// </item>
    /// </list>
    /// </summary>
    [Serializable]
    public class Book : Source
    {
        /// <summary>
        /// Свойство Year, определяющее год издания книги.
        /// </summary>
        /// <value>Год издания книги</value>
        public short Year { get; set; }
        /// <summary>
        /// Свойство Publisher, определяющее наименование издательства книги.
        /// </summary>
        /// <value>Наименование издательства книги</value>
        public string Publisher { get; set; }
        /// <summary>
        /// Конструктор класса Book по умолчанию.
        /// </summary>
        public Book() { }
        /// <summary>
        /// Конструктор класса Book.
        /// </summary>
        public Book(string name, string author, short year, string publisher) : base(name, author)
        {
            Year = year;
            Publisher = publisher;
        }
        /// <summary>
        /// Метод Display для отображения характеристик книги.
        /// </summary>
        public override void Display()
        {
            Trace.WriteLine("Запуск процедуры Display класса Book.");
            Console.WriteLine("Type: Book");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("Year: " + Year);
            Console.WriteLine("Publisher: " + Publisher);
            Trace.WriteLine("Процедура Display выполнена успешно. Данные выведены в консоль.");
        }
    }
    /// <summary>
    /// Производный класс <c>Paper</c>.
    /// <list type="bullet">
    /// <item>
    /// <term>Year</term>
    /// <description>Свойство, соответсвующее году издания газеты.</description>
    /// </item>
    /// <item>
    /// <term>PaperNum</term>
    /// <description>Свойство PaperNum, определяющее номер выпуска газеты.</description>
    /// </item>
    /// <item>
    /// <term>Paper</term>
    /// <description>Конструктор класса.</description>
    /// </item>
    /// <item>
    /// <term>Paper</term>
    /// <description>Конструктор класса по умолчанию.</description>
    /// </item>
    /// <item>
    /// <term>Display</term>
    /// <description>Переопределенный метод для вывода информации о газете.</description>
    /// </item>
    /// </list>
    /// </summary>
    [Serializable]
    public class Paper : Source
    {
        /// <summary>
        /// Свойство Year, определяющее год выпуска газеты.
        /// </summary>
        /// <value>Год издания газеты</value>
        public short Year { get; set; }
        /// <summary>
        /// Свойство PaperNum, определяющее номер выпуска газеты.
        /// </summary>
        /// <value>Номер выпуска газеты</value>
        public int PaperNum { get; set; }
        /// <summary>
        /// Конструктор класса Paper по умолчанию.
        /// </summary>
        public Paper() {}
        /// <summary>
        /// Конструктор класса Paper.
        /// </summary>
        public Paper(string name, string author, int papernum, short year) : base(name, author)
        {
            PaperNum = papernum;
            Year = year;
        }
        /// <summary>
        /// Метод Display для отображения характеристик газеты.
        /// </summary>
        public override void Display()
        {
            Trace.WriteLine("Запуск процедуры Display класса Paper.");
            Console.WriteLine("Type: Paper");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("Paper Number: " + PaperNum);
            Console.WriteLine("Year: " + Year);
            Trace.WriteLine("Процедура Display выполнена успешно. Данные выведены в консоль.");
        }
    }
    /// <summary>
    /// Производный класс <c>EResource</c>.
    /// <list type="bullet">
    /// <item>
    /// <term>Reference</term>
    /// <description>Свойство Reference, определяющее ссылку на электронный ресурс.</description>
    /// </item>
    /// <item>
    /// <term>Annotation</term>
    /// <description>Свойство Annotation, определяющее аннотацию к ресурсу.</description>
    /// </item>
    /// <item>
    /// <term>EResource</term>
    /// <description>Конструктор класса.</description>
    /// </item>
    /// <item>
    /// <term>EResource</term>
    /// <description>Конструктор класса по умолчанию.</description>
    /// </item>
    /// <item>
    /// <term>Display</term>
    /// <description>Переопределенный метод для вывода информации об электронном ресурсе.</description>
    /// </item>
    /// </list>
    /// </summary>
    [Serializable]
    public class EResource : Source
    {
        /// <summary>
        /// Свойство Reference, определяющее ссылку на электронный ресурс.
        /// </summary>
        /// <value>Ссылка на электронный ресурс.</value>
        public string Reference { get; set; }
        /// <summary>
        /// Свойство Annotation, определяющее аннотацию к ресурсу.
        /// </summary>
        /// <value>Аннотация к ресурсу.</value>
        public string Annotation { get; set; }
        /// <summary>
        /// Конструктор класса EResources по умолчанию.
        /// </summary>
        public EResource() { }
        /// <summary>
        /// Конструктор класса EResources.
        /// </summary>
        public EResource(string name, string author, string reference, string annotation) : base(name, author)
        {
            Annotation = annotation;
            Reference = reference;
        }
        /// <summary>
        /// Метод Display для отображения характеристик электронного ресурса.
        /// </summary>
        public override void Display()
        {
            Trace.WriteLine("Запуск процедуры Display класса EResource.");
            Console.WriteLine("Type: EResource");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("Reference: " + Reference);
            Console.WriteLine("Annotation: " + Annotation);
            Trace.WriteLine("Процедура Display выполнена успешно. Данные выведены в консоль.");
        }
    }
    /// <summary>
    /// Главный класс Program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Обьявление объекта класса Source.
        /// </summary>
        public static Source[] Catalog;
        /// <summary>
        /// Процедура ShowCatalog() для вывода каталога изданий на экран.
        /// </summary>
        /// <remarks>
        /// Происходит обращение к массиву объектов класса Source
        /// и вызов процедуры Display(), определенной для каждого производного класса.
        /// </remarks>       
        public static void ShowCatalog()
        {
            Trace.WriteLine("Запуск процедуры ShowCatalog");
            Console.WriteLine("---Каталог---");
            foreach (Source s in Catalog)
            {
                s.Display();
                Console.WriteLine();
            }
            Trace.WriteLine("Процедура ShowCatalog выполнена успешно. Данные выведены в консоль.");
        }
        /// <summary>
        /// Процедура InputCatalog() для чтения данных из файла input.txt.
        /// В зависимости от значения первого элемента в строке исходного файла
        /// происходит создание объекта необходимого класса (Book, Paper, EResource)
        /// и заполнение Source[] Catalog.
        /// </summary>
        /// <remarks>
        /// Первая строка исходного файла - значение n, строго соответствующее количеству 
        /// записей в каталоге и в исходном файле. Каждая следующая строка - отдельное издание.
        /// Разделителем характеристик является знак подчеркивания.
        /// Первый элемент соответствует типу издания, а последующие - особые
        /// характеристики, соответствующие свойствам каждого производного класса (имя автора, название, год и др.).
        /// </remarks> 
       
        public static void InputCatalog()
        {
            Trace.WriteLine("Запуск процедуры InputCatalog");
            string[] arrStr;
            StreamReader sr = new StreamReader("input.txt");
            string str = sr.ReadLine();
            // Значение из первой строки исходного файла определяет размер каталога.
            Catalog = new Source[Convert.ToInt32(str)];
            str = sr.ReadLine();
            int intCnt = 0;

            while (str != null)
            {
                arrStr = str.Split('_');

                switch (arrStr[0].ToLower())
                {
                    case "book":
                        Catalog[intCnt] = new Book(arrStr[1], arrStr[2], Convert.ToInt16(arrStr[3]), arrStr[4]);
                        intCnt++;
                        Array.Clear(arrStr, 0, arrStr.Length);
                        break;
                    case "paper":
                        Catalog[intCnt] = new Paper(arrStr[1], arrStr[2], Convert.ToInt32(arrStr[3]), Convert.ToInt16(arrStr[4]));
                        intCnt++;
                        Array.Clear(arrStr, 0, arrStr.Length);
                        break;
                    case "eresource":
                        Catalog[intCnt] = new EResource(arrStr[1], arrStr[2], arrStr[3], arrStr[4]);
                        intCnt++;
                        Array.Clear(arrStr, 0, arrStr.Length);
                        break;
                    // В случае несовпадения первого элемента строки и одного из существующих типов издания
                    // происходит вызов исключения.
                    default:
                        throw new Exception("Обнаружен неизвестный тип издания: " + arrStr[0]);
                }
                str = sr.ReadLine();
            }
            sr.Close();


            // Работа с XML-файлом
            string xmlFile = "data.xml";
            if (File.Exists(xmlFile)){
                File.Delete(xmlFile);
            }
            
            foreach (Source s in Catalog)
            {
                if( Convert.ToString(s.GetType()) == "Sources_Lab2.Paper")
                {
                    XmlSerializer serPaper = new XmlSerializer(typeof(Paper));
                    using (FileStream fs = new FileStream(xmlFile, FileMode.Append))
                    {
                        serPaper.Serialize(fs, s);
                    }
                }
                else if(Convert.ToString(s.GetType()) == "Sources_Lab2.Book")
                {
                    XmlSerializer serBook = new XmlSerializer(typeof(Book));
                    using (FileStream fs = new FileStream(xmlFile, FileMode.Append))
                    {
                        serBook.Serialize(fs, s);
                    }
                }
                else if (Convert.ToString(s.GetType()) == "Sources_Lab2.EResource")
                {
                    XmlSerializer serERes = new XmlSerializer(typeof(EResource));
                    using (FileStream fs = new FileStream(xmlFile, FileMode.Append))
                    {
                        serERes.Serialize(fs, s);
                    }
                }

            }
            Trace.WriteLine("Процедура InputCatalog выполнена успешно. Массив Catalog заполнен.");
        }

        /// <summary>
        /// Процедура SearchAuthor() для организации интерфейса поиска изданий по фамилии автора.
        /// </summary>
        /// <remarks>
        /// Сама функция проверки того, является ли издание искомым, организована в классе Source.
        /// </remarks> 
        public static void SearchAuthor()
        {
            Trace.WriteLine("Запуск процедуры SearchAuthor");
            int intCnt;
            Console.WriteLine("Для начала поиска по каталогу введите 1.");
            if (Console.ReadLine() == "1")
            {
                while (true)
                {
                    Console.WriteLine("Введите фамилию автора издания:");
                    string strSearchAuthor = Console.ReadLine();
                    Console.WriteLine();
                    intCnt = 0;
                    foreach (Source src in Catalog)
                    {
                        if (src.Author.ToLower() == strSearchAuthor.ToLower())
                        {
                            // Вызов метода, определенного в классе Source.
                            src.FindSources(strSearchAuthor);
                            src.Display();
                            intCnt++;
                            Console.WriteLine();
                        };
                    }
                    if (intCnt == 0)
                    {
                        Console.WriteLine("Ничего не найдено.");
                    }
                    else
                    {
                        Console.WriteLine("Поиск завершен. Найдено изданий: " + intCnt);
                    }
                    Console.WriteLine("Для продолжения поиска введите 1.");
                    if (Console.ReadLine() != "1")
                    {
                        break;
                    }
                }
            }
            Console.WriteLine("Выход из программы.");
            Trace.WriteLine("Процедура SearchAuthor выполнена успешно.");
        }
        /// <summary>
        /// Процедура Main - точка входа в программу.
        /// </summary>
        /// <param name="args"> Список аргументов командной строки</param>
        static void Main(string[] args)
        {
            try
            {
                InputCatalog();
                ShowCatalog();
                SearchAuthor();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.ReadLine();
        }
    }
}
