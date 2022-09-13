using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_7_3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const string CommandSortByFullName = "1";
            const string CommandSortByAge = "2";
            const string CommandSortByDisease = "3";

            bool isWork = true;
            Hospital hospital = new Hospital();

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine($"Выбирите пункт меню: \n" +
                    $"{CommandSortByFullName}) Сортировка по ФИО.\n" +
                    $"{CommandSortByAge}) Сортировка по возврасту. \n" +
                    $"{CommandSortByDisease}) Вывести больных с определенным заболеванием");
                string userinput = Console.ReadLine();

                switch (userinput)
                {
                    case CommandSortByFullName:
                        hospital.SortByFullName();
                        break;

                    case CommandSortByAge:
                        hospital.SortByAge();
                        break;

                    case CommandSortByDisease:
                        hospital.SortByDisease();
                        break;

                    default:
                        Console.WriteLine("Выбрана неверная команда !");
                        break;
                }
            }
        }
    }

    class Hospital
    {
        private List<Patient> _patients;

        public Hospital()
        {
            _patients = new List<Patient>();
            _patients.Add(new Patient("Александров Александр Алексанлрович", 30, Disease.Ифекция));
            _patients.Add(new Patient("Иванов Иван Иванович", 25, Disease.Ковид));
            _patients.Add(new Patient("Авдюхин Глеб Павлович", 22, Disease.Ифекция));
            _patients.Add(new Patient("Акимова Ольга Валентиновна", 27, Disease.Ковид));
            _patients.Add(new Patient("Алейникова Виктория Владимировна", 34, Disease.Ифекция));
            _patients.Add(new Patient("Белкина Александра Сергеевна", 37, Disease.Ковид));
            _patients.Add(new Patient("Белоглазова Анна Юрьевна", 45, Disease.Перелом));
            _patients.Add(new Patient("Беляева Алёна Игорьевна", 66, Disease.Ковид));
            _patients.Add(new Patient("Гаврилова Светлана Владимировна", 55, Disease.Простуда));
            _patients.Add(new Patient("Гавричкова Лилия Николаевна", 60, Disease.Перелом));
        }

        public void SortByFullName()
        {
            var patients = _patients.OrderBy(patient => patient.FullName);
            ShowPatients(patients);
        }

        public void SortByAge()
        {
            var patients = _patients.OrderBy(patient => patient.Age);
            ShowPatients(patients);
        }

        public void SortByDisease()
        {
            Console.Write("Введите название болезни:");

            if (Enum.TryParse(Console.ReadLine(), out Disease disease))
            {
                var patients = _patients.Where(patient => patient.Disease == disease);
                ShowPatients(patients);
            }
        }

        public void ShowPatients(IEnumerable<Patient> patients)
        {
            foreach (Patient patient in patients)
            {
                Console.WriteLine($"{patient.FullName} - {patient.Age} - {patient.Disease}");
            }
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }
    }

    class Patient
    {
        public string FullName { get; private set; }
        public int Age { get; private set; }
        public Disease Disease { get; private set; }

        public Patient(string fullName, int age, Disease disease)
        {
            FullName = fullName;
            Age = age;
            Disease = disease;
        }

    }
    public enum Disease
    {
        Ифекция,
        Простуда,
        Ковид,
        Перелом
    }

}
