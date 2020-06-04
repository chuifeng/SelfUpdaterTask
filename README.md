# Задание

Цель: Разработать программу, которая будет обновлять сама себя.

Язык: C#

Требования: Корректная работа в ОС Windows XP – Windows 8.1. 
____________________________
Основные функциональные возможности:
1.	Отображение текущей версии*
2.	Обновление программы
________________________________
Структура каталогов:

•	Y:\new

•	Y:\new\test.exe

•	Y:\test.exe
____________________________
При запуске программы должно появиться окно с информацией о версии файла и кнопкой «Обновить».

При нажатии кнопки «Обновить» необходимо заменить файл «Y:\test.exe» файлом «Y:\new\test.exe». После успешной замены файла необходимо запустить программу заново.

Программы «Y:\new\test.exe» и «Y:\test.exe» идентичны друг другу за исключением версий файлов. Версии файлов «Y:\test.exe» и «Y:\new\test.exe» должны быть разными.

При запуске программы с параметром «ShowVersion» должно появляться сообщение с текстом «Версия программы текущая_версия_программы» и кнопкой «ОК». После нажатия на кнопку «ОК» программа должна быть закрыта.

自动更新,调用cmd 删除和启动文件


            try
            {
                var FilePath = Path.GetDirectoryName(Application.ExecutablePath);
                var FileName = Path.GetFileName(Application.ExecutablePath);
                var Exten = Path.GetExtension(Application.ExecutablePath);
                var OldFile = Path.GetFileNameWithoutExtension(Application.ExecutablePath) + "_old"+Exten;   
                
                if (File.Exists(String.Format("{0}\\new\\{1}", FilePath, FileName)))
                    Process.Start(new ProcessStartInfo()
                    {
                        Arguments = String.Format("/c ping localhost & del {0} ", String.Format("{0}\\new\\{1}", FilePath, FileName)),
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true,
                        FileName = "cmd.exe"
                    });

                File.Move(Application.ExecutablePath, String.Format("{0}\\new\\{1}", FilePath, FileName));
                File.Copy(String.Format("{0}\\new\\{1}", FilePath, FileName), Application.ExecutablePath);
                File.Copy(Application.ExecutablePath, OldFile);



                /*IntPtr hRes = BeginUpdateResourse(String.Format("{0}\\new\\{1}", FilePath, FileName), false);
                bool result = false;
                if (hRes == IntPtr.Zero) return;
                result = UpdateResource(hRes, VERSION_INFO_ID, VERSION_NAME_ID, VERSION_LANG_ID, "Hello", 10);
                if (!result) MessageBox.Show(String.Format("Error = "+Marshal.GetLastWin32Error()));
                if (!EndUpdateResource(hRes, false)) MessageBox.Show(String.Format("Error = "+Marshal.GetLastWin32Error()));*/

                

                Process.Start(new ProcessStartInfo()
                {
                    Arguments = String.Format("/c ping localhost & del {0} & start {1}", OldFile, Application.ExecutablePath),
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    FileName="cmd.exe"
                });
                Environment.Exit(1);
