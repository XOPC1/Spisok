namespace Spisochek{
    internal class Class1{
        static void Main(string[] args){
            string path_list = "main.txt";
            List<string> strings = new List<string>();
            List<string> classes = new List<string>();
            List<Spisochek> list_ = new List<Spisochek>();
            int count = 0;
            string exit = "";
            while (exit != "3"){
                Console.WriteLine("1)Основной список\n2)Готовые списки\n3)Выход");
                exit = Console.ReadLine();
                if (exit == "3"){
                    return;
                }
                switch (exit){
                    case "1":
                        Console.Clear();
                        while (exit != "3"){
                            Console.WriteLine("1)Добавить в основной список\n2)Выход");
                            exit = Console.ReadLine();
                            Console.Clear();
                            if (exit == "3"){
                                break;
                            }
                            switch (exit){
                                case "1":
                                    using (StreamWriter sw = new StreamWriter(path_list, true)){
                                        Console.WriteLine("Если закончили добавление, нажмите 0");
                                        string q = " ";
                                        while (q != "0"){
                                            q = Console.ReadLine();
                                            if (q == "0"){
                                                Console.Clear();
                                                break;
                                            }
                                            sw.WriteLine(q);
                                        }
                                    }
                                    break;
                                case "2":
                                    Console.Clear();
                                    return;
                                default: break;
                            }
                        }
                        break;
                    case "2":
                        while (exit != "7"){
                            Console.WriteLine("" +
                           "1) Новый список\n" +
                           "2) Добавить элемент в список\n" +
                           "3) Копирование файла\n" +
                           "4) Удалить файл\n" +
                           "5) Очистить список\n" +
                           "6) Вывести список на экран\n" +
                           "7) Выход\n");
                            exit = Console.ReadLine();
                            Console.Clear();
                            if (exit == "7"){
                                break;
                            }
                            switch (exit){
                                case "1":
                                    Console.WriteLine("введите название списка: ");
                                    string path_new_list = (Console.ReadLine()) + ".txt";
                                    using (StreamWriter writer = new StreamWriter(path_new_list, true)) ;
                                    break;
                                case "2":
                                    using (StreamReader reader = new StreamReader(path_list)){
                                        string? line;
                                        while ((line = reader.ReadLine()) != null){
                                            strings.Add(line);
                                        }
                                    }
                                    Console.WriteLine("Введите название списка: ");
                                    string path_spisok = (Console.ReadLine()) + ".txt";
                                    Console.WriteLine("Введите номер предмета который,хотите добавить в список и нажмите Enter," +
                                        "\nДля выхода нажмите '0'");
                                    for (int i = 0; i < strings.Count(); i++){
                                        Console.WriteLine("[" + (i + 1) + "]" + strings[i]);
                                    }
                                    using (StreamWriter writer = new(path_spisok, true)){
                                        while (true){
                                            int num = int.Parse(Console.ReadLine());
                                            try{
                                                if (num == 0){
                                                    break;
                                                }
                                                writer.WriteLine(strings[num - 1]);
                                            }
                                            catch{
                                                Console.WriteLine("Нубас, попробуй заного");
                                            }
                                        }
                                        writer.Close();
                                    }
                                    break;
                                case "3":
                                    Console.WriteLine("Введите название списка который хотите скопировать: ");
                                    string path_copy1 = (Console.ReadLine()) + ".txt";
                                    string path_copy = "copy-" + path_copy1;
                                    File.Copy(path_copy1, path_copy, true);
                                    Console.WriteLine("копирование завершено");
                                    break;
                                case "4":
                                    Console.WriteLine("Введите название списка который хотите удалить: ");
                                    string path_delete = (Console.ReadLine()) + ".txt";
                                    File.Delete(path_delete);
                                    Console.WriteLine("список " + path_delete + " удален");
                                    break;
                                case "5":
                                    Console.WriteLine("введите название списка: ");
                                    string path_clear = (Console.ReadLine()) + ".txt";
                                    using (StreamWriter writer = new StreamWriter(path_clear, false)) ;
                                    break;
                                case "6":
                                    string path_txt = @"C:\Users\Компьютер\Desktop\Шаг\Домашка\С#\KR\Spisok\Spisok\";
                                    DirectoryInfo dir = new DirectoryInfo(path_txt);
                                    foreach (FileInfo files in dir.GetFiles("*.txt")){
                                        Console.WriteLine("---> " + files.Name);
                                    }
                                    Console.WriteLine("введите название списка: ");
                                    string path_read = (Console.ReadLine()) + ".txt";
                                    using (StreamReader op = new StreamReader(path_read)){
                                        string? line;
                                        while ((line = op.ReadLine()) != null){
                                            strings.Add(line);
                                        }
                                    }
                                    for (int i = 0; i < strings.Count(); i++){
                                        Console.WriteLine((i + 1) + " - " + strings[i]);
                                    }
                                    strings.Clear();
                                    Console.WriteLine("Напишите 0 для выхода");
                                    string ex2 = "";
                                    ex2 = Console.ReadLine();
                                    if (ex2 == "0"){
                                        Console.Clear();
                                        break;
                                    }
                                    break;
                                case "7":
                                default: break;
                            }
                        }
                        break;
                    case "3":
                    default: break;
                }
            }
        }
    }
}